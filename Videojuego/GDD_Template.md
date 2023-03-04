# **Dimensional Odyssey: The Abduction**

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

##

## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
   1. [Summary](#summary)
   2. [Gameplay](#gameplay)
   3. [Mindset](#mindset)
3. [Technical](#technical)
   1. [Screens](#screens)
   2. [Controls](#controls)
   3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
   1. [Themes](#themes)
      1. Ambience
      2. Objects
         1. Ambient
         2. Interactive
      3. Challenges
   2. [Game Flow](#game-flow)
5. [Development](#development)
   1. [Abstract Classes](#abstract-classes--components)
   2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
   1. [Style Attributes](#style-attributes)
   2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
   1. [Style Attributes](#style-attributes-1)
   2. [Sounds Needed](#sounds-needed)
   3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

~~Sum up your game idea in 2 sentences. A kind of elevator pitch. Keep it simple!~~

Te secuestraron y te llevaron a un laboratorio, y cuando piensas que nada podría empeorar te das cuenta que todo el mundo cambió y nada es lo que parece.

### **Gameplay**

~~What should the gameplay be like? What is the goal of the game, and what kind of obstacles are in the way? What tactics should the player use to overcome them?~~

Es un videojuego RPG de plataformas 2D que tiene por objetivo atravesar varios niveles llenos de enemigos para descubrir el secreto de quién fue la persona que te secuestró y por qué.

Debido a que hay varios poderes y armas disponibles en el juego, el jugador debe pensar en la mejor combinación entre ambas para hacer frente a sus enemigos.

### **Mindset**

~~What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?~~
Queremos que el jugador se sienta atraido por nuestras mecanicas y estilo de pelea, los cuales estan muy apegados al viaje entre dimensiones. Como cada nivel representa un nuevo reto por el entorno en el que esta.

## _Technical_

---

### **Screens**

1. Title Screen
   1. Profile
   2. Options
2. Game
   1. Story explanation
   2. Inventory
   3. Entering a new dimension
   4. Losing all your life
3. End credits

### **Controls**

~~How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)~~

Utilizaremos el arreglo de teclado clásico de WASD o con flechas para el movimiento del jugador; esto incluira moverse en cuatro direcciones: arriba, abajo, derecho, izquierda. 

### **Mechanics**

~~Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.~~
Nuestras mecánicas basicas incluyen un sistema de elementos como la electricidad, agua, fuego, etc. que te daran ventaja sobre ciertos enemigos o te haran vulnerable a otros. Además de que dependiendo de cada dimension/nivel cambiaran ciertas leyes de la fisíca a las cuales el jugador tendra que adaptarse. Al principio tienes la opción de elegir entre tres pócimas, y la que elijas te dará un poder distinto.

## _Level Design_

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
   1. Mood
      1. Dark, calm, foreboding
2. Objects
   1. _Ambient_
      1. Fireflies
      2. Beams of moonlight
      3. Tall grass
   2. _Interactive_
      1. Wolves
      2. Goblins
      3. Rocks
3. Castle
   1. Mood
      1. Dangerous, tense, active
   2. Objects
      1. _Ambient_
         1. Rodents
         2. Torches
         3. Suits of armor
      2. _Interactive_
         1. Guards
         2. Giant rats
         3. Chests

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

 **Explicación de la historia: Sueño**
   Mientras te despiertas, ves entre pestañazos fragmentos muy vagos, tipo _flashes_, de lo que te sucedió pero no lo suficiente para entender bien lo que está pasando. La visión parece un sueño, y el sueño termina contigo cayendote en algo que asemeja un hoyo negro. 

2. **Nivel inicial: Laboratorio**
   Abres los ojos y empiezas en un laboratorio. Te despiertas de golpe, mareado y confundido. Un señor te dice "Bienvenido de regreso doctor." Te das cuenta de que estas amarrado y necesitas picar _enter_ muchas veces para destruir la cuerda. Pierdes HP al hacer esto. Tan pronto como te desamarras, enfrentas tu primera pelea con el doctor. Una vez que lo vences, se abre un cofre donde se te presentan 3 pócimas en tubos de ensayo de las cuales tienes que elegir una, y cada una te otorgará un poder diferente. 

   El objetivo de este nivel es escapar sin que te atrapen los monitos en bata y vencer al doctor principal. Una vez que logres esto, el doctor suelta la llave de la puerta y puedes salir.

3. **Primer nivel: Colores naturales**
   Sales del laboratorio para descubrir que no estás en tu casa; no estás en tu ciudad.

4. **Segundo nivel**

5. **Último nivel**

## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
   1. BasePlayer
   2. BaseEnemy
   3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_

### **Derived Classes / Component Compositions**

1. BasePlayer
   1. PlayerMain
   2. PlayerUnlockable
2. BaseEnemy
   1. EnemyWolf
   2. EnemyGoblin
   3. EnemyGuard (may drop key)
   4. EnemyGiantRat
   5. EnemyPrisoner
3. BaseObject
   1. ObjectRock (pick-up-able, throwable)
   2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
   3. ObjectGoldCoin (cha-ching!)
   4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
   1. ObstacleWindow (destroyed with rock)
   2. ObstacleWall
   3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
   1. InteractableButton

_(example)_

## _Graphics_

---

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
   1. Human-like
      1. Goblin (idle, walking, throwing)
      2. Guard (idle, walking, stabbing)
      3. Prisoner (walking, running)
   2. Other
      1. Wolf (idle, walking, running)
      2. Giant Rat (idle, scurrying)
2. Blocks
   1. Dirt
   2. Dirt/Grass
   3. Stone Block
   4. Stone Bricks
   5. Tiled Floor
   6. Weathered Stone Block
   7. Weathered Stone Bricks
3. Ambient
   1. Tall Grass
   2. Rodent (idle, scurrying)
   3. Torch
   4. Armored Suit
   5. Chains (matching Weathered Stone Bricks)
   6. Blood stains (matching Weathered Stone Bricks)
4. Other
   1. Chest
   2. Door (matching Stone Bricks)
   3. Gate
   4. Button (matching Weathered Stone Bricks)

_(example)_

## _Sounds/Music_

---

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

### **Sounds Needed**

1. Effects
   1. Soft Footsteps (dirt floor)
   2. Sharper Footsteps (stone floor)
   3. Soft Landing (low vertical velocity)
   4. Hard Landing (high vertical velocity)
   5. Glass Breaking
   6. Chest Opening
   7. Door Opening
2. Feedback
   1. Relieved &quot;Ahhhh!&quot; (health)
   2. Shocked &quot;Ooomph!&quot; (attacked)
   3. Happy chime (extra life)
   4. Sad chime (died)

_(example)_

### **Music Needed**

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

_(example)_

## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
   1. base entity
      1. base player
      2. base enemy
      3. base block
2. base app state
   1. game world
   2. menu world
3. develop player and basic block classes
   1. physics / collisions
4. find some smooth controls/physics
5. develop other derived classes
   1. blocks
      1. moving
      2. falling
      3. breaking
      4. cloud
   2. enemies
      1. soldier
      2. rat
      3. etc.
6. design levels
   1. introduce motion/jumping
   2. introduce throwing
   3. mind the pacing, let the player play between lessons
7. design sounds
8. design music

_(example)_
