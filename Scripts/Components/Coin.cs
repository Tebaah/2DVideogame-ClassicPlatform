using Godot;
using System;

/// <summary>
/// Coin representa una moneda coleccionable en el juego.
/// Su responsabilidad es detectar la colisión con el jugador, reproducir un sonido, 
/// modificar el puntaje a través de ScoreManager y eliminarse de la escena.
/// No gestiona la lógica de puntaje ni la visualización.
/// </summary>
public partial class Coin : Area2D
{
    #region Variables

    /// <summary>
    /// Multiplicador de puntaje que se aplicará al recoger la moneda.
    /// </summary>
    [Export] public float ScoreMultiplier { get; set; }

    /// <summary>
    /// Reproductor de sonido para el efecto al recoger la moneda.
    /// </summary>
    private AudioStreamPlayer2D _audio;

    /// <summary>
    /// Referencia al nodo principal del nivel para buscar ScoreManager.
    /// </summary>
    private Node _levelNode;

    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa referencias a componentes necesarios al cargar la moneda.
    /// </summary>
    public override void _Ready()
    {
        _audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _levelNode = GetTree().CurrentScene;
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// Método llamado cuando un cuerpo entra en el área de la moneda.
    /// Si el cuerpo es el jugador, multiplica el puntaje, reproduce el sonido y elimina la moneda.
    /// </summary>
    /// <param name="body">El nodo que entra en el área de la moneda.</param>
    public void OnCoinBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            var scoreManager = _levelNode.GetNodeOrNull<ScoreManager>("LevelManager/ScoreManager");
            if (scoreManager != null)
            {
                scoreManager.MultiplyScore(ScoreMultiplier);
                QueueFree();
            }
            else
            {
                GD.PrintErr("ScoreManager node not found. Cannot add score.");
            }
        }
    }

    #endregion 
}
