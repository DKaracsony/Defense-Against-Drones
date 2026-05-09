# Mars Mission

Mars Mission is a simple VR action game developed in Unity for Meta Quest.  
The player is placed on a Mars route and must survive waves of attacking drones.

## Project Overview

The game focuses on a complete VR gameplay loop:

- Main menu scene
- Introductory mission popup
- Player movement and interaction
- Drone wave spawning system
- Drone attacks and player health
- Win and lose conditions
- Result scene with restart and main menu options

## Gameplay

The player starts in the menu scene and can begin the mission through a VR-interactable UI.

After entering the game scene, a mission briefing is displayed. Once the player continues, movement is enabled and drone waves begin.

The objective is to survive the incoming drone waves.

If the player survives all waves, the mission is completed.  
If the player health reaches zero, the mission fails and the reached wave is displayed.

## Features

- VR player setup with XR Interaction Toolkit
- Scene-based game flow
- Drone spawning system with waves
- Drone health and destruction logic
- Player damage and death handling
- Win/lose result handling
- Mars-themed sci-fi UI
- Polished menu, intro, and result screens
- Git workflow using main, develop, and feature branches

## Scenes

The project uses three main scenes:

- MenuScene
- GameScene
- ResultScene

Scene flow:

MenuScene -> GameScene -> ResultScene

From the result scene, the player can restart the game or return to the main menu.

## Technologies Used

- Unity
- C#
- XR Interaction Toolkit
- TextMeshPro
- Meta Quest 3 testing
- Git
- GitHub

## Controls

The game is designed for VR interaction using Meta Quest controllers.

Main interactions include:

- Ray interaction with UI buttons
- Player movement
- VR camera movement
- Gameplay interaction systems

## Development Workflow

The project was developed using a branch-based Git workflow:

- main      - stable final version
- develop   - active development version
- feature/* - individual feature branches

Feature branches were created from `develop`, merged back into `develop`, and finally `develop` was used to update `main`.

## Final Status

The project is complete and ready for demonstration purposes.

Final implemented state includes:

- Working menu scene
- Working gameplay scene
- Working result scene
- Drone wave gameplay loop
- Player damage and result logic
- Polished UI