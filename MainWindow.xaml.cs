using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberTimes_ChatBot_Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This class controls the main WPF window: UI events, sending messages,
    /// handling the startup overlay, playing audio and recording voice notes.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Simple recorder helper (NAudio wrapper). Created when user starts recording.
        private AudioRecorder? recorder;
        // Path to the temporary WAV file created when recording.
        private string? currentRecordingPath;

        public MainWindow()
        {
            InitializeComponent();
            // Hook the important UI events to their handlers.
            SendButton.Click += SendButton_Click;
            InputTextBox.KeyDown += InputTextBox_KeyDown;
            Loaded += MainWindow_Loaded;

            ContinueButton.Click += ContinueButton_Click;
            NameTextBox.KeyDown += NameTextBox_KeyDown;
            EndChatButton.Click += EndChatButton_Click;
            // recorder is initialized when the user starts recording to save resources.
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

        // Continue button handler on the startup overlay.
        // Validates the name and then shows the main chat UI.
        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text?.Trim();
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

            // Hide the overlay and play the welcome audio.
            StartupOverlay.Visibility = Visibility.Collapsed;
            AudioPlayer.PlayWelcomeSound();

            // Show a friendly personalized message in the chat bubble.
            ChatMessage botWelcome;
            if (visits > 2)
            {
                // Returning user (more than two visits)
                botWelcome = new ChatMessage { Sender = "Bot", Text = $"Welcome back {UserManager.CurrentUserName}! I remember you from your previous visits.", IsUser = false };
            }
            else
            {
                // First or second visit
                botWelcome = new ChatMessage { Sender = "Bot", Text = $"Welcome {UserManager.CurrentUserName}, I am your AI Cybersecurity Assistant. It is a pleasure to have you here. You may ask about passwords, scams, malware, privacy, or safe browsing.", IsUser = false };
            }
            ChatListBox.Items.Add(botWelcome);
            ChatListBox.ScrollIntoView(botWelcome);

            // Focus the chat input so the user can type their first question.
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

            // Create a ChatMessage object to represent the user's message.
            var userMsg = new ChatMessage { Sender = UserManager.CurrentUserName, Text = text, IsUser = true };
            ChatListBox.Items.Add(userMsg);
            ChatListBox.ScrollIntoView(userMsg);

            // Get a reply from the ChatBot engine and add it as a bot ChatMessage.
            var response = ChatBot.GetResponse(text);
            var botMsg = new ChatMessage { Sender = "Bot", Text = response, IsUser = false };
            ChatListBox.Items.Add(botMsg);
            ChatListBox.ScrollIntoView(botMsg);

            // Clear the input and keep focus for further typing.
            InputTextBox.Clear();
            InputTextBox.Focus();
        }

        // When a topic button in the left sidebar is clicked, send that topic as a user action
        // and ask the ChatBot engine to explain it.
        private void TopicButton_Click(object sender, RoutedEventArgs e)
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
                var response = ChatBot.GetResponse(topicKey);
                var botMsg = new ChatMessage { Sender = "Bot", Text = response, IsUser = false };
                ChatListBox.Items.Add(botMsg);
                ChatListBox.ScrollIntoView(botMsg);

                InputTextBox.Focus();
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
    }
}