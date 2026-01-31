# 🎮 Unity 3D Obstacle Game

![Unity](https://img.shields.io/badge/Unity-2021.3-blue)
![C#](https://img.shields.io/badge/C%23-Scripting-green)
![GameDev](https://img.shields.io/badge/Game%20Development-ObstacleGame-orange)

---

## 📌 Project Overview

This is a **3D obstacle avoidance game** built in **Unity** with **C# scripting**.  

The game challenges the player to navigate a **maze-like environment**, avoid obstacles, collect coins, and reach checkpoints.  

It demonstrates **basic game mechanics, player interaction, UI implementation, and physics in Unity**.

---

## 🕹️ Gameplay Features

- **Player Movement:** Smooth movement and rotation (WASD / Arrow keys)  
- **Camera:** Smooth follow using **Cinemachine**  
- **Coins:** Collectibles to increase score  
- **Checkpoints:** Player respawns at last checkpoint after hitting obstacles  
- **Lives System:** 5 lives; game over when lives reach zero  
- **Game Over & Win Screens:** Visual feedback when level ends or player fails  

---

## 📂 Project Structure

ObstacleGame/
│
├── Assets/
│ ├── Scripts/ # Player controls, UI logic, checkpoint system
│ ├── Prefabs/ # Player, coins, obstacles
│ ├── Materials/ # Textures and materials
│ ├── Scenes/ # Main game scene(s)
│ └── UI/ # Canvas, score, lives, win/game-over screens
│
├── ProjectSettings/ # Unity project configuration
└── README.md

yaml
Copy code

---

## ⚙️ Requirements

- **Unity 2021.3 LTS** (or newer)  
- **C# scripting**  
- **Cinemachine** package (for smooth camera follow)

---

## ▶️ How to Run the Game

1. **Clone the repository**
```bash
git clone https://github.com/your-username/ObstacleGame.git
Open project in Unity Hub

Open the Main Scene

Path: Assets/Scenes/Main.unity

Press Play in Unity Editor

Controls:

Move: W / A / S / D or Arrow Keys

Collect coins and avoid obstacles

Reach the end to win the game

🏆 Learning Outcomes
By completing this project, I learned:

Unity 3D scene design and physics

C# scripting for player controls, collisions, and game logic

UI design for score, lives, win/game-over messages

Implementing Cinemachine for camera management

Managing game logic like coins, checkpoints, and lives system

🚀 Future Improvements
Add multiple levels with increasing difficulty

Add sound effects and background music

Introduce enemy AI obstacles

Implement mobile controls (touch input support)

Add leaderboard and scoring system

👨‍💻 Author
Tahir Ahmad
Software Engineering Student | Unity Game Developer

📜 License
This project is for educational purposes.
You may clone, modify, or learn from this project with proper attribution.

⭐ If you enjoy the game or find it helpful, consider giving the repository a star!
