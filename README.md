## Resumen del Proyecto

Este proyecto es un juego de plataformas 2D inspirado en Mario Bros, desarrollado en Godot 4 utilizando C#. El jugador controla un personaje que se desplaza lateralmente y salta para evitar enemigos y recolectar monedas, con el objetivo de llegar al final de cada nivel. El juego cuenta con:

### Pantalla de inicio y selección de niveles

Se muestra un título y logo que transiciona automáticamente a un menú de selección, donde se desbloquean progresivamente tres niveles.

### Mecánicas de juego

- **Personaje principal**: Movimiento lateral y salto, implementado con `CharacterBody2D`, `Sprite2D`, `CollisionShape2D` y `AnimationPlayer`.
- **Enemigos**: Patrón de movimiento simple (izquierda a derecha) que se elimina al ser saltado.

### Elementos del entorno

- **Plataformas**: Estáticas y móviles para la construcción de niveles.
- **Coleccionables (monedas)**: Aumentan el puntaje al ser recolectados.

### Interfaz gráfica (HUD)

Visualización del tiempo, puntaje y vidas.

### Pantallas adicionales

- **Pantalla de pausa**: Con opciones para reanudar o salir.
- **Pantalla de game over**: Reinicia el juego.

El desarrollo se guía por un cronograma detallado que abarca desde la implementación de las mecánicas básicas hasta la optimización final y pruebas, asegurando una experiencia de juego coherente y pulida. Este proyecto utiliza figuras básicas y abstractas para centrarse en la programación y las mecánicas, dejando la posibilidad de ampliar el aspecto visual en futuras iteraciones.
