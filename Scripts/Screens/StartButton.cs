using Godot;
using System;

public partial class StartButton : Button
{
    #region Variables
    #endregion

    #region Godot Methods
    #endregion

    #region Custom Methods

    public void OnStartButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Level/level_2.tscn");
    }
    #endregion

}
