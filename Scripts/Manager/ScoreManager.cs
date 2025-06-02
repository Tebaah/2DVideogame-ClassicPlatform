using Godot;

/// <summary>
/// ScoreManager gestiona exclusivamente el puntaje del jugador en el juego.
/// Permite sumar, restar y multiplicar puntos, y emite una señal cada vez que el puntaje cambia.
/// No se encarga de la visualización ni de otras lógicas de juego.
/// </summary>
public partial class ScoreManager : Node
{
    /// <summary>
    /// Puntaje actual del jugador. Solo puede ser modificado por los métodos de esta clase.
    /// </summary>
    public int Score { get; private set; }

    /// <summary>
    /// Señal emitida cada vez que el puntaje cambia.
    /// El parámetro es el nuevo puntaje.
    /// </summary>
    [Signal] public delegate void OnScoreUpdatedEventHandler(int score);

    /// <summary>
    /// Suma puntos al puntaje actual y emite la señal de actualización.
    /// </summary>
    /// <param name="points">Cantidad de puntos a sumar.</param>
    public void AddScore(int points)
    {
        Score += points;
        EmitSignal(nameof(OnScoreUpdated), Score);
    }

    /// <summary>
    /// Resta puntos al puntaje actual y emite la señal de actualización.
    /// </summary>
    /// <param name="points">Cantidad de puntos a restar.</param>
    public void DiscountScore(int points)
    {
        Score -= points;
        EmitSignal(nameof(OnScoreUpdated), Score);
    }

    /// <summary>
    /// Multiplica el puntaje actual por un factor y emite la señal de actualización.
    /// </summary>
    /// <param name="multiplier">Factor por el que se multiplica el puntaje.</param>
    public void MultiplyScore(float multiplier)
    {
        Score = (int)(Score * multiplier);
        EmitSignal(nameof(OnScoreUpdated), Score);
    }

    /// <summary>
    /// Conecta la señal de actualización de puntaje a un método de la interfaz de usuario.
    /// </summary>
    /// <param name="target">Nodo objetivo (por ejemplo, la UI).</param>
    /// <param name="methodName">Nombre del método a llamar cuando el puntaje cambie.</param>
    public void ConnectScoreUpdatedToUI(Node target, string methodName)
    {
        Connect("OnScoreUpdated", new Callable(target, methodName));
    }
}
