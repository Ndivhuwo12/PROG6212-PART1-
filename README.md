# 🔐 Cybersecurity Awareness Chatbot — Part 1

**Module:** PROG6221 – Programming 2A  
**Assessment:** Portfolio of Evidence (POE) — Part 1  

---

## Overview

A C# console application that acts as a **Cybersecurity Awareness Assistant** for South African citizens.  
On launch it plays a voice greeting, displays an ASCII logo, asks for the user's name, and then conducts a text-based conversation about cybersecurity topics.

---

## Features (Part 1)

| # | Feature | Details |
|---|---------|---------|
| 1 | **Voice Greeting** | Plays `greeting.wav` via `System.Media.SoundPlayer` on startup |
| 2 | **ASCII Logo** | Large banner art displayed as a title screen |
| 3 | **Personalised Greeting** | Asks for the user's name; all responses use it |
| 4 | **Basic Response System** | Covers passwords, phishing, safe browsing, privacy, malware, ransomware, social engineering, scams, 2FA, VPN |
| 5 | **Input Validation** | Handles empty input, null/EOF, and unknown queries with helpful fallback messages |
| 6 | **Enhanced Console UI** | Coloured text, section headers, decorative borders, typing effect, dividers |
| 7 | **Code Structure** | Multiple classes (`ChatBot`, `ResponseEngine`, `UserProfile`, `DisplayHelper`, `AudioPlayer`) – no logic dumped in `Program.cs` |
| 8 | **GitHub CI** | GitHub Actions workflow builds the project on every push |

---

## Project Structure

```
CybersecurityChatbot/
├── Program.cs          ← Entry point (minimal – just wires up classes)
├── ChatBot.cs          ← Session orchestration (greeting, loop, farewell)
├── ResponseEngine.cs   ← Keyword matching & response dictionary
├── UserProfile.cs      ← Auto-properties for user data
├── DisplayHelper.cs    ← All console UI helpers (colours, ASCII, typing effect)
├── AudioPlayer.cs      ← WAV playback via System.Media
├── greeting.wav        ← Voice greeting (record your own – see below)
└── .github/
    └── workflows/
        └── ci.yml      ← GitHub Actions CI pipeline
```

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (Windows)
- Visual Studio 2022 **or** VS Code with C# extension

### Run from command line
```bash
cd CybersecurityChatbot
dotnet run
```

### Voice Greeting
Record a short WAV file welcoming the user, e.g.:  
*"Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."*

Save it as **`greeting.wav`** in the project root. The app will play it automatically on launch.  
If the file is absent, the app continues without audio and shows an informational message.

---

## CI Status

> Add a screenshot of the green ✅ CI badge from GitHub Actions here after your first push.

---

## Sample Conversation

```
[CyberBot]: Welcome, Alice! I'm your Cybersecurity Awareness Assistant...
[Alice]: what can I ask you about?
[CyberBot]: Great question! You can ask me about:
  🔑  Password safety
  🎣  Phishing scams
  ...
[Alice]: tell me about phishing
[CyberBot]: 🎣 Phishing Awareness:
  • Be suspicious of unexpected emails...
```

---

## Topics Supported

`password` · `phishing` · `safe browsing` · `privacy` · `malware` · `ransomware` · `social engineering` · `scam` · `two-factor` · `vpn` · `help`

---

*PROG6221 POE — Part 1 | Individual Assignment*
