# Light Up Riyadh

A 2D game made in **Unity** with **C#**. You play a small flame flying through the night. Flap to rise, fly through the gaps between water obstacles, and keep your flame alive. Pass enough obstacles and the dark Riyadh skyline lights up.

## Gameplay

- **Controls:** press `Space` to flap upward
- **Obstacles:** water obstacles move across the screen and put out the flame on contact
- **Score:** +1 for every obstacle you pass
- **Win:** reach the target score and the city background switches to a lit-up skyline with a win sound
- **Difficulty:** choose **Easy** or **Hard** from the start menu; Hard spawns obstacles faster, narrows the gaps, and changes the flap strength
- **Game over:** the flame goes out, then you can play again or return to the menu

## Scripts

| Script | What it does |
|---|---|
| [`StartMenuController.cs`](Scripts/StartMenuController.cs) | start menu and Easy/Hard selection, saved with `PlayerPrefs` |
| [`PlayerMovement.cs`](Scripts/PlayerMovement.cs) | flap physics, collision with water, game-over sequence |
| [`WaterObstacleSpawner.cs`](Scripts/WaterObstacleSpawner.cs) | spawns obstacles at random heights; rate depends on difficulty |
| [`WaterObstacleMovement.cs`](Scripts/WaterObstacleMovement.cs) | moves obstacles left and removes them off-screen |
| [`ScoreOnPass.cs`](Scripts/ScoreOnPass.cs) | adds a point when the player passes an obstacle |
| [`ScoreManager.cs`](Scripts/ScoreManager.cs) | score display and the win effect that lights up the city |
| [`GameOverButtons.cs`](Scripts/GameOverButtons.cs) | Play Again and Home buttons |

## Tech

Unity (2D, URP) · C# · TextMesh Pro · Unity Input System

## What I learned

I taught myself Unity and C# for this project: 2D physics with `Rigidbody2D`, triggers and collisions, prefabs and spawning, scene management, UI panels, audio, and saving settings with `PlayerPrefs`.
