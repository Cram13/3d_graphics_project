Minecraft Dungeon
I was inspired by the mobile game Archero to develop a 3d top down shooter as well. Top down shooters or Shoot 'em ups how they are also called are are a subgenre of shooters which were most famous in arcade games such as space invaders or Asteroids or Galaxian. One common factor for such games is the fight against multiple enemies while at the same point dodging their attacks by avoiding their bullets. Which will also be a main game mechanic in my game. 


The main features are:
  Learnable skills which are reseted after resurrection
    Different shooting types like additional bullets per shoot
    Add status effects (fire, ice, poison) to the attacks
  Several different enemy types
    Melee
    Range
    Enemies with special status effects if they hit the player
  Strong boss monster with several attacks
  Basic stats which can be improved by spending the collected coins
 
Implementation Details:
  Goal was a modular approach which allows a tool box system for building new enemies. I decide to combine all basic functionalities like basic stats as Attack, Attack Speed, Movement Speed and Health points into one Character class and derive from this class the enemies and player class. These are the fundamental parts of all characters (Player and enemies). The other common traits are implemented as prefabs. These are then added as children to the gameobject with the base class. This added prefabs will then handle all parts related to the prefab and use the data of the base class. Some examples would be the attack itself, the display of status effects, dropping experience and currency

  
Run instructions:
  Download the prebuild versions for Windows(not tested) and Linux here::: and run the exe or x86_64 file to start the game
  or 
  Use the Unity3d editor
  Prerequisits: Unity3d(developed and tested with 2019.2.4f1) and Blender(2.80)
  Download this repository and open it with the Unity3d editor then hit the play button at the top
  This version allows you to manipulate all variables and modify the game as you like.
  

