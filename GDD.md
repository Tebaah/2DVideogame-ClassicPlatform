# Game Design Document (GDD) – [Nombre del Juego]

1. **Resumen del Juego**
    - **Género**: Plataforma 2D, inspirado en Mario Bros.
    - **Plataforma**: Godot 4 utilizando C#.
    - **Visión General**:
      El jugador controla un personaje que se desplaza por niveles repletos de plataformas (estáticas y móviles), evitando enemigos y recolectando monedas para aumentar el puntaje. El objetivo es llegar al final del nivel, superando obstáculos y enemigos mediante el salto.

2. **Mecánicas de Juego**
    - **Personaje Principal**
      - **Movimiento**:
         - Se desplaza de izquierda a derecha.
         - Salto normal (único, sin doble salto en esta versión inicial).
      - **Implementación Técnica**:
         - Nodo principal: `CharacterBody2D`
         - Componentes: `Sprite2D`, `CollisionShape2D`, `AnimationPlayer`
         - Script (C#): Control del movimiento (modificando `Velocity.x` y `Velocity.y`), aplicación de gravedad y verificación de colisiones (usando `IsOnFloor()`).

    - **Enemigos**
      - **Movimiento**:
         - Patrón de movimiento simple de izquierda a derecha.
      - **Interacción con el Jugador**:
         - Son eliminados al saltar sobre ellos.
      - **Implementación Técnica**:
         - Nodo principal: `CharacterBody2D`
         - Componentes: `Sprite2D`, `CollisionShape2D`
         - Script (C#): Gestión del movimiento automático, detección de colisiones y cambio de dirección en límites, detección de "golpe" del jugador (puede utilizar un `Area2D` para detectar el impacto del salto).

    - **Elementos del Nivel**
      - **Plataformas**
         - **Plataformas Estáticas**:
            - Fijas en el entorno.
            - Nodo: `StaticBody2D` con `Sprite2D` y `CollisionShape2D`.
         - **Plataformas Móviles**:
            - Se mueven entre dos puntos definidos.
            - Nodo: `Node2D` conteniendo un `StaticBody2D`.
            - Movimiento: Se implementa con `Tween` o mediante lógica en `_Process()`.

      - **Coleccionables (Monedas)**
         - **Funcionalidad**:
            - Al recolectar, aumentan el puntaje del jugador.
         - **Implementación Técnica**:
            - Nodo principal: `Area2D`
            - Componentes: `Sprite2D`, `CollisionShape2D`, `AnimationPlayer`
            - Script (C#): Detecta la colisión con el jugador y actualiza el puntaje, además de gestionar la animación y desaparición de la moneda.

3. **Interfaces y Pantallas**
    - **Pantalla de Inicio**
      - **Contenido**:
         - Título y logo del juego.
      - **Transición**:
         - Automática a la pantalla de selección tras un temporizador.
      - **Implementación Técnica**:
         - Nodo principal: `Control`
         - Componentes: `Label` (título), `TextureRect` (logo) y `Timer` para la transición.

    - **Pantalla de Selección de Nivel**
      - **Características**:
         - Sistema de desbloqueo progresivo (3 niveles disponibles).
      - **Implementación Técnica**:
         - Nodo principal: `Control`
         - Componentes:
            - `Button` para cada nivel.
            - `Label` para mostrar estado (desbloqueado/bloqueado).
         - Script (C#): Control de desbloqueo y selección de niveles según progreso.

    - **Interfaz Gráfica (HUD)**
      - **Elementos a mostrar**:
         - Tiempo transcurrido.
         - Puntaje acumulado.
         - Vidas restantes.
      - **Implementación Técnica**:
         - Nodo principal: `CanvasLayer`
         - Componentes:
            - Múltiples `Label` para cada dato.
            - (Opcional) `TextureProgressBar` para alguna representación visual del progreso.
         - Script (C#): Actualización en tiempo real de los datos.

    - **Pantalla de Pausa**
      - **Opciones**:
         - Reanudar el juego.
         - Salir del juego (o volver al menú principal).
      - **Implementación Técnica**:
         - Nodo principal: `Control`
         - Componentes:
            - `Panel` para el fondo.
            - `Button` para cada acción (reanudar, salir).
         - Script (C#): Gestión de la pausa y reanudación del juego.

    - **Pantalla de Game Over**
      - **Funcionalidad**:
         - Mostrar mensaje de “Game Over”.
         - Opción para reiniciar el juego.
      - **Implementación Técnica**:
         - Nodo principal: `Control`
         - Componentes:
            - `Label` para el mensaje.
            - `Button` para reiniciar.
         - Script (C#): Reinicia el nivel y resetea los parámetros del juego.

4. **Cronograma de Desarrollo Detallado**
    - **Semana 1-2: Movimiento del Personaje y Cámara**
      - **Tareas**:
         - Configurar el nodo `CharacterBody2D` para el personaje.
         - Implementar el movimiento de izquierda a derecha en el script C#.
         - Programar la mecánica de salto y la aplicación de gravedad.
         - Configurar la cámara (`Camera2D`) para seguir al personaje.

    - **Semana 3-4: Enemigos y Pantallas Iniciales**
      - **Enemigos**:
         - Crear la clase de enemigos basada en `CharacterBody2D`.
         - Programar el movimiento automático y la detección de colisiones para eliminar al enemigo al ser saltado.
      - **Pantalla de Inicio y Selección**:
         - Diseñar la pantalla de inicio usando `Control`, `Label`, `TextureRect` y `Timer`.
         - Crear la pantalla de selección con botones y sistema de desbloqueo progresivo.

    - **Semana 5-6: Elementos del Nivel, Coleccionables y HUD**
      - **Plataformas**:
         - Implementar plataformas estáticas (`StaticBody2D`) y móviles (con `Tween` o lógica en `_Process()`).
      - **Monedas**:
         - Crear coleccionables con `Area2D`, configurar colisiones y actualizar puntaje al ser recogidas.
      - **HUD**:
         - Desarrollar la interfaz en `CanvasLayer` para mostrar tiempo, puntaje y vidas.

    - **Semana 7-8: Pantallas de Pausa y Game Over**
      - **Pantalla de Pausa**:
         - Implementar una pantalla de pausa con `Control`, `Panel` y botones (reanudar y salir).
         - Programar la lógica para detener y reanudar el juego.
      - **Pantalla de Game Over**:
         - Crear la pantalla de game over con un mensaje y botón para reiniciar el juego.

    - **Semana 9-10: Pulido, Optimización y Pruebas**
      - **Optimización**:
         - Revisar y corregir errores en colisiones y mecánicas de movimiento.
         - Optimizar la física y el rendimiento general.
      - **Ajustes de Jugabilidad**:
         - Balancear la velocidad de enemigos y la dificultad de niveles.
         - Añadir efectos sonoros básicos si es necesario.
      - **Pruebas Finales**:
         - Testear cada nivel y pantalla para asegurar una experiencia coherente y fluida.

5. **Notas Técnicas y Herramientas**
    - **Motor**: Godot 4
    - **Lenguaje de Programación**: C#
    - **Estilo Visual**: Figuras básicas y abstractas para centrar el desarrollo en la programación y mecánicas.
    - **Control de Versiones**: Se recomienda utilizar Git para gestionar el desarrollo y las actualizaciones del juego.

6. **Consideraciones Adicionales**
    - Revisar la documentación oficial de Godot 4 para aprovechar las nuevas funcionalidades del motor en la versión C#.
    - Planificar iteraciones de prueba para cada módulo (personaje, enemigos, HUD) para identificar y solucionar problemas de jugabilidad.
    - Si en el futuro se desea ampliar el juego, considerar la implementación de power-ups y mecánicas adicionales.
