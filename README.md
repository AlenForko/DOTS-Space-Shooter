# DOTS Space Shooter

## About
This is a DOTS (Data-Oriented Technology Stack) Space Shooter game created in Unity. It is not a fully playable game, as it is only to show the power of DOTS.
In the final version, asteroids will spawn around the player and move towards the player. At some point, the screen will be filled with asteroids and start
destroying themselves when they collide with the player.

## Controls

- A/D or Left/Right arrow keys - Rotate ship
- Space - Shoot

## Optimization
For the optimization part of this project, I used ECS (Entity Component System) for all of my scripts - spawning, moving & shooting. If I were to have 100.000
asteroids spawned at the same time through OOP (Object oriented programming), I surely wouldn't achieve the goal of having a solid 30 FPS. This is why ECS
is extremely powerful and allowed my game to have an immense amount of "objects" spawned in the scene at the same time without the cost of performance.

![70.000 asteroids](/Images/70k.png?raw=true)

In the above example, we can see how I achieve above 60 FPS with 70.000 asteroids spawned at the same time and moving towards the center of the screen,
where the player is waiting to destroy these asteroids. 

![101.000 asteroids](/Images/101k.png?raw=true)

Here we are achieving 30+ FPS. The screen is completely full with asteroids, getting destroyed when they reach the player, and the player is shooting out bullets at the same time.
