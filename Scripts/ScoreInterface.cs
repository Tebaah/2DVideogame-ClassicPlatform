using Godot;
using System;

/// <summary>
/// ScoreInterface se encarga de mostrar el puntaje y el tiempo restante en la interfaz gráfica del juego.
/// No gestiona la lógica de juego, solo actualiza los elementos visuales en respuesta a señales de otros managers.
/// </summary>
public partial class ScoreInterface : CanvasLayer
{
    #region Variables

    /// <summary>
    /// Referencia al Label que muestra el puntaje.
    /// </summary>
    private Label _scoreLabel;
    /// <summary>
    /// Referencia al Label que muestra el tiempo restante.
    /// </summary>
    private Label _timeLabel;
    private TimerManager _timerManager;

    private Button _continueButton;
    private Button _resetButton;

    private LevelManager _nextLevelManager;
    private LevelManager _resetLevelManager;
    private Label _textMessage;

    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa las referencias a los Labels y muestra el tiempo inicial antes de que comience el cronómetro.
    /// </summary>
    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("Control/Container/ScoreLabel");
        _scoreLabel.Text = "Score: 0";
        _timeLabel = GetNode<Label>("Control/Container/TimeLabel");
        _continueButton = GetNode<Button>("Control/MenuContainer/ContinueButton");
        _resetButton = GetNode<Button>("Control/MenuContainer/ResetButton");

        _nextLevelManager = (LevelManager)GetParent();
        _resetLevelManager = (LevelManager)GetParent();

        _nextLevelManager.Connect("NextLevel", new Callable(this, "OnNextLevel"));
        _resetLevelManager.Connect("ResetLevel", new Callable(this, "OnResetLevel"));

        _textMessage = GetNode<Label>("Control/MessageContainer/TextMessage");

        // Solo para mostrar el tiempo inicial antes de que empiece el cronómetro
        ShowInitialTime();
    }
    #endregion

    #region Custom Methods

    public void OnNextLevel()
    {
        _continueButton.Visible = true;
        _textMessage.Text = "Checkpoint reached!";
        _textMessage.Visible = true;
    }

    public void OnResetLevel()
    {
        _resetButton.Visible = true;
        _textMessage.Text = "Checkpoint reached! Press Reset to try again.";
        _textMessage.Visible = true;
    }

    /// <summary>
    /// Muestra el tiempo inicial en la interfaz, obteniéndolo desde TimerManager.
    /// </summary>
    void ShowInitialTime()
    {
        var timerManager = GetNode<TimerManager>("../TimerManager");
        int initialTime = timerManager.TimeToFinish;
        int m = initialTime / 60;
        int s = initialTime % 60;
        _timeLabel.Text = $"Time: {m:D2}:{s:D2}";
    }

    /// <summary>
    /// Actualiza el texto del puntaje en la interfaz.
    /// </summary>
    /// <param name="newScore">Nuevo puntaje a mostrar.</param>
    public void UpdateScore(int newScore)
    {
        _scoreLabel.Text = $"Score: {newScore}";
    }

    /// <summary>
    /// Actualiza el texto del tiempo restante en la interfaz.
    /// </summary>
    /// <param name="timeLeft">Tiempo restante en segundos.</param>
    public void UpdateTime(int timeLeft)
    {
        int m = timeLeft / 60;
        int s = timeLeft % 60;
        _timeLabel.Text = $"Time: {m:D2}:{s:D2}";
    }

    #endregion
}
