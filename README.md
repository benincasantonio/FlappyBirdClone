# FlappyBird Clone

A Unity-based clone of the classic FlappyBird game, built with modern Unity features and clean C# architecture.

## 🎮 Game Overview

This is a faithful recreation of the popular FlappyBird mobile game. The player controls a bird that must navigate through a series of pipes by tapping/clicking to make the bird flap its wings and avoid obstacles.

## 🚀 Features

- **Simple Controls**: One-button gameplay - tap or click to make the bird flap
- **Endless Gameplay**: Procedurally generated pipe obstacles
- **Score System**: Track your high score as you progress
- **Clean UI**: Interface with score display

## 🛠️ Technical Details

### Built With
- **Unity Engine** - Game development platform
- **C#** - Programming language

### Key Components

- **GameManager**: Singleton pattern implementation for game state management
- **UIManager**: Handles UI updates and score display using Singleton pattern
- **BirdController**: Manages bird physics, input handling, and animations
- **PipeManager**: Spawns and manages pipe obstacles
- **ScoreTrigger**: Detects when player successfully passes through pipes

## 🎯 How to Play

1. **Start**: Launch the game and press any key to begin
2. **Control**: Click or tap to make the bird flap its wings
3. **Objective**: Navigate through the gaps between pipes
4. **Scoring**: Earn points by successfully passing through pipe gaps
5. **Challenge**: Avoid hitting pipes or the ground

## 🚀 Getting Started

### Prerequisites
- Unity 6 or later
- Basic understanding of Unity development (for modifications)

### Running the Project
1. Clone or download this repository
2. Open the project in Unity
3. Load the `Game.unity` scene from `Assets/Scenes/`
4. Press the Play button in Unity Editor

### Building the Game
1. Go to File → Build Settings
2. Add the Game scene to the build
3. Select your target platform
4. Click "Build" to create the executable

## 🙏 Special Thanks

### Audio Assets
- **coin2.wav** by **The-Sacha-Rush**  
  Source: https://freesound.org/s/336903/  
  License: Creative Commons 0


## 📞 Contact

If you have questions or suggestions about this project, feel free to reach out!

---

*Enjoy playing FlappyBird Clone! 🐦*
