# Game Design Document (GDD) – Time to Hit

## 1. Resumen del Juego

**Género:** Plataforma 2D con elementos de acción y contrarreloj.  
**Plataforma:** Desarrollado en Godot 4 utilizando C#.

### Visión General

"Time to Hit" es un juego de plataformas 2D donde el jugador debe completar cada nivel en un tiempo limitado, eliminando la mayor cantidad de enemigos posible para acumular el puntaje necesario y avanzar al siguiente nivel.

Cada nivel presenta:

- **Tiempo límite:** Un cronómetro cuenta los segundos disponibles.
- **Puntaje objetivo:** Se deben eliminar suficientes enemigos para alcanzar la puntuación mínima.

Si el jugador no cumple ambas condiciones, deberá repetir el nivel.

## 2. Mecánicas de Juego

### 2.1. Personaje Principal

**Movimiento:**

- Desplazamiento lateral (izquierda y derecha).
- Salto estándar.

**Interacción con el entorno:**

- Puede pisar plataformas estáticas y móviles.
- Eliminación de enemigos al saltar sobre ellos.
- Puede obtener coleccionables al colisionar con ellos.

**Implementación Técnica:**

- **Nodo principal:** CharacterBody2D.
- **Componentes:** Sprite2D, CollisionShape2D, AnimationPlayer, StateMachine.
- **Script (C#):** Manejo de movimiento, gravedad, colisiones y mecánicas de ataque.

### 2.2. Enemigos

**Movimiento:**

- Patrón de movimiento de izquierda a derecha.

**Interacción con el Jugador:**

- Son eliminados al ser golpeados por el jugador.
- Otorgan puntos al ser eliminados.

**Implementación Técnica:**

- **Nodo principal:** CharacterBody2D.
- **Componentes:** Sprite2D, CollisionShape2D, StateMachine.
- **Script (C#):** Movimiento automático, detección de colisiones y asignación de puntos.

### 2.3. Sistema de Puntaje y Tiempo

**Tiempo Limitado:**

- Cada nivel tiene un tiempo específico para ser completado.

**Puntaje Necesario:**

- Se debe alcanzar un puntaje mínimo eliminando enemigos.

**Implementación Técnica:**

- **Nodo principal:** Timer para gestionar el tiempo del nivel.
- **Script (C#):** Control del temporizador, actualización del puntaje y verificación de condiciones para completar el nivel.

## 3. Interfaces y Pantallas

### 3.1. Pantalla de Inicio

**Contenido:**

- Título y logo del juego "Time to Hit".

**Transición:**

- Automática a la pantalla de selección de nivel después de unos segundos.

**Implementación Técnica:**

- **Nodo principal:** Control.
- **Componentes:** Label (título), TextureRect (logo), Timer para la transición.

### 3.2. Pantalla de Selección de Nivel

**Características:**

- Desbloqueo progresivo de niveles.
- Muestra el puntaje requerido y el tiempo disponible para cada nivel.

**Implementación Técnica:**

- **Nodo principal:** Control.
- **Componentes:** Button para cada nivel, Label para información de puntaje y tiempo.
- **Script (C#):** Gestión del desbloqueo de niveles y navegación.

### 3.3. Interfaz Gráfica (HUD)

**Elementos a mostrar:**

- Temporizador del nivel.
- Puntaje actual.
- Vidas restantes.

**Implementación Técnica:**

- **Nodo principal:** CanvasLayer.
- **Componentes:** Label para cada elemento.
- **Script (C#):** Actualización en tiempo real de la información mostrada.

### 3.4. Pantalla de Pausa

**Opciones:**

- Reanudar juego.
- Salir al menú principal.

**Implementación Técnica:**

- **Nodo principal:** Control.
- **Componentes:** Panel de fondo, Button para cada opción.
- **Script (C#):** Control de pausa y navegación de menús.

### 3.5. Pantalla de Game Over

**Funcionalidad:**

- Mostrar mensaje de "Game Over".
- Opción para reiniciar el nivel o regresar al menú principal.

**Implementación Técnica:**

- **Nodo principal:** Control.
- **Componentes:** Label para el mensaje, Button para opciones.
- **Script (C#):** Reinicio del nivel y gestión de navegación.

## 4. Notas Técnicas y Herramientas

- **Motor de desarrollo:** Godot 4.
- **Lenguaje de programación:** C#.
- **Formato de sprites y assets:** Figuras abstractas para priorizar mecánicas.

**Herramientas adicionales:**

- Editor de código: Visual Studio Code o JetBrains Rider.
- Control de versiones: Git y GitHub.

## 5. Consideraciones Finales

- **Dificultad progresiva:** Cada nivel será más desafiante en cuanto a tiempo disponible y cantidad de enemigos.
- **Posible expansión:** Incorporar más tipos de enemigos y power-ups.
- **Testing:** Se realizarán pruebas en cada fase del desarrollo para asegurar estabilidad y jugabilidad.
