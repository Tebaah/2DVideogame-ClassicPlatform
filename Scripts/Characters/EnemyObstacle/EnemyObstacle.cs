using Godot;
using System;

/// <summary>
/// EnemyObstacle se encarga únicamente de inicializar y exponer referencias a sus componentes (sprite, colisión, audio, raycasts, posición inicial).
/// No implementa lógica de movimiento, animación ni reacciones: toda esa lógica debe ser gestionada por la máquina de estados o componentes externos.
/// Utiliza ComponentInitializer para centralizar la inicialización de componentes.
/// </summary>
public partial class EnemyObstacle : Area2D
{
    #region Variables

    [Export] public double FallSpeed { get; set; } = 100;
    [Export] public double RiseSpeed { get; set; } = 100;
    /// <summary>
    /// Posición Y inicial del obstáculo.
    /// </summary>
    public double PositionInitialY { get; set; }
    /// <summary>
    /// Referencia al sprite animado del obstáculo.
    /// </summary>
    public AnimatedSprite2D AnimatedSprite { get; private set; }
    /// <summary>
    /// Referencia a la colisión del obstáculo.
    /// </summary>
    public CollisionShape2D CollisionShape { get; private set; }
    /// <summary>
    /// Referencia al reproductor de audio del obstáculo.
    /// </summary>
    public AudioStreamPlayer AudioPlayer { get; private set; }
    /// <summary>
    /// Referencia al RayCast principal.
    /// </summary>
    public RayCast2D RayCast { get; private set; }
    /// <summary>
    /// Referencias a RayCasts adicionales para detectar al jugador.
    /// </summary>
    public RayCast2D RayCastPlayer { get; private set; }
    public RayCast2D RaycastPlayer2 { get; private set; }

    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa las referencias a los componentes del obstáculo usando ComponentInitializer.
    /// </summary>
    public override void _Ready()
    {
        AnimatedSprite = ComponentInitializer.GetComponent<AnimatedSprite2D>(this, "Sprite");
        CollisionShape = ComponentInitializer.GetComponent<CollisionShape2D>(this, "Collision");
        AudioPlayer = ComponentInitializer.GetComponent<AudioStreamPlayer>(this, "Audio");
        RayCast = ComponentInitializer.GetComponent<RayCast2D>(this, "RayCast");
        RayCastPlayer = ComponentInitializer.GetComponent<RayCast2D>(this, "RayCast2");
        RaycastPlayer2 = ComponentInitializer.GetComponent<RayCast2D>(this, "RayCast3");
        PositionInitialY = Position.Y;
    }

    #endregion
}
