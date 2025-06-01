using Godot;
using System;

/// <summary>
/// TimerManager gestiona el temporizador del nivel.
/// Se encarga de iniciar, actualizar y emitir una señal cada vez que el tiempo restante cambia.
/// No controla la visualización ni otras lógicas de juego.
/// </summary>
public partial class TimerManager : Node
{
    /// <summary>
    /// Tiempo total para completar el nivel (en segundos).
    /// </summary>
    [Export] public int TimeToFinish; 

    /// <summary>
    /// Referencia al nodo Timer de Godot encargado de la cuenta regresiva.
    /// </summary>
    private Timer timer;

    /// <summary>
    /// Señal emitida cada vez que el tiempo restante cambia.
    /// El parámetro es el tiempo restante en segundos.
    /// </summary>
    [Signal] public delegate void OnTimeUpdatedEventHandler(int timeLeft);

    /// <summary>
    /// Inicializa el TimerManager, conecta el evento Timeout y comienza el temporizador.
    /// </summary>
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        StartTimer();
        // Conectar el timeout del Timer a este TimerManager
        timer.Timeout += OnTimerTimeout;
    }

    /// <summary>
    /// Inicia el temporizador tras una breve espera inicial.
    /// </summary>
    public async void StartTimer()
    {
        await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
        timer.Start();
    }

    /// <summary>
    /// Método llamado cada vez que el Timer llega a cero.
    /// Disminuye el tiempo restante y emite la señal de actualización.
    /// </summary>
    public void OnTimerTimeout()
    {
        if (TimeToFinish > 0)
        {
            TimeToFinish-- ;
            EmitSignal(nameof(OnTimeUpdated), TimeToFinish);
        }
    }
}
