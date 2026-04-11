namespace CybersecurityChatbot
{
    /// <summary>
    /// Stores information about the current user session.
    /// Demonstrates the use of auto-implemented properties (Learning Unit 1).
    /// </summary>
    public class UserProfile
    {
        // Auto-implemented properties
        public string Name { get; set; } = "User";
        public int MessageCount { get; set; } = 0;

        /// <summary>Returns a formatted greeting using the stored name.</summary>
        public string GetPersonalisedGreeting()
        {
            return $"Welcome, {Name}! I'm your Cybersecurity Awareness Assistant. " +
                   "How can I help you stay safe online today?";
        }
    }
}
