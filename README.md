# Time to Hit

## Descripción

**Time to Hit** es un juego de plataformas 2D en el que el jugador debe recorrer el nivel, eliminar enemigos y alcanzar la meta dentro de un tiempo limitado. Para avanzar al siguiente nivel, es necesario cumplir con dos condiciones: llegar a la meta antes de que el tiempo se acabe y alcanzar una cantidad mínima de puntos eliminando enemigos.

## Características Principales

- Juego de plataformas 2D con vista lateral.
- Mecánica de tiempo limitado por nivel.
- Eliminación de enemigos para acumular puntaje.
- Desbloqueo progresivo de niveles.

## Mecánicas del Juego

### Jugador

- Movimiento de izquierda a derecha.
- Salto normal.
- Eliminar enemigos saltando sobre ellos.
- Potenciar el puntaje con elementos extras como monedas.
- Disminuye el puntaje al ser tocado por el enemigo.

### Enemigos

- Movimiento de izquierda a derecha.
- MOvimiento de caida libre al acercarse.
- Se eliminan cuando el jugador salta sobre ellos.
- Otorgan puntaje al ser eliminados.

### Niveles

- Cada nivel tiene un tiempo límite.
- El jugador debe eliminar enemigos para obtener puntos.
- Para avanzar, el jugador debe alcanzar la meta antes de que el tiempo se acabe y tener la cantidad mínima de puntos requerida.

## Interfaz Gráfica

- Tiempo restante.
- Puntaje actual.
- Botones de pause, continuar y reiniciar el nivel.

## Elementos del Nivel

- Plataformas estáticas y móviles.
- Coleccionables (monedas que aumentan el puntaje).
- Obstaculos (elementos que aumenta la dificulatad).

## Pantallas del Juego

- **Pantalla de Inicio**: Muestra el título y el logo del juego. Después de cierto tiempo, cambia automáticamente a la pantalla de selección de nivel.
- **Pantalla de Inicio de Nivel**: Permite iniciar el nivel.
- **Pantalla de Juego**: Contiene la jugabilidad principal.
- **Pantalla de Pausa**: Permite detener el juego principal.


## Tecnologías Utilizadas

- **Motor**: Godot 4
- **Lenguaje de programación**: C#

## Notas Técnicas

- **Jugador**: Utiliza un nodo `CharacterBody2D`, un `AnimationPlayer` para animaciones y un script en C# para gestionar movimiento y colisiones.
- **Enemigos**: Basados en `CharacterBody2D`, con movimiento simple de izquierda a derecha.
- **Interfaz**: Implementada con nodos `CanvasLayer` y `Label`.
- **Tiempo y puntaje**: Gestionados mediante un script global.

## Objetivo del Proyecto

El objetivo principal del desarrollo de este juego es mejorar la programación en C# y la implementación de mecánicas en Godot 4, priorizando la lógica del juego sobre el arte gráfico.

## Créditos

- **Assets**: Kenney https://www.kenney.nl/ 
- **Sound effects**: jsfxr https://sfxr.me/
