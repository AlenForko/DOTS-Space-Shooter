# DOTS Space Shooter

## About
This is a DOTS (Data-Oriented Technology Stack) Space Shooter game created in Unity. It is not a fully playable game, as it is only to show the power of DOTS.
In the final version, asteroids will spawn around the player and move towards the player. At some point, the screen will be filled with asteroids and start
destroying themselves when they collide with the player.

## Controls

- A/D or Left/Right arrow keys - Rotate ship
- Space - Shoot
- 1 - restart/start ECS Game
- 2 - restart/start OOP Game
- Q - Quit game

## Optimization

### ECS
For the optimization part of this project, I used ECS (Entity Component System) for all of my scripts - spawning, moving & shooting. If I were to have 100.000
asteroids spawned at the same time through OOP (Object oriented programming), I surely wouldn't achieve the goal of having a solid 30 FPS. This is why ECS
is extremely powerful and allowed my game to have an immense amount of "objects" spawned in the scene at the same time without the cost of performance.

![JobsProfiling](/Images/JobsAsteroidSpawnerSystem.png?raw=true)

Here we can notice that even though we are spawning 1.000 entities at once, it doesn't affect performance as much as it would normally. With 31ms in only one frame, 
I call that a win. Furthermore, we can see that the AsteroidMovement script runs at 0.09ms which is just incredible.

![70.000 asteroids](/Images/70k.png?raw=true)

In the above example, we can see how I achieve above 60 FPS with 70.000 asteroids spawned at the same time and moving towards the center of the screen,
where the player is waiting to destroy these asteroids. 

![101.000 asteroids](/Images/101k.png?raw=true)

Here we are achieving 30+ FPS. The screen is completely full with asteroids, getting destroyed when they reach the player, and the player is shooting out bullets at the same time.

### OOP

I tried making the game using simple OOB programming, and the results are really terrible. The performance completely drops after 6.000 game objects spawned and starting to collide
with the player at the same time. I didn't add bullet collision, as I didn't see a point of attempting even to see the performance difference with bullets involved as well.

While profiling the OOP version of the game, we can notice a significant difference compared to ECS. With a whopping 216.17ms for just the Asteroid Movement script is just terrible
performance overall. Not to mention the physics update with 1350ms and growing with each tick, we can notice how much more powerful ECS is.

![OOPProfiler](/Images/MonoProfiler.png?raw=true)

![101.000 asteroids](/Images/6k.png?raw=true)

### Computer Test Stats

The screenshots taken are on a pretty decent computer, so you may not get the same exact performance as I do.

- CPU 11th Gen Intel Core i5-11600k @ 3.90 GHz
- GPU NVIDIA GeForce RTX 3060
