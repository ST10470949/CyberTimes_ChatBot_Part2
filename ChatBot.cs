using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberTimes_ChatBot_Part2
{
    public static class ChatBot
    {
        // simple in-memory memories (session-only)
        private static string? memoryName = null;
        private static string? memoryMood = null;
        private static List<string> memoryPreferences = new List<string>();
        // store a single favourite cybersecurity topic (session-only)
        private static string? memoryFavoriteTopic = null;

        // Main entry for getting a response from the chatbot engine
        public static string GetResponse(string input)
        {
            var user = string.IsNullOrWhiteSpace(UserManager.CurrentUserName) ? "User" : UserManager.CurrentUserName;
            if (string.IsNullOrWhiteSpace(input)) return "Please type a question or select a topic.";

            var lower = (input ?? string.Empty).ToLower();

            // Quick help
            if (lower.Contains("what can i ask") || lower.Contains("what can i ask you") || lower.Contains("what can i ask about") || lower.Contains("what can you answer"))
            {
                return $"{user}, You can ask me about: " + string.Join(", ", TopicManager.Topics.Keys);
            }

            // First process memory commands / personal phrases (priority #1)
            var mem = ProcessMemoryInput(input, lower);
            if (!string.IsNullOrEmpty(mem))
            {
                // Memory responses have top priority and should be returned immediately
                return mem;
            }

            // Sentiment detection: if user expresses an emotion, reply empathetically and give a tip immediately
            var sentimentReply = DetectSentimentAndTip(lower);
            if (!string.IsNullOrEmpty(sentimentReply))
            {
                // If we know the user's favourite topic, add a personalised sentence
                if (!string.IsNullOrEmpty(memoryFavoriteTopic))
                {
                    sentimentReply += "\n\n" + $"Since you are interested in {memoryFavoriteTopic}, remember to use secure passwords and avoid sharing personal information on public websites.";
                }
                // If we know the user's name via UserManager or memory, personalise the start
                var knownName = !string.IsNullOrEmpty(memoryName) ? memoryName : (!string.IsNullOrWhiteSpace(UserManager.CurrentUserName) ? UserManager.CurrentUserName : null);
                if (!string.IsNullOrEmpty(knownName)) sentimentReply = knownName + ", " + sentimentReply;
                return sentimentReply;
            }

            // --- PRIORITY: Cybersecurity topic detection ---
            // numeric shortcuts map to topics
            if (int.TryParse(lower, out int n))
            {
                var keys = TopicManager.Topics.Keys.ToList();
                if (n >= 1 && n <= keys.Count)
                {
                    var key = keys[n - 1];
                    return user + ", " + TopicManager.Topics[key];
                }
            }

            // direct topic name match (highest priority) - collect all direct matches in the full input
            var matched = new List<string>();
            foreach (var kv in TopicManager.Topics)
            {
                if (lower.Contains(kv.Key) && !matched.Contains(kv.Key)) matched.Add(kv.Key);
            }

            // Split input into segments by common separators and conjunctions so multiple topics/questions are detected
            var segments = System.Text.RegularExpressions.Regex.Split(lower, "\\?|!|;|\\.|,|\\band\\b|\\balso\\b|\\bthen\\b|\\bplus\\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                .Select(s => s.Trim()).Where(s => s.Length > 0).ToList();

            foreach (var seg in segments)
            {
                // tokens per segment
                var segTokens = new List<string>();
                foreach (var t in System.Text.RegularExpressions.Regex.Split(seg, "[^a-z0-9]+"))
                {
                    if (!string.IsNullOrEmpty(t)) segTokens.Add(t);
                }

                // check direct phrase match within the segment first
                foreach (var kv in TopicManager.Topics)
                {
                    if (seg.Contains(kv.Key) && !matched.Contains(kv.Key)) matched.Add(kv.Key);
                }

                // token-level matching
                foreach (var kv in TopicManager.Topics)
                {
                    if (matched.Contains(kv.Key)) continue;
                    var keyTokens = kv.Key.Split(' ');
                    foreach (var kt in keyTokens)
                    {
                        if (segTokens.Contains(kt)) { matched.Add(kv.Key); break; }
                    }
                }
            }

            // fuzzy suggestions across full input tokens as a last attempt to catch misspellings
            var fullTokens = new List<string>();
            foreach (var t in System.Text.RegularExpressions.Regex.Split(lower, "[^a-z0-9]+")) if (!string.IsNullOrEmpty(t)) fullTokens.Add(t);
            if (matched.Count == 0)
            {
                var suggestions = FuzzyMatcher.GetSuggestions(TopicManager.Topics.Keys, fullTokens);
                foreach (var s in suggestions)
                {
                    if (!matched.Contains(s)) matched.Add(s);
                }
            }

            if (matched.Count > 0)
            {
                // build combined response for all matched topics, preserving order and avoiding duplicates
                var parts = new List<string>();
                foreach (var key in matched)
                {
                    if (TopicManager.Topics.TryGetValue(key, out var text)) parts.Add(text);
                }

                // include memory response at top if it exists and is not redundant
                if (!string.IsNullOrEmpty(mem))
                {
                    parts.Insert(0, mem);
                }

                return user + ", " + string.Join("\n\n", parts);
            }

            // --- END PRIORITY: topics ---

            // Now handle small-talk and utility responses (date/time/greetings)
            // Date/time detection: only trigger on explicit date/time queries
            if (IsDateQuestion(lower))
                return "Today's date is " + DateTime.Now.ToShortDateString() + ".";

            if (IsTimeQuestion(lower))
                return "The current time is " + DateTime.Now.ToShortTimeString() + ".";

            // Greetings and small talk
            if (lower.Contains("hello") || lower.Contains("hi") || lower.Contains("hey"))
                return "Hello! How can I help you with cybersecurity today?";

            if (lower.Contains("thank") || lower.Contains("thanks"))
                return "You’re welcome — happy to help. Ask me anything about online safety.";

            if (lower.Contains("your name") || lower.Contains("who are you") || lower.Contains("what are you"))
                return "I am Cyber Times With Abo, your cybersecurity assistant. I can explain threats and give practical advice.";

            if (lower.Contains("purpose") || lower.Contains("what do you do") || lower.Contains("about you"))
                return "I help people learn about online risks and how to protect themselves — passwords, phishing, malware, privacy and more.";

            if (lower.Contains("weather"))
                return "I can't check live weather, but remember to avoid clicking unknown links in weather alerts — they can be phishing.";

            if (lower.Contains("bye") || lower.Contains("goodbye") || lower.Contains("see you"))
                return "Goodbye — stay safe online!";

            if (lower.Contains("help") || lower.Contains("how do i") || lower.Contains("how to"))
                return "Tell me the topic you need help with, for example 'passwords', 'phishing', or 'safe browsing'.";

            if (lower.Contains("joke") || lower.Contains("funny"))
                return "Why did the computer get cold? Because it left its Windows open. 😄";

            return "I didn't understand that. Try asking about 'phishing', 'malware', or 'passwords', or pick a topic from the sidebar.";
        }

        // ProcessMemoryInput looks for phrases that set or request remembered values.
        // Returns a reply when a memory action is handled, otherwise null.
        public static string ProcessMemoryInput(string rawInput, string lower)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;

            // Set name (avoid misclassifying short emotion phrases like "I am scared")
            string[] namePrefixes = new[] { "my name is ", "call me " };
            foreach (var p in namePrefixes)
            {
                int idx = lower.IndexOf(p, StringComparison.Ordinal);
                if (idx == 0)
                {
                    string value = rawInput.Substring(p.Length).Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        memoryName = value;
                        // also update shared user store so other parts of app use the name
                        UserManager.CurrentUserName = memoryName;
                        return $"Nice to meet you, {memoryName}. I'll remember your name.";
                    }
                }
            }

            // Also accept "I am <name>" or "I'm <name>" but only when the remainder looks like a name (no emotion words)
            if (lower.StartsWith("i am ") || lower.StartsWith("i'm ") || lower.StartsWith("im "))
            {
                var candidate = rawInput.Substring(rawInput.IndexOf(' ') + 1).Trim();
                // simple heuristic: treat as name if it's 1-3 words and not an emotion keyword
                var tokens = candidate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var emotionWords = new[] { "scared", "afraid", "anxious", "nervous", "unsafe", "sad", "happy", "upset", "angry" };
                if (tokens.Length > 0 && tokens.Length <= 3 && !tokens.Any(t => emotionWords.Contains(t.ToLower())))
                {
                    memoryName = candidate;
                    UserManager.CurrentUserName = memoryName;
                    return $"Nice to meet you, {memoryName}. I'll remember your name.";
                }
            }

            // Ask for name
            if (lower.Contains("what is my name") || lower.Contains("what's my name") || lower.Contains("do you know my name"))
            {
                if (!string.IsNullOrEmpty(memoryName)) return $"Your name is {memoryName}.";
                if (!string.IsNullOrEmpty(UserManager.CurrentUserName)) return $"Your name is {UserManager.CurrentUserName}.";
                return "I don't know your name yet. You can tell me by saying 'my name is ...'";
            }

            // Set mood
            string[] moodPrefixes = new[] { "my mood is ", "i feel ", "i'm feeling ", "i am feeling " };
            foreach (var p in moodPrefixes)
            {
                int idx = lower.IndexOf(p, StringComparison.Ordinal);
                if (idx == 0)
                {
                    string value = rawInput.Substring(p.Length).Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        memoryMood = value;
                        return $"Thanks for telling me — I have noted that you're feeling {memoryMood}.";
                    }
                }
            }

            // Ask for mood
            if (lower.Contains("what is my mood") || lower.Contains("how am i feeling") || lower.Contains("what am i feeling"))
            {
                if (!string.IsNullOrEmpty(memoryMood)) return $"You told me you're feeling {memoryMood}.";
                return "I don't know how you're feeling yet. You can tell me by saying 'I feel ...'";
            }

            // Preferences: set simple preferences
            string[] prefPrefixes = new[] { "i prefer ", "my preference is ", "i like " };
            foreach (var p in prefPrefixes)
            {
                int idx = lower.IndexOf(p, StringComparison.Ordinal);
                if (idx == 0)
                {
                    string value = rawInput.Substring(p.Length).Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        memoryPreferences.Add(value);
                        // If the preference looks like a cybersecurity topic, store as favorite topic for personalization
                        // match against known topics keys
                        foreach (var k in TopicManager.Topics.Keys)
                        {
                            if (value.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                memoryFavoriteTopic = k;
                                break;
                            }
                        }
                        return $"Noted. I'll remember that you prefer {value}.";
                    }
                }
            }

            // Ask for preferences
            if (lower.Contains("what are my preferences") || lower.Contains("what do i prefer") || lower.Contains("what do i like"))
            {
                if (memoryPreferences.Count > 0) return "You told me you prefer: " + string.Join(", ", memoryPreferences) + ".";
                return "You haven't told me any preferences yet. Say 'I prefer ...' to set one.";
            }

            // Forget commands
            if (lower.Contains("forget my name") || lower.Contains("clear my name"))
            {
                memoryName = null;
                return "Okay, I have forgotten your name.";
            }

            if (lower.Contains("forget my mood") || lower.Contains("clear my mood"))
            {
                memoryMood = null;
                return "Okay, I have forgotten your mood.";
            }

            // not a memory-related input
            return null;
        }

        // Detect if the user is explicitly asking for the date
        private static bool IsDateQuestion(string lower)
        {
            if (string.IsNullOrWhiteSpace(lower)) return false;
            // common patterns that indicate intent to get current date
            var patterns = new[] { "what is today's date", "what is today", "what is the date", "tell me the date", "today's date", "current date", "what date is it", "what's the date" };
            foreach (var p in patterns)
            {
                if (lower.Contains(p)) return true;
            }
            // also allow short explicit forms
            if (lower.Trim() == "date" || lower.Trim() == "today") return true;
            return false;
        }

        // Detect common sentiments from the user's input and return an empathetic reply with a cybersecurity tip.
        // Returns null when no sentiment is detected.
        private static string DetectSentimentAndTip(string lower)
        {
            if (string.IsNullOrWhiteSpace(lower)) return null;

            // Worried
            var worried = new[] { "scared", "afraid", "anxious", "nervous", "unsafe" };
            foreach (var w in worried) if (lower.Contains(w)) return "I understand that this situation can feel stressful. A good cybersecurity practice is to enable two-factor authentication and change your passwords regularly.";

            // Curious
            var curious = new[] { "wondering", "interested", "want to know", "how does" };
            foreach (var c in curious) if (lower.Contains(c)) return "That is a great question. Learning about cybersecurity is very important. A useful tip is to avoid clicking unknown links in emails or messages.";

            // Frustrated
            var frustrated = new[] { "annoyed", "confused", "don't understand", "dont understand", "do not understand" };
            foreach (var f in frustrated) if (lower.Contains(f)) return "I understand your frustration. Cybersecurity topics can sometimes be confusing. One useful tip is to always use strong and unique passwords for different accounts.";

            // Happy
            var happy = new[] { "great", "thanks", "helpful", "awesome", "love it" };
            foreach (var h in happy) if (lower.Contains(h)) return "I am glad you found it helpful. A good habit is to keep your software updated to stay protected from security threats.";

            return null;
        }

        // Detect if the user is explicitly asking for the time
        private static bool IsTimeQuestion(string lower)
        {
            if (string.IsNullOrWhiteSpace(lower)) return false;
            var patterns = new[] { "what time is it", "current time", "tell me the time", "what is the time", "time now", "what's the time" };
            foreach (var p in patterns)
            {
                if (lower.Contains(p)) return true;
            }
            if (lower.Trim() == "time") return true;
            return false;
        }
    }
}
