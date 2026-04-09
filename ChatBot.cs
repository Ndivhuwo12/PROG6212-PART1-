using System;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private readonly UserProfile    _user;
        private readonly ResponseEngine _engine;

        public ChatBot()
        {
            _user   = new UserProfile();
            _engine = new ResponseEngine();
        }

        public void Start()
        {
            CollectUserName();
            ShowWelcomeMessage();
            RunMainLoop();
            ShowFarewell();
        }

        // ── Name collection ───────────────────────────────────────────────────

        private void CollectUserName()
        {
            DisplayHelper.SectionHeader("Identity Verification", ConsoleColor.Yellow);

            DisplayHelper.DrawThinBox(new[]
            {
                "Before we begin, I need to know who I'm talking to.",
                "Your name will be used to personalise our conversation."
            }, ConsoleColor.DarkYellow, ConsoleColor.Gray);

            DisplayHelper.BlankLine();
            DisplayHelper.WriteColour("  Enter your name below:", ConsoleColor.White);
            DisplayHelper.BlankLine();

            string? input = null;
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  ➤  ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayHelper.WriteColour("  ⚠  Name cannot be empty. Please try again.", ConsoleColor.Red);
                    DisplayHelper.BlankLine();
                }
            }

            _user.Name = input.Trim();
        }

        // ── Welcome screen ────────────────────────────────────────────────────

        private void ShowWelcomeMessage()
        {
            DisplayHelper.SectionHeader($"Welcome, {_user.Name}", ConsoleColor.Green);

            DisplayHelper.DrawBox(new[]
            {
                $"Hello, {_user.Name}! Great to have you here.",
                "",
                "I am your personal Cybersecurity Awareness Assistant.",
                "My mission is to help South African citizens stay",
                "safe and informed in an increasingly digital world.",
                "",
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━",
                "Available Topics:",
                "  🔑 Password Safety    🎣 Phishing Scams",
                "  🌐 Safe Browsing      🔒 Privacy Settings",
                "  🛡  Malware           👾 Social Engineering",
                "  💀 Ransomware         ⚠  Scam Awareness",
                "  📱 Two-Factor Auth    🌍 VPN",
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━",
                "Type  'help'  to see this list again.",
                "Type  'exit'  or  'quit'  to end the session."
            }, ConsoleColor.Green, ConsoleColor.White);

            DisplayHelper.BlankLine();
        }

        // ── Main loop ─────────────────────────────────────────────────────────

        private void RunMainLoop()
        {
            DisplayHelper.SectionHeader("Conversation", ConsoleColor.Cyan);

            while (true)
            {
                DisplayHelper.ShowUserPrompt(_user.Name);

                string? rawInput = Console.ReadLine();
                Console.ResetColor();

                // EOF / Ctrl+Z
                if (rawInput is null)
                {
                    DisplayHelper.BotSay("No input detected. Ending session.", ConsoleColor.DarkYellow);
                    break;
                }

                string trimmed = rawInput.Trim();

                // Empty input
                if (string.IsNullOrWhiteSpace(trimmed))
                {
                    DisplayHelper.BotSay(
                        "⚠  It looks like you didn't type anything.\n" +
                        "   Please enter a question or type 'help' for available topics.",
                        ConsoleColor.Yellow);
                    continue;
                }

                // Exit
                if (ResponseEngine.IsExitCommand(trimmed))
                    break;

                // Response
                _user.MessageCount++;
                string response = _engine.GetResponse(trimmed);
                DisplayHelper.BotSay(response);

                DisplayHelper.BlankLine();
                DisplayHelper.Divider(ConsoleColor.DarkGray);
            }
        }

        // ── Farewell ──────────────────────────────────────────────────────────

        private void ShowFarewell()
        {
            DisplayHelper.BlankLine();
            DisplayHelper.DrawBox(new[]
            {
                "👋  Session Complete",
                "",
                $"Thank you for chatting, {_user.Name}!",
                $"You asked {_user.MessageCount} question(s) in this session.",
                "",
                "Remember: Stay alert. Stay safe. Stay informed.",
                "",
                "🛡  Cybersecurity Awareness Assistant  |  PROG6221"
            }, ConsoleColor.DarkGreen, ConsoleColor.Green);

            DisplayHelper.BlankLine();
        }
    }
}
