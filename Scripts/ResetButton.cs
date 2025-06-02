using Godot;
using System;

/// <summary>
/// ResetButton gestiona la acción de reiniciar el nivel actual cuando el usuario presiona el botón.
/// Su única responsabilidad es recargar la escena correspondiente al nivel actual.
/// No gestiona lógica de juego, UI general ni otras funcionalidades ajenas al botón de reinicio.
/// </summary>
public partial class ResetButton : Button
{
    #region Variables

    private string _currentLevel;
    private string _levelName;
    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa el nombre del nivel actual al cargar el botón.
    /// </summary>
    public override void _Ready()
    {
        _currentLevel = GetTree().CurrentScene.Name;
        _levelName = _currentLevel.ToLower();
    }
    #endregion

    #region Custom Methods

    /// <summary>
    /// Método llamado al presionar el botón de reinicio.
    /// Recarga la escena del nivel actual.
    /// </summary>
    public void OnResetButtonPressed()
    {
        GetTree().ChangeSceneToFile($"res://Scenes/Level/{_levelName}.tscn");
    }
    #endregion
}
