# 🎮 FreakFall

<div align="center">

![Unity](https://img.shields.io/badge/Unity-2019+-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Android-green?style=for-the-badge&logo=android)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

**A fast-paced falling arcade game where quick reflexes mean survival**

[Report Bug](https://github.com/AkshayKappala/FreakFall/issues) • [Request Feature](https://github.com/AkshayKappala/FreakFall/issues)

</div>

---

## 📖 About

FreakFall is an addictive mobile arcade game where players must tap colored tiles while falling at increasing speeds.  The game challenges your reflexes and decision-making as you navigate through three types of tiles - tap the wrong one and it's game over!  With multiple themes, power-ups, and Google Play leaderboard integration, FreakFall offers endless replayability.

### 🎯 Why FreakFall? 

FreakFall combines simple tap mechanics with progressively challenging gameplay that keeps players engaged. The game features a polished monetization system with rewarded video ads, in-game currency economy, and theme customization options.

---

## ✨ Features

- 🎨 **Multiple Themes**:  Three distinct visual themes (Classic, Suit Boot, Tribal) with unlock progression
- 🎮 **Color-Based Gameplay**: Three tile types (Red, Green, Blue) with unique interactions
- ⚡ **Power System**:  Boost mechanics and gift drops for strategic gameplay
- 🏆 **Google Play Services**: Leaderboard integration for competitive scoring
- 💰 **In-Game Economy**:  Coin system with 50-coin gifts and theme purchases
- 📺 **Monetization**:  Appodeal ad integration (Interstitial, Banner, Rewarded Video)
- 🔊 **Audio Management**: Complete sound system with mute/unmute functionality
- 📱 **Tutorial System**: First-time player guidance
- ⏸️ **Pause/Resume**: Full game state management with countdown resume
- 💾 **Save System**: PlayerPrefs-based persistent data storage

---

## 🛠️ Tech Stack

### Core
- **Engine**: Unity (C#)
- **Platform**: Android
- **Scripting**: C# (. NET)

### SDKs & Services
- **Google Play Games Services**: Authentication and leaderboards
- **Appodeal**:  Ad mediation platform
- **Simple Android Notifications**: Push notification support
- **Apxor Unity**:  Analytics integration

### Key Systems
- **UI Framework**: Unity UI (Canvas-based)
- **Audio**: Unity AudioSource management
- **Physics**: Unity Collider system for tile interactions
- **Animation**: Unity Animator for UI transitions

---

## 🚀 Quick Start

### Prerequisites

```bash
Unity 2019.4+ (LTS recommended)
Android SDK (API Level 21+)
JDK 8 or higher
```

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/AkshayKappala/FreakFall. git
cd FreakFall
```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Add" and select the cloned project folder
   - Open with Unity 2019.4 or later

3. **Configure Google Play Services**
   - Update `Assets/GPGSIds.cs` with your leaderboard IDs: 
```csharp
public static class GPGSIds
{
    public const string leaderboard_high_socre = "YOUR_LEADERBOARD_ID";
}
```

4. **Configure Appodeal**
   - Open `Assets/Scripts/AppodealManager.cs`
   - Replace the app key with your Appodeal credentials:
```csharp
string appKey = "YOUR_APPODEAL_KEY";
Appodeal.initialize(appKey, Appodeal. INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO);
```

5. **Build Settings**
   - Go to `File > Build Settings`
   - Switch platform to Android
   - Configure Player Settings (Company Name, Package Name, etc.)

6. **Build and Run**
```bash
File > Build Settings > Build or Build And Run
```

---

## 📁 Project Structure

```
Assets/
├── Scenes/                      # Unity scenes
│   ├── MainMenu.unity          # Main menu with theme selection
│   └── GamePlay.unity          # Core gameplay scene
├── Scripts/                     # C# gameplay scripts
│   ├── GameController. cs       # Main menu controller
│   ├── GamePlayController. cs   # Gameplay initialization
│   ├── UIManager.cs            # UI state management
│   ├── BasicTileScript. cs      # Tile interaction logic
│   ├── TileSpawner.cs          # Procedural tile generation
│   ├── TileType.cs             # Tile enum definitions
│   ├── AppodealManager.cs      # Ad integration
│   └── GroundScript.cs         # Game over detection
├── Sprites/                     # 2D artwork and UI elements
├── Audio/                       # Sound effects and music
├── Animations/                  # UI animation controllers
├── Resources/                   # Dynamically loaded prefabs
├── GooglePlayGames/            # GPGS plugin
└── Appodeal/                   # Appodeal SDK
```

---

## 🎨 Customization Guide

### Adding a New Theme

1. **Create Theme Assets**
   - Add sprites to `Assets/Sprites/`
   - Create prefabs in `Assets/Resources/` with naming convention: `{ThemeNumber}RescueCharGreen`

2. **Update GameController**
```csharp
public void Theme4()
{
    theme = 4;
    SaveTheme(4);
    Double_click_play(4);
}
```

3. **Update GamePlayController**
```csharp
case 4: GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = BG4; break;
```

### Modifying Tile Behavior

Edit `Assets/Scripts/BasicTileScript.cs`:

```csharp
private void OnMouseDown()
{
    if (Tiletype == TileType.Green)
    {
        // Green tile logic - safe tile
        greenfunction();
    }
    else if (Tiletype == TileType.Blue)
    {
        // Blue tile logic - bonus tile
        bluefunction2();
    }
    else if (Tiletype == TileType.Red)
    {
        // Red tile logic - game over
        UIManager.Instance.ShowGameOverMenu();
        Destroy(this.gameObject);
    }
}
```

### Adjusting Game Difficulty

Modify spawn rates in `Assets/Scripts/TileSpawner.cs` and falling speed in `BasicTileScript.cs`:

```csharp
public static float StartVelocity = 0.25f; // Increase for harder gameplay
```

---

## 🎯 Gameplay Mechanics

### Tile Types
- **🟢 Green Tiles**: Safe tiles - tap to progress and score points
- **🔵 Blue Tiles**: Bonus tiles - tap for special rewards
- **🔴 Red Tiles**:  Danger tiles - tapping causes instant game over

### Scoring System
- Each successful tile tap increases your score
- Difficulty increases as `TileSpeed` increments
- Speed affects tile falling velocity:  `StartVelocity + (TileSpeed * 0.01f)`

### Economy
- **Starting Coins**: 300 (first-time players)
- **Gift Drops**: +50 coins per parachute gift
- **Revive Cost**: 200 coins
- **Ad Rewards**:  200 coins per rewarded video

### Theme Unlocking
Themes unlock when `PlayerPrefs.GetInt("isUnlocked") == 5`

---

## 📱 Build & Deployment

### Android Build

1. **Configure Player Settings**
```
File > Build Settings > Player Settings
- Company Name: FreakSpace
- Product Name: FreakFall
- Package Name: com.FreakSpace.FreakFall
- Minimum API Level: Android 5.0 (API Level 21)
```

2. **Keystore Setup**
```
Player Settings > Publishing Settings
- Create New Keystore or use existing
- Configure alias and passwords
```

3. **Build**
```bash
File > Build Settings > Build
```

4. **Test on Device**
```bash
adb install FreakFall.apk
```

### Performance Optimization

- **Target Frame Rate**: Set in GamePlayController
- **Audio Optimization**:  Sound pool management in `AppodealManager`
- **Memory Management**: Destroy tiles beyond screen bounds

---

## 🐛 Troubleshooting

### Google Play Services Not Working
- Verify your app is signed with the correct SHA-1 fingerprint
- Check `GPGSIds.cs` contains correct leaderboard IDs
- Ensure Google Play Services plugin is properly installed

### Ads Not Displaying
```csharp
// Check Appodeal initialization
Appodeal.setTesting(true); // Enable test mode
```
- Verify Appodeal app key is correct
- Check network connectivity
- Review ad frequency settings in `AppodealManager`

### Build Errors
- Clean build folder:  `Edit > Preferences > External Tools > Clean`
- Reimport all assets: `Assets > Reimport All`
- Check for conflicting plugin versions

### Audio Issues
```csharp
// Verify sound preference
Debug.Log(PlayerPrefs.GetInt("Soundpref")); // 1 = On, 0 = Off
```

---

## 🤝 Contributing

Contributions are welcome! Feel free to:
- 🐛 Report bugs
- 💡 Suggest new features
- 🔧 Submit pull requests

---

## 📄 License

This project is available for educational and portfolio purposes. 

---

## 👨‍💻 Contact

**Developer**: Akshay Kappala

- GitHub:  [@AkshayKappala](https://github.com/AkshayKappala)
- Repository: [FreakFall](https://github.com/AkshayKappala/FreakFall)

---

<div align="center">

**Made with ❤️ using Unity**

*If you enjoy FreakFall, give it a ⭐ on GitHub!*

</div>
