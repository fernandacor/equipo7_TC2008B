# **Dimensional Odyssey: The Abduction**

## _Game Design Document_

---

##### **Copyright notice / JJAFSS / boring legal stuff nobody likes**

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

Te secuestraron y te llevaron a un laboratorio, y cuando piensas que nada podría empeorar te das cuenta que todo el mundo cambió y nada es lo que parece.

### **Gameplay**

Dimensional Oddyssey un videojuego RPG de plataforma 2D que tiene por objetivo atravesar varios niveles llenos de enemigos para descubrir el secreto de quién fue la persona que te secuestró y por qué.

Debido a que hay varios poderes y armas disponibles en el juego, el jugador debe pensar en la mejor combinación entre ambas para hacer frente a sus enemigos.

### **Mindset**

~~What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?~~
Queremos que el jugador se sienta atraido por nuestras mecanicas y estilo de pelea, los cuales estan muy apegados al viaje entre dimensiones, dado que cada nivel representa un nuevo reto por el entorno en el que esta.

## _Technical_

---

### **Screens**

1. Pantalla Principal
   1. Iniciar Juego
   2. Elegeir Perfil 
   3. Opciones
2. Juego
   1. Resume del juego hasta el moemnto 
   2. Inventario
   3. Elegir "Power up" al acabar una de las dimensions
   4. Pantalla de que has Muerto
3. End credits

### **Mechanics**

**Estilo de juego**

El juego es estilo RPG y Rogue-like

**Jugabilidad principal**

- **WASD:** Movimiento del jugador hacia arriba, abajo, derecha e izquierda.
- **Mouse:** Apuntado.
- **Click izquierdo**: Disparo básico.
- **Click derecho:** Disparo especial.
- **Shift**: Dash - Movimiento rápido para esquivar los ataques enemigos - Tiene cooldown.

Referencia: [https://youtu.be/6BrZryMz-ac](https://youtu.be/6BrZryMz-ac)

**Crecimiento estilo RPG**

El crecimiento del jugador se va a dar por las estadísticas del personaje principal y del arma.

**Personaje principal**

El personaje principal va a contar con los siguientes atributos:

- Experiencia
- Vida
- Energía
- Velocidad de movimiento
- Velocidad de disparo
- Fuerza
- Resistencia
- Recuperación de energía
- Robo de vida

**Experiencia**

Son los puntos que se van a usar para determinar cuando el jugador suba de nivel. A medida que el jugador tiene más nivel, se necesitan más puntos de experiencia para subir otro nivel.

**Sistema de niveles**

Cada vez que el jugador suba de nivel automáticamente se van a mejorar todos sus atributos, pero también se le va a dar la opción al jugador de asignar un punto extra a un atributo en específico para que de esta forma el jugador pueda crear un personaje que se ajuste a su estilo de juego.

Al morir el jugador, todos sus niveles de experiencia y, por consiguiente, todos los atributos del personaje, se van a reiniciar a su estado base exceptuando por puntos globales que van a ser compartidos en todas las runs. La forma de obtener estos puntos globales va a ser a través de items que van a estar escondidos en los distintos niveles y una vez que se obtengan ya no van a estar disponibles en las siguientes runs, con esto se logra que haya un crecimiento global limitado.

**Vida**

Cuando se acaben los puntos de vida el jugador muere y se reinicia el juego. La forma de conseguir puntos de vida es a través de:

- El atributo "robo de vida"
- Pociones escondidas en los niveles

**Energía**

Los puntos de energía servirán para poder hacer los disparos especiales, los cuales utilizan los atributos de los modificadores del arma. La forma de recuperar energía es a través de:

- El atributo "recuperación de energía"
- Pociones escondidas en los niveles

**Velocidad de movimiento**

Es la velocidad con el que el personaje se va a poder mover por el mapa, además de que también sirve para disminuir el tiempo de cooldown para usar el dash.

**Velocidad de disparo**

Es la velocidad con la que se va a disparar el arma.

**Fuerza**

Es el daño que se le va a influir a los enemigos

**Resistencia**

Es la resistencia al daño de los enemigos

**Recuperación de energía**

Sirve para recuperar energía con el pasar del tiempo. Entre más recuperación de energía tenga el personaje, más energía recuperará por segundo.

**Robo de vida**

Sirve para recuperar vida cada vez que se derrote a un enemigo. La cantidad de vida que se va a obtener es un porcentaje de vida del enemigo y entre más robo de vida tenga el personaje, más grande será ese porcentaje.

**Arma principal**

El arma va a ser la misma que se elija al principio del run, pero por el mapa y de manera random derrotando enemigos se van a poder conseguir modificadores, estos sirven para mejorar los atributos del arma y agregarle funcionalidades extras.

**Armas iniciales**

Las armas que se van a poder elegir al principio de las runs son:

|   | Pistola | Escopeta | Metralleta |
| --- | --- | --- | --- |
| **Daño** | Medio | Alto | Bajo |
| **Velocidad de disparo** | Medio | Bajo | Alto |
| **Cantidad de disparos** | 1 | 3 | 1 |

**Atributos**

- Velocidad de movimiento
- Velocidad de disparo
- Fuerza
- Resistencia
- Recuperación de energía
- Robo de vida

**Funcionalidades extras**

- Multi-disparo
- Disparo doble
- Disparo trasero
- Disparo que rebote

**Reglas de los modificadores (tokens)**

El arma sólo va a poder tener 3 modificadores, así que cuando el jugador se encuentre con nuevos modificadores va a tener que decidir si agarrarlos o dejarlos y así crear una estrategia teniendo en cuenta los atributos de su personaje y de su arma.

Además de estos 3 modificadores, el personaje va a tener espacio para un modificador más, pero este no va a estar activo en el arma sino que será sólo de almacenaje. La función de esto es que cuando el jugador salga al mapa principal, puede ir a la casa del personaje y guardar este modificador, el cual va a poder dejar ahí y usar en la siguiente run para que además de los puntos globales del personaje, también pueda tener un modificador de arma desde un principio y así hacer el reinicio del juego más fácil y menos aburrido.

## _Level Design_

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Assets**

1. Edificios
   1. Casa del jugador
   2. Base Militar
   3. Laboratorio 
   4. Oxxo/Dr.Simi
2. Objects
   1. _Ambient_
      1. Arboles
      2. Dependiendo del universo en el que estas cambiara el filtro de color del escenario
      3. Edificios/Casas destruidas
      4. Carros
   2. _Interactive_
      1. Podras interactuar con cofres/cajas fuertes para recger items  
      2. Entrar a partes de los edificios 
      3. Algún NPC dependiendo de la Dimensión
3. Dimensiones
   1. Mood
      1. Cada mundo como mencionamos antes tendra la misma plantilla pero cada dimensión tiene un filtro distinto:
         1. Mundo normal
         2. Mundo colorido
         3. Mundo postapocalítico
         4. Mundo dorado

_(example)_

### **Game Flow**

<!-- 1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_ -->

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
 <!--
1. BasePhysics
   1. Jugador Base
   2. Enemigo Base
   3. Objeto Base
2. BaseObstacle
   1. Rocas Base
   2. Arboles Base
   3. Carros Base
3. BaseInteractable
   1. Cofres Base
   2. Token para subir de nivel base
   3. Recoger Mejoras Base

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

-->

- Clase del jugador
- Movimiento del jugador
- Clase de los enemigos
- Movimiento de los enemigos
- Aparición de los enemigos
- Clase de los bosses (cada uno con su respectiva clase)
- Movimiento de los bosses
- Interacción con los NPCs
- Interacción con objetos
    - Tokens
    - Armas
    - XP
- Cambios de escena

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
