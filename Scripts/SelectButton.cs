using Godot;
using System;

public partial class SelectButton : Button
{
    #region Variables

    GameManager _gameManager;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");
    }
    #endregion

    #region custom Methods

    public void OnSelectButtonPressed()
    {
        GD.Print($"Enter on level {this.Name}");
    }

    #endregion
}
