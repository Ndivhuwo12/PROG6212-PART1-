using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting on startup
            AudioPlayer.PlayGreeting();

            // Display ASCII art header
            DisplayHelper.ShowAsciiLogo();

            // Start chatbot session
            ChatBot bot = new ChatBot();
            bot.Start();
        }
    }
}
