using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberSecurity_Part2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This class controls the main WPF window: UI events, sending messages,
    /// handling the startup overlay, playing audio and recording voice notes.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Simple recorder helper. Created when user starts recording.
        private AudioRecorder? recorder;
        // Path to the temporary WAV file created when recording.
        private string? currentRecordingPath;
        // Guard to avoid re-entrant text change updates on the name box
        private bool isUpdatingNameText = false;
        // Sidebar state for collapsible topics
        private bool _sidebarOpen = true;

        public MainWindow()
        {
            InitializeComponent();
            // Hook the important UI events to their handlers.
            // NOTE: SendButton.Click and InputTextBox.KeyDown are already wired in XAML
            // so they are not subscribed here again to avoid double-firing.
            Loaded += MainWindow_Loaded;

            // ensure startup overlay blocks interaction until name provided
            StartupOverlay.IsHitTestVisible = true;
            NameTextBox.KeyDown += NameTextBox_KeyDown;
            NameTextBox.TextChanged += NameTextBox_TextChanged;

            // recorder is initialized when the user starts recording to save resources.
        }

        // Toggle handler for the Topics sidebar button in the header.
        private void BtnToggleTopics_Click(object sender, RoutedEventArgs e)
        {
            _sidebarOpen = !_sidebarOpen;
            // Use the named column directly for reliability
            var col = SidebarColumn;
            if (col == null) return;

            var anim = new GridLengthAnimation
            {
                From = col.Width,
                To = _sidebarOpen ? new GridLength(240, GridUnitType.Pixel) : new GridLength(0, GridUnitType.Pixel),
                Duration = new Duration(TimeSpan.FromMilliseconds(220)),
                EasingFunction = new System.Windows.Media.Animation.QuadraticEase { EasingMode = System.Windows.Media.Animation.EasingMode.EaseInOut }
            };

            // Begin the animation on the column's Width property
            col.BeginAnimation(ColumnDefinition.WidthProperty, anim);

            // Update the icon label using the named control
            if (ToggleIcon != null) ToggleIcon.Text = _sidebarOpen ? "✕" : "☰";
        }

        // Toggle the sidebar visibility with a simple width animation
        private void SidebarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sidebar = this.FindName("Sidebar") as Border;
                if (sidebar == null)
                {
                    // fallback: find first border in column 0
                    sidebar = LogicalTreeHelper.FindLogicalNode(this, "") as Border;
                }
                // Simple toggle: collapse or show the sidebar container
                var gridCol = this.MainContentGrid.ColumnDefinitions[0];
                if (gridCol.Width.Value > 0)
                {
                    gridCol.Width = new GridLength(0);
                }
                else
                {
                    gridCol.Width = new GridLength(240);
                }
            }
            catch { }
        }

        // Called when the window finishes loading.
        // We make sure the header user text is up to date and focus the name box.
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // If no user is set, keep it empty so the overlay will ask for a name.
            if (string.IsNullOrWhiteSpace(UserManager.CurrentUserName))
            {
                UserManager.CurrentUserName = string.Empty;
            }
            else
            {
                // Update the header display to show the current user.
                UpdateHeaderUser();
            }

            // Ensure the startup overlay is visible and interactive and the name box is enabled/focused.
            try
            {
                if (StartupOverlay != null)
                {
                    StartupOverlay.Visibility = Visibility.Visible;
                    StartupOverlay.IsHitTestVisible = true;
                }

                if (NameTextBox != null)
                {
                    NameTextBox.IsEnabled = true;
                    NameTextBox.Focusable = true;
                    // Focus after layout completes to avoid timing issues
                    this.Dispatcher.BeginInvoke(new System.Action(() =>
                    {
                        try { NameTextBox.Focus(); } catch { }
                    }));
                }
            }
            catch { }

            // Focus the name box so the user can type their name immediately.
            NameTextBox.Focus();
        }

        // Update the small "User:" text in the header to show current username.
        private void UpdateHeaderUser()
        {
            if (HeaderUserText != null)
            {
                HeaderUserText.Text = $"User: {UserManager.CurrentUserName}";
            }
        }

        // When the user presses Enter inside the name textbox, treat it as 'Continue'.
        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ContinueButton_Click(this, new RoutedEventArgs());
            }
        }

        // Normalize the name to Title Case as the user types.
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdatingNameText) return;
            try
            {
                isUpdatingNameText = true;
                var tb = sender as TextBox;
                if (tb == null) return;
                var selStart = tb.SelectionStart;
                var original = tb.Text ?? string.Empty;
                // Use TextInfo ToTitleCase but preserve existing casing for acronyms by lowering first
                var ti = CultureInfo.CurrentCulture.TextInfo;
                var lower = original.ToLower();
                var titled = ti.ToTitleCase(lower);
                if (titled != original)
                {
                    tb.Text = titled;
                    // restore caret roughly at same logical place
                    tb.SelectionStart = Math.Min(selStart + (titled.Length - original.Length), tb.Text.Length);
                }
            }
            finally
            {
                isUpdatingNameText = false;
            }
        }

        // Continue button handler on the startup overlay.
        // Validates the name and then shows the main chat UI.
        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text?.Trim();
            // Require at least a non-empty name (allow single-word names to avoid blocking users)
            if (string.IsNullOrWhiteSpace(name))
            {
                // Show a friendly warning if the name is empty.
                NameWarning.Visibility = Visibility.Visible;
                return;
            }

            NameWarning.Visibility = Visibility.Collapsed;

            // Save the name for this session and update header.
            UserManager.CurrentUserName = name;
            UpdateHeaderUser();

            // Increment an internal usage counter for analytics (saved to disk).
            var visits = UserManager.IncrementUserCount(name);

            // Enable the main UI and hide the startup overlay immediately
            MainContentGrid.IsEnabled = true;
            StartupOverlay.Visibility = Visibility.Collapsed;
            StartupOverlay.IsHitTestVisible = false;

            // Make the EndChatButton visible now that the user has logged in.
            EndChatButton.Visibility = Visibility.Visible;

            // Play the 'Abos2.wav' sound synchronously in a background task so we can await it
            try
            {
                var path = System.IO.Path.Combine(System.AppContext.BaseDirectory, "Abos2.wav");
                if (System.IO.File.Exists(path))
                {
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        try
                        {
                            var sp = new System.Media.SoundPlayer(path);
                            sp.PlaySync();
                        }
                        catch { }
                    });
                }
            }
            catch { }

            // Show the user's own greeting message first (right side bubble)
            // so it looks like the user just "arrived" and introduced themselves.
            var userGreeting = new ChatMessage
            {
                Sender = UserManager.CurrentUserName,
                Text = $"Hi, I am {UserManager.CurrentUserName}.",
                IsUser = true
            };
            ChatListBox.Items.Add(userGreeting);
            ChatListBox.ScrollIntoView(userGreeting);

            // Small pause so the greeting feels like a real conversation exchange.
            await System.Threading.Tasks.Task.Delay(400);

            // After audio finishes, post the friendly personalized message in the chat bubble.
            ChatMessage botWelcome;
            if (visits > 2)
            {
                // Returning user (more than two visits)
                botWelcome = new ChatMessage
                {
                    Sender = "Bot",
                    Text = $"Welcome back {UserManager.CurrentUserName}! 👋 I remember you from your previous visits. Great to have you here again. Feel free to ask me anything about cybersecurity — passwords, phishing, malware, privacy and more.",
                    IsUser = false
                };
            }
            else
            {
                // First or second visit
                botWelcome = new ChatMessage
                {
                    Sender = "Bot",
                    Text = $"Welcome {UserManager.CurrentUserName}! 👋 I am your AI Cybersecurity Assistant. It is a pleasure to have you here. You may ask me about passwords, phishing, malware, privacy, safe browsing and much more. Select a topic on the left or type your question below to get started.",
                    IsUser = false
                };
            }

            ChatListBox.Items.Add(botWelcome);
            ChatListBox.ScrollIntoView(botWelcome);
            InputTextBox.Focus();
        }

        // If the user presses Enter in the chat input, send the message.
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.None)
            {
                e.Handled = true; // prevent newline
                SendCurrentMessage();
            }
        }

        // Send button clicked - send the user's message to the chatbot engine.
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendCurrentMessage();
        }

        // Get the text from input, add it to the chat UI, call ChatBot.GetResponse and display the reply.
        private void SendCurrentMessage()
        {
            var text = InputTextBox.Text?.Trim();
            if (string.IsNullOrWhiteSpace(text)) return;

            try
            {
                // Create a ChatMessage object to represent the user's message.
                var userMsg = new ChatMessage { Sender = UserManager.CurrentUserName, Text = text, IsUser = true };
                // Update UI on the dispatcher to be safe from any calling context
                this.Dispatcher.Invoke(() =>
                {
                    ChatListBox.Items.Add(userMsg);
                    ChatListBox.ScrollIntoView(userMsg);
                });

                // Call chatbot engine (guarded)
                string response;
                try
                {
                    response = ChatBot.GetResponse(text) ?? "I'm not sure I understand. Can you try rephrasing?";
                }
                catch (Exception ex)
                {
                    // Log if desired (Debug.WriteLine) and produce friendly error
                    System.Diagnostics.Debug.WriteLine($"ChatBot.GetResponse error: {ex.Message}");
                    response = "I'm having trouble processing that right now. Please try again.";
                }

                var botMsg = new ChatMessage { Sender = "Bot", Text = response, IsUser = false };
                this.Dispatcher.Invoke(() =>
                {
                    ChatListBox.Items.Add(botMsg);
                    ChatListBox.ScrollIntoView(botMsg);
                });

                // Clear the input and keep focus for further typing.
                this.Dispatcher.Invoke(() =>
                {
                    InputTextBox.Clear();
                    InputTextBox.Focus();
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SendCurrentMessage error: {ex.Message}");
                var err = new ChatMessage { Sender = "Bot", Text = "An unexpected error occurred. Please try again.", IsUser = false };
                this.Dispatcher.Invoke(() =>
                {
                    ChatListBox.Items.Add(err);
                    ChatListBox.ScrollIntoView(err);
                });
            }
        }

        // When a topic button in the left sidebar is clicked, send that topic as a user action
        // and ask the ChatBot engine to explain it.
        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.Tag is string tag)
                {
                    // topicKey is the identifier used in TopicManager.Topics
                    var topicKey = tag.Trim();
                    // Display the clicked topic in the chat as if the user sent it.
                    var display = btn.Content is StackPanel sp && sp.Children.Count > 1 && sp.Children[1] is TextBlock tb ? tb.Text : topicKey;
                    var userMsg = new ChatMessage { Sender = UserManager.CurrentUserName, Text = display, IsUser = true };
                    ChatListBox.Items.Add(userMsg);
                    ChatListBox.ScrollIntoView(userMsg);

                    // Query chatbot engine for the topic's explanation and display it.
                    string response;
                    try
                    {
                        response = ChatBot.GetResponse(topicKey) ?? "I'm not sure I understand. Can you try rephrasing?";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"ChatBot.GetResponse error: {ex.Message}");
                        response = "I'm having trouble processing that right now. Please try again.";
                    }

                    var botMsg = new ChatMessage { Sender = "Bot", Text = response, IsUser = false };
                    ChatListBox.Items.Add(botMsg);
                    ChatListBox.ScrollIntoView(botMsg);

                    InputTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TopicButton_Click error: {ex.Message}");
            }
        }

        // End Chat button handler: show friendly exit lines and close the app.
        private void EndChatButton_Click(object sender, RoutedEventArgs e)
        {
            // call the existing ExitProgram flow (friendly messages) and then close
            ExitSequence();
        }

        // ExitSequence posts several farewell messages and then closes the window.
        private async void ExitSequence()
        {
            // Display the original console exit lines as bot messages in the chat sequentially
            var lines = new string[]
            {
                $"Goodbye, {UserManager.CurrentUserName}.",
                "Thank you for using Cyber Times With Abo.",
                "Stay vigilant and stay safe online.",
                "Remember, cybersecurity is a shared responsibility. Together, we can create a safer digital world for everyone.",
                "Made by Abongile Manqana"
            };

            foreach (var line in lines)
            {
                var msg = new ChatMessage { Sender = "Bot", Text = line, IsUser = false };
                ChatListBox.Items.Add(msg);
                ChatListBox.ScrollIntoView(msg);
                // small pause so messages appear readable
                await System.Threading.Tasks.Task.Delay(450);
            }

            // give a moment before closing
            await System.Threading.Tasks.Task.Delay(550);
            this.Close();
        }

        // RecordButton toggles recording state. Uses AudioRecorder to write a WAV file.
        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle recording state
            if (recorder == null)
            {
                try
                {
                    recorder = new AudioRecorder();
                    var tmp = System.IO.Path.GetTempFileName();
                    var wav = System.IO.Path.ChangeExtension(tmp, ".wav");
                    // ensure unique
                    if (System.IO.File.Exists(wav)) System.IO.File.Delete(wav);
                    currentRecordingPath = wav;
                    recorder.StartRecording(wav);
                    RecordButton.Content = "⏺"; // recording indicator
                }
                catch
                {
                    recorder = null;
                }
            }
            else
            {
                // stop and send the recorded file to bot (for now, we just add a message)
                recorder.StopRecording();
                recorder.Dispose();
                recorder = null;
                RecordButton.Content = "🎤";

                if (!string.IsNullOrEmpty(currentRecordingPath) && System.IO.File.Exists(currentRecordingPath))
                {
                    // show a user message indicating a voice note was recorded
                    var userMsg = new ChatMessage { Sender = UserManager.CurrentUserName, Text = "[Voice message recorded]", IsUser = true };
                    ChatListBox.Items.Add(userMsg);
                    ChatListBox.ScrollIntoView(userMsg);

                    // Optionally play the recorded audio using SoundPlayer
                    try
                    {
                        var sp = new System.Media.SoundPlayer(currentRecordingPath);
                        sp.Play();
                    }
                    catch { }

                    // clean up temp file later if desired
                }
            }
        }

        private void NameTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}