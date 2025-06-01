using Godot;
using System;

/// <summary>
/// Paused gestiona la visualización y el control del estado de pausa del juego.
/// Su responsabilidad es mostrar/ocultar la interfaz de pausa y alternar el estado de pausa global cuando se presiona la tecla correspondiente.
/// No gestiona la lógica de entrada ni otras funcionalidades ajenas a la pausa.
/// </summary>
public partial class Paused : CanvasLayer
{
    #region Variables
    private ColorRect _colorRect;
    private Button _pauseButton;

    #endregion
    public override void _Ready()
    {
        _colorRect = GetNode<ColorRect>("ColorRect");
        _pauseButton = GetNode<Button>("PauseButton");
    }
    public override void _Process(double delta)
    {
        GamePaused();
    }

    /// <summary>
    /// Alterna la visibilidad de la interfaz de pausa y el estado de pausa global
    /// cuando se detecta la acción de pausa.
    /// </summary>
    public void GamePaused()
	{
        if (Input.IsActionJustPressed("Pause"))
        {
            _pauseButton.Visible = !_pauseButton.Visible;
            GetTree().Paused = !GetTree().Paused;
            _colorRect.Visible = !_colorRect.Visible;
		}

	}
}
