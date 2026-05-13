# Barrel Rush

A recreation of the original Donkey Kong arcade game (Nintendo, 1981), built from scratch in Unity 6. This is not an original game. Every character, mechanic, and level layout comes from the 1981 arcade version. I made it to learn 2D physics, sprite animation, and scene management in Unity.

![Level 1](Screenshot/Screenshot_1.png)

## How it plays

You control Mario. Donkey Kong sits at the top of the screen throwing barrels down at you. Your job is to climb up the platforms and reach the princess without getting hit.

Barrels roll down the tilted platforms and bounce when they hit an edge. You can climb ladders to move between floors, or jump over barrels if you time it right.

| Input | Action |
|-------|--------|
| Arrow keys / WASD | Move left and right |
| Space | Jump |
| Up / Down | Climb ladders |

You start with 3 lives. Getting hit by a barrel costs one. Reaching the princess adds 1000 points and loads the next level. Lose all 3 lives and the game restarts from Level 1.

## Screenshots

| Level 1 | Level 2 |
|---------|---------|
| ![Level 1](Screenshot/Screenshot_1.png) | ![Level 2](Screenshot/Screenshot_3.png) |

## Project structure

```
Assets/
  Scripts/
    Player.cs        -- movement, jumping, climbing, sprite animation
    Barrel.cs        -- barrel physics and collision response
    Spawner.cs       -- spawns barrels at random intervals
    GameManager.cs   -- lives, score, scene loading (singleton)
  Scenes/
    Preload.unity    -- entry point, initializes GameManager
    Level 1.unity    -- first stage (white platforms)
    Level 2.unity    -- second stage (gold platforms, more barrels)
  Prefabs/
    Mario, DonkeyKong, Princess, Barrel, Platform, Ladder
  Sprites/
    Pixel art for all characters and objects
```

The codebase is small on purpose. Four scripts, three scenes, six prefabs. The `GameManager` uses a singleton pattern with `DontDestroyOnLoad` so it persists across scene transitions. The `Spawner` creates barrels at random intervals between 2 and 4 seconds. Barrels get an impulse force when they land on a platform, which makes them roll along the slope.

Player collision detection uses `OverlapBoxNonAlloc` to check for ground and ladder contacts every frame. The ground check compares Y positions to figure out if Mario is standing on a platform or passing through one from below.

## Built with

- Unity 6.4 (6000.4.4f1)
- Universal Render Pipeline (URP) 2D
- C# with Unity's Input Manager

## Running locally

1. Clone this repo
2. Open it in Unity Hub (requires Unity 6.4 or compatible)
3. Open `Assets/Scenes/Preload.unity`
4. Press Play

The game starts from the Preload scene, which initializes the GameManager and loads Level 1 automatically.

## Legal

This project is a fan recreation made for educational purposes. Donkey Kong, Mario, and all related characters are property of Nintendo. No commercial use intended.
