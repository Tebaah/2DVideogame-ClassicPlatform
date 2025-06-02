using Godot;
using System;

/// <summary>
/// ContinueButton gestiona la acción de avanzar al siguiente nivel cuando el usuario presiona el botón.
/// Calcula el nombre del siguiente nivel en base al nombre de la escena actual y realiza la transición de escena.
/// No gestiona lógica de juego ni otras funcionalidades ajenas al botón de continuar.
/// </summary>
public partial class ContinueButton : Button
{
    #region Variables
    private string _currentLevel;
    private string _levelName;
    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa el nombre del nivel actual y calcula el nombre del siguiente nivel al cargar el botón.
    /// </summary>
    public override void _Ready()
    {
        _currentLevel = GetTree().CurrentScene.Name;
        _levelName = _currentLevel.ToLower();

        char lastCharacter = _levelName[^1];
        int newCharacter = int.Parse(lastCharacter.ToString()) + 1;
        _levelName = _levelName.Replace(lastCharacter, newCharacter.ToString()[0]);
        GD.Print(_levelName);
    }
    #endregion

    #region Custom Methods

    /// <summary>
    /// Método llamado al presionar el botón de continuar.
    /// Cambia la escena al siguiente nivel calculado.
    /// </summary>
    public void OnContinueButtonPressed()
    {
        GetTree().ChangeSceneToFile($"res://Scenes/Level/{_levelName}.tscn");
    }
    #endregion
}
