using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Plays a WAV voice greeting using the Windows winmm.dll API directly.
    /// No NuGet packages or extra assembly references required.
    /// </summary>
    public static class AudioPlayer
    {
        private const string WavFileName = "greeting.wav";

        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_SYNC     = 0x0000;
        private const uint SND_FILENAME = 0x00020000;

        public static void PlayGreeting()
        {
            try
            {
                string wavPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WavFileName);

                if (!File.Exists(wavPath))
                    wavPath = Path.Combine(Directory.GetCurrentDirectory(), WavFileName);

                if (!File.Exists(wavPath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"  [Audio] Place '{WavFileName}' in the project folder to hear the voice greeting.");
                    Console.ResetColor();
                    return;
                }

                PlaySound(wavPath, IntPtr.Zero, SND_FILENAME | SND_SYNC);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"  [Audio] Could not play greeting: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}