using Godot;
using System;

public partial class StartButton : Button
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        GrabFocus();
    }

    #endregion

    #region Custom Methods

    public void OnStartButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Level/level_1.tscn");
    }
    #endregion

}
