using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Houses all predefined chatbot responses and the keyword-matching logic.
    /// </summary>
    public class ResponseEngine
    {
        // ── Keyword → response dictionary ─────────────────────────────────────

        private readonly Dictionary<string, string> _keywordResponses = new(StringComparer.OrdinalIgnoreCase)
        {
            // Greetings / general
            ["how are you"] =
                "I'm running at full security capacity, thank you for asking! 😊 How can I help you stay safe today?",

            ["what is your purpose"] =
                "I'm the Cybersecurity Awareness Assistant. My purpose is to educate South African citizens about " +
                "online threats like phishing, malware, and social engineering – helping you stay safer on the internet.",

            ["what can i ask you about"] =
                "Great question! You can ask me about:\n" +
                "  🔑  Password safety\n" +
                "  🎣  Phishing scams\n" +
                "  🌐  Safe browsing\n" +
                "  🔒  Privacy settings\n" +
                "  🛡️   Malware & ransomware\n" +
                "  👾  Social engineering\n" +
                "  ❓  Or just say 'help' to see this list again.",

            ["help"] =
                "You can ask me about password safety, phishing, safe browsing, privacy, malware, or social engineering. " +
                "Type 'exit' or 'quit' to leave.",

            // Cybersecurity topics
            ["password"] =
                "🔑 Password Safety Tip:\n" +
                "  • Use at least 12 characters mixing letters, numbers, and symbols.\n" +
                "  • Never reuse the same password across multiple sites.\n" +
                "  • Consider a reputable password manager like Bitwarden or 1Password.\n" +
                "  • Enable two-factor authentication (2FA) wherever possible.",

            ["phishing"] =
                "🎣 Phishing Awareness:\n" +
                "  • Be suspicious of unexpected emails asking you to click links or provide personal details.\n" +
                "  • Check the sender's real email address – scammers often spoof trusted brands.\n" +
                "  • Hover over links before clicking to preview the actual URL.\n" +
                "  • Legitimate organisations will never ask for your password via email.",

            ["safe browsing"] =
                "🌐 Safe Browsing Tips:\n" +
                "  • Always check for HTTPS (padlock icon) before entering sensitive data.\n" +
                "  • Keep your browser and extensions up to date.\n" +
                "  • Avoid using public Wi-Fi for banking or sensitive transactions.\n" +
                "  • Use a reputable ad-blocker to reduce malvertising risks.",

            ["privacy"] =
                "🔒 Privacy Best Practices:\n" +
                "  • Review app permissions on your phone and revoke unnecessary access.\n" +
                "  • Limit personal information shared on social media.\n" +
                "  • Use a VPN on public networks.\n" +
                "  • Regularly review privacy settings on platforms like Facebook and Google.",

            ["malware"] =
                "🛡️ Malware Protection:\n" +
                "  • Install reputable antivirus software and keep it updated.\n" +
                "  • Never download software from untrusted sources.\n" +
                "  • Be cautious of USB drives from unknown origins.\n" +
                "  • Regularly back up your data to a secure, offline location.",

            ["ransomware"] =
                "💀 Ransomware Warning:\n" +
                "  • Ransomware encrypts your files and demands payment – prevention is key.\n" +
                "  • Keep regular offline backups so you can restore without paying.\n" +
                "  • Never open email attachments from unknown senders.\n" +
                "  • Patch your operating system and software promptly.",

            ["social engineering"] =
                "👾 Social Engineering:\n" +
                "  • Attackers manipulate people rather than systems – stay sceptical.\n" +
                "  • Verify callers' identities before sharing any information over the phone.\n" +
                "  • 'Vishing' (voice phishing) and 'smishing' (SMS phishing) are common in South Africa.\n" +
                "  • When in doubt, hang up and call the organisation back on a verified number.",

            ["scam"] =
                "⚠️ Scam Awareness:\n" +
                "  • If an offer seems too good to be true, it almost certainly is.\n" +
                "  • Never pay upfront fees to claim a prize.\n" +
                "  • Report scams to the South African Banking Risk Information Centre (SABRIC).\n" +
                "  • Share awareness with friends and family – scammers target all age groups.",

            ["two-factor"] =
                "📱 Two-Factor Authentication (2FA):\n" +
                "  • 2FA adds a second layer of protection beyond your password.\n" +
                "  • Use an authenticator app (e.g. Google Authenticator) rather than SMS where possible.\n" +
                "  • Enable 2FA on email, banking, and social media accounts first.",

            ["vpn"] =
                "🌍 VPN (Virtual Private Network):\n" +
                "  • A VPN encrypts your internet traffic, protecting it on public Wi-Fi.\n" +
                "  • Choose a reputable, no-logs VPN provider.\n" +
                "  • A VPN does not make you anonymous – practice safe browsing too.",
        };

        // ── Default / fallback responses ──────────────────────────────────────

        private readonly string[] _defaultResponses =
        {
            "I didn't quite understand that. Could you rephrase? Try asking about 'password', 'phishing', or type 'help'.",
            "Hmm, I'm not sure what you mean. Type 'help' to see what topics I can assist with.",
            "That's outside my knowledge base right now. Try asking about safe browsing, malware, or privacy.",
        };

        private int _defaultIndex = 0;

        // ── Public API ────────────────────────────────────────────────────────

        /// <summary>
        /// Returns the best response for the given user input.
        /// Uses keyword matching; falls back to default response on no match.
        /// </summary>
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "It seems like you didn't type anything. Please enter a question or topic.";

            string lower = input.ToLower();

            // Direct or partial keyword match
            foreach (var kvp in _keywordResponses)
            {
                if (lower.Contains(kvp.Key))
                    return kvp.Value;
            }

            // Rotating default response
            string fallback = _defaultResponses[_defaultIndex % _defaultResponses.Length];
            _defaultIndex++;
            return fallback;
        }

        /// <summary>Checks whether the input is a recognised exit command.</summary>
        public static bool IsExitCommand(string input)
        {
            string trimmed = input.Trim().ToLower();
            return trimmed is "exit" or "quit" or "bye" or "goodbye";
        }
    }
}
