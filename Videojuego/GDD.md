# **Dimensional Odyssey: The Abduction**

## _Game Design Document_

---

##### **Copyright notice / JJAFSS / boring legal stuff nobody likes**

## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
   1. [Summary](#summary)
   2. [Gameplay](#gameplay)
   3. [Mindset](#mindset)
3. [Technical](#technical)
   1. [Screens](#screens)
   2. [Mechanics](#mechanics)
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

Te secuestraron y te despiertas en un laboratorio, y cuando por fin logras salir de ahí te das cuenta que todo el mundo cambió aunque pareciera que es el mismo.

### **Gameplay**

Dimensional Oddyssey un videojuego RPG y Roguelike 2D que tiene por objetivo atravesar varios niveles llenos de enemigos para descubrir el secreto de quién fue la persona que te secuestró y por qué.

Debido a que hay varias armas y modificadores para las mismas disponibles en el juego, el jugador debe pensar en la mejor estrategia para hacer frente a sus enemigos.

### **Mindset**

Queremos que el jugador se sienta atraido por nuestras mecánicas y estilo de pelea, los cuales estan muy apegados al viaje entre dimensiones, dado que cada nivel representa un nuevo reto por el entorno en el que esta.

## _Technical_

---

### **Screens**

1. Pantalla Principal
   1. Iniciar Juego
   2. Opciones
   3. Créditos
2. Juego
   1. Resumen del juego hasta el momento
   2. Inventario
   3. Elegir "Power up" al acabar una de las dimensiones
   4. Transición de dimensiones
   5. Pantalla de juego terminado
3. End credits

### **Mechanics**

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

- **Experiencia:**

  Son los puntos que se van a usar para determinar cuando el jugador suba de nivel. A medida que el jugador tiene más nivel, se necesitan más puntos de experiencia para subir otro nivel.

  - **Sistema de niveles:**

    Cada vez que el jugador suba de nivel automáticamente se van a mejorar todos sus atributos, pero también se le va a dar la opción al jugador de asignar un punto extra a un atributo en específico para que de esta forma el jugador pueda crear un personaje que se ajuste a su estilo de juego.

    Al morir el jugador, todos sus niveles de experiencia y, por consiguiente, todos los atributos del personaje, se van a reiniciar a su estado base exceptuando por puntos globales que van a ser compartidos en todas las runs. La forma de obtener estos puntos globales va a ser a través de items que van a estar escondidos en los distintos niveles y una vez que se obtengan ya no van a estar disponibles en las siguientes runs, con esto se logra que haya un crecimiento global limitado.

- **Vida:**

  Cuando se acaben los puntos de vida el jugador muere y se reinicia el juego. La forma de conseguir puntos de vida es a través de:

  - El atributo "robo de vida"
  - Pociones escondidas en los niveles

- **Energía:**

  Los puntos de energía servirán para poder hacer los disparos especiales, los cuales utilizan los atributos de los modificadores del arma. La forma de recuperar energía es a través de:

  - El atributo "recuperación de energía"
  - Pociones escondidas en los niveles

- **Velocidad de movimiento:**

  Es la velocidad con el que el personaje se va a poder mover por el mapa, además de que también sirve para disminuir el tiempo de cooldown para usar el dash.

- **Velocidad de disparo:**

  Es la velocidad con la que se va a disparar el arma.

- **Fuerza:**

  Es el daño que se le va a influir a los enemigos

- **Resistencia:**

  Es la resistencia al daño de los enemigos

- **Recuperación de energía:**

  Sirve para recuperar energía con el pasar del tiempo. Entre más recuperación de energía tenga el personaje, más energía recuperará por segundo.

- **Robo de vida:**

  Sirve para recuperar vida cada vez que se derrote a un enemigo. La cantidad de vida que se va a obtener es un porcentaje de vida del enemigo y entre más robo de vida tenga el personaje, más grande será ese porcentaje.

**Arma principal**

El arma va a ser la misma que se elija al principio del run, pero por el mapa y de manera random derrotando enemigos se van a poder conseguir modificadores, estos sirven para mejorar los atributos del arma y agregarle funcionalidades extras.

- **Armas iniciales:**

  Las armas que se van a poder elegir al principio de las runs son:

  |                          | Pistola | Escopeta | Metralleta |
  | ------------------------ | ------- | -------- | ---------- |
  | **Daño**                 | Medio   | Alto     | Bajo       |
  | **Velocidad de disparo** | Medio   | Bajo     | Alto       |
  | **Cantidad de disparos** | 1       | 3        | 1          |

- **Atributos:**

  - Velocidad de movimiento
  - Velocidad de disparo
  - Fuerza
  - Resistencia
  - Recuperación de energía
  - Robo de vida

- **Funcionalidades extras:**

  - Multi-disparo
  - Disparo doble
  - Disparo trasero
  - Disparo que rebote

- **Reglas de los modificadores (tokens):**

  El arma sólo va a poder tener 3 modificadores, así que cuando el jugador se encuentre con nuevos modificadores va a tener que decidir si agarrarlos o dejarlos y así crear una estrategia teniendo en cuenta los atributos de su personaje y de su arma.

  Además de estos 3 modificadores, el personaje va a tener espacio para un modificador más, pero este no va a estar activo en el arma sino que será sólo de almacenaje. La función de esto es que cuando el jugador salga al mapa principal, puede ir a la casa del personaje y guardar este modificador, el cual va a poder dejar ahí y usar en la siguiente run para que además de los puntos globales del personaje, también pueda tener un modificador de arma desde un principio y así hacer el reinicio del juego más fácil y menos aburrido.

## _Level Design_

### **Assets**

1. Edificios
   1. Casa del jugador
   2. Base Militar
   3. Laboratorio
   4. Oxxo
2. Objects
   1. _Ambient_
      1. Árboles
      2. Dependiendo del universo en el que estas cambiará el filtro de color del escenario
      3. Edificios
      4. Carros
   2. _Interactive_
      1. Podras interactuar con cofres/cajas fuertes para recoger items
      2. Entrar a partes de los edificios
      3. Algún NPC dependiendo de la Dimensión
3. Dimensiones
   1. Mood
      1. Cada mundo, como mencionamos antes, tendrá la misma plantilla pero cada dimensión tiene un filtro distinto:
         1. Mundo normal
         2. Mundo colorido
         3. Mundo postapocalítico
         4. Mundo dorado

## _Development_

---

### **Abstract Classes / Components**

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
