using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public static class DisplayHelper
    {
        private static readonly int Width = 70;

        // ── Core colour writers ───────────────────────────────────────────────

        public static void WriteColour(string text, ConsoleColor colour, bool newLine = true)
        {
            Console.ForegroundColor = colour;
            if (newLine) Console.WriteLine(text);
            else Console.Write(text);
            Console.ResetColor();
        }

        public static void TypeWrite(string text, ConsoleColor colour = ConsoleColor.White, int delayMs = 15)
        {
            Console.ForegroundColor = colour;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // ── Box drawing ───────────────────────────────────────────────────────

        public static void DrawBox(string[] lines, ConsoleColor borderColour, ConsoleColor textColour)
        {
            string top    = "╔" + new string('═', Width - 2) + "╗";
            string bottom = "╚" + new string('═', Width - 2) + "╝";
            string empty  = "║" + new string(' ', Width - 2) + "║";

            WriteColour(top, borderColour);
            WriteColour(empty, borderColour);
            foreach (string line in lines)
            {
                int padding = Width - 2 - line.Length;
                int left    = padding / 2;
                int right   = padding - left;
                Console.ForegroundColor = borderColour;
                Console.Write("║");
                Console.ForegroundColor = textColour;
                Console.Write(new string(' ', left) + line + new string(' ', right));
                Console.ForegroundColor = borderColour;
                Console.WriteLine("║");
                Console.ResetColor();
            }
            WriteColour(empty, borderColour);
            WriteColour(bottom, borderColour);
        }

        public static void DrawThinBox(string[] lines, ConsoleColor borderColour, ConsoleColor textColour)
        {
            string top    = "┌" + new string('─', Width - 2) + "┐";
            string bottom = "└" + new string('─', Width - 2) + "┘";
            string empty  = "│" + new string(' ', Width - 2) + "│";

            WriteColour(top, borderColour);
            WriteColour(empty, borderColour);
            foreach (string line in lines)
            {
                Console.ForegroundColor = borderColour;
                Console.Write("│ ");
                Console.ForegroundColor = textColour;
                Console.Write(line.PadRight(Width - 4));
                Console.ForegroundColor = borderColour;
                Console.WriteLine(" │");
                Console.ResetColor();
            }
            WriteColour(empty, borderColour);
            WriteColour(bottom, borderColour);
        }

        // ── Dividers ──────────────────────────────────────────────────────────

        public static void Divider(ConsoleColor colour = ConsoleColor.DarkCyan)
            => WriteColour("  " + new string('─', Width - 4), colour);

        public static void BlankLine() => Console.WriteLine();

        // ── ASCII Logo ────────────────────────────────────────────────────────

        public static void ShowAsciiLogo()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            BlankLine();
Console.ForegroundColor = ConsoleColor.Cyan;

Console.WriteLine(@"███╗   ███╗ █████╗ ████████╗██╗██╗     ██████╗  █████╗ ");
Console.WriteLine(@"████╗ ████║██╔══██╗╚══██╔══╝██║██║     ██╔══██╗██╔══██╗");
Console.WriteLine(@"██╔████╔██║███████║   ██║   ██║██║     ██║  ██║███████║");
Console.WriteLine(@"██║╚██╔╝██║██╔══██║   ██║   ██║██║     ██║  ██║██╔══██║");
Console.WriteLine(@"██║ ╚═╝ ██║██║  ██║   ██║   ██║███████╗██████╔╝██║  ██║");
Console.WriteLine(@"╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚══════╝╚═════╝ ╚═╝  ╚═╝");

Console.ResetColor();
BlankLine();

            DrawBox(new[]
            {
                "🔐  CYBERSECURITY AWARENESS ASSISTANT  🔐",
                "",
                "Protecting South African Citizens Online",
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━",
                "v1.0  |  PROG6221  |  Department of Cybersecurity"
            }, ConsoleColor.DarkCyan, ConsoleColor.White);

            BlankLine();
        }

        // ── Section headers ───────────────────────────────────────────────────

        public static void SectionHeader(string title, ConsoleColor colour = ConsoleColor.Cyan)
        {
            BlankLine();
            string bar   = new string('═', Width - 4);
            string label = $"  ╡ {title.ToUpper()} ╞";
            WriteColour("  ╔" + bar + "╗", colour);
            WriteColour(label, colour);
            WriteColour("  ╚" + bar + "╝", colour);
            BlankLine();
        }

        // ── Chat bubble style output ──────────────────────────────────────────

        public static void BotSay(string message, ConsoleColor colour = ConsoleColor.White)
        {
            BlankLine();
            WriteColour("  ┌─[ 🤖 Matilda ]" + new string('─', Width - 20) + "┐", ConsoleColor.DarkCyan);

            // Word-wrap long messages inside the box
            foreach (string line in WrapText(message, Width - 6))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  │  ");
                Console.ResetColor();
                TypeWrite(line, colour, 12);
            }

            WriteColour("  └" + new string('─', Width - 4) + "┘", ConsoleColor.DarkCyan);
        }

        public static void BotSayInstant(string message, ConsoleColor colour = ConsoleColor.White)
        {
            BlankLine();
            WriteColour("  ┌─[ 🤖 Matilda ]" + new string('─', Width - 20) + "┐", ConsoleColor.DarkCyan);
            foreach (string line in WrapText(message, Width - 6))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  │  ");
                WriteColour(line, colour, false);
                Console.WriteLine();
            }
            WriteColour("  └" + new string('─', Width - 4) + "┘", ConsoleColor.DarkCyan);
        }

        public static void ShowUserPrompt(string userName)
        {
            BlankLine();
            WriteColour($"  ┌─[ 👤 {userName} ]", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  └▶ ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // ── Status / info messages ────────────────────────────────────────────

        public static void InfoLine(string icon, string label, string value,
                                    ConsoleColor labelColour = ConsoleColor.DarkCyan,
                                    ConsoleColor valueColour = ConsoleColor.White)
        {
            Console.Write($"  {icon} ");
            WriteColour(label, labelColour, false);
            WriteColour($" {value}", valueColour);
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static string[] WrapText(string text, int maxWidth)
        {
            var lines  = new System.Collections.Generic.List<string>();
            string[] paragraphs = text.Split('\n');

            foreach (string para in paragraphs)
            {
                if (para.Length <= maxWidth)
                {
                    lines.Add(para);
                    continue;
                }
                string[] words   = para.Split(' ');
                string   current = "";
                foreach (string word in words)
                {
                    if ((current + " " + word).TrimStart().Length > maxWidth)
                    {
                        if (current.Length > 0) lines.Add(current);
                        current = word;
                    }
                    else
                    {
                        current = (current + " " + word).TrimStart();
                    }
                }
                if (current.Length > 0) lines.Add(current);
            }
            return lines.ToArray();
        }
    }
}
