# GameProject
Proekt for C## course
This game is a recreation of the classic "Snake" where you control a snake moving across the screen. The objective is to collect food (represented by red circles) to grow, avoiding collisions with the borders or your own body.
The project uses an object-oriented structure with separation of concerns through classes and interfaces:

Program: Entry point, initializes the game
Game: Manages the main game logic and collisions
Snake: Handles the snake's behavior
Food: Generates food at random positions
Position: Represents x,y coordinates on screen
IRenderable: Interface for objects that can be drawn on screen
GameRenderer: Implements the interface to render the game

For its development, I started from a previous tutorial, adapting and expanding it with additional features such as an introduction screen, pause system, and a more structured code organization following object-oriented design principles.
The modular structure facilitates extending the game with new features and reusing components in future similar projects.
