# WargHeroes

## Installation

- Install Unity version 2017.1.1f
- clone the repository
- open it in unity

## Stages

### Stage 0

- Player character, movement
- Terrain
- Tower with collision detection

### Stage 1

- Shooting
	- Cast ray from camera in the direction of forward vector
	- If it shoots an object that implements shootable, then destroy that object

- Enemy
	- Navigation box - enemy moving around
	- Enemy is a cube
	- Enemy move around -> always move toward player

### Stage 2