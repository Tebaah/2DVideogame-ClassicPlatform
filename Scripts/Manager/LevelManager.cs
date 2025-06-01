using Godot;
using System;
using System.Threading.Tasks;

/// <summary>
/// LevelManager coordina la lógica principal de un nivel en el juego.
/// Su responsabilidad es orquestar y conectar los distintos managers (puntaje, tiempo, checkpoint) y responder a eventos globales del nivel.
/// No implementa lógica interna de puntaje, tiempo ni UI, solo delega y coordina.
/// </summary>
public partial class LevelManager : Node
{
    #region Variables

    /// <summary>
    /// Puntaje necesario para ganar el nivel.
    /// </summary>
    [Export] public int PointsToWin;
    /// <summary>
    /// Puntaje actual del jugador (actualizado por la señal de ScoreManager).
    /// </summary>
    public int score;
    /// <summary>
    /// Límite izquierdo del nivel.
    /// </summary>
    [Export] public int LimitLeft;
    /// <summary>
    /// Límite derecho del nivel.
    /// </summary>
    [Export] public int LimitRight;
    /// <summary>
    /// Referencia al ScoreManager, encargado de la lógica de puntaje.
    /// </summary>
    private ScoreManager scoreManager;
    /// <summary>
    /// Referencia al TimerManager, encargado de la lógica de tiempo.
    /// </summary>
    private TimerManager timerManager;
    /// <summary>
    /// Referencia al checkpoint del nivel.
    /// </summary>
    private CheckPointLevel _checkPointLevel;

    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa referencias, conecta señales y prepara la UI al iniciar el nivel.
    /// </summary>
    public override void _Ready()
    {
        var gui = GetNode<ScoreInterface>("CanvasLayer");
        scoreManager = GetNode<ScoreManager>("ScoreManager");
        timerManager = GetNode<TimerManager>("TimerManager");
        _checkPointLevel = GetNode<CheckPointLevel>("CheckPointLevel");
        scoreManager.ConnectScoreUpdatedToUI(gui, "UpdateScore");
        scoreManager.ConnectScoreUpdatedToUI(this, "OnScoreUpdated");
        timerManager.Connect("OnTimeUpdated", new Callable(gui, "UpdateTime"));
        _checkPointLevel.Connect("OnCheckpointReached", new Callable(this, "OnCheckpointReached"));
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// Lógica a ejecutar cuando se alcanza un checkpoint.
    /// Valida si el puntaje es suficiente para avanzar.
    /// </summary>
    public void OnCheckpointReached()
    {
        if (score >= PointsToWin)
        {
            GD.Print("Checkpoint reached with score: " + score);
            // TODO: Implementar lógica para manejar el checkpoint alcanzado, como guardar el estado del juego o avanzar al siguiente nivel.
        }
        else
        {
            GD.Print("Checkpoint reached, but score is not enough: " + score);
            // TODO: Implementar lógica para manejar el checkpoint alcanzado, como reiniciar el nivel por no alcanzar el puntaje necesario.
        }
    }

    /// <summary>
    /// Método para manejar la señal de actualización de puntaje.
    /// Actualiza la variable local para reflejar el puntaje real del ScoreManager.
    /// </summary>
    /// <param name="score">Nuevo puntaje.</param>
    public void OnScoreUpdated(int score)
    {
        this.score = score;
    }

    /// <summary>
    /// Método para manejar la señal de actualización de tiempo (puede usarse para lógica adicional).
    /// </summary>
    /// <param name="timeLeft">Tiempo restante.</param>
    public void OnTimeUpdated(int timeLeft)
    {
        // Actualiza la UI o lógica relacionada con el tiempo si es necesario
    }

    #endregion
}
