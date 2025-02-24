using Godot;
using System;

public partial class CheckPointLevel : Area2D
{
    #region Variables

    [Export] private bool _IsActivated { get; set; }

    #endregion

    #region  Godot Methods

    #endregion

    #region  Custom Methods
    
    public void OnBodyEntered(Node2D body)
    {
        if (IsInGroup("Player") && _IsActivated == false)
        {
            GD.Print("CheckPointLevel: Activated");
            _IsActivated = true;

            GameManager _gameManager = GetNode<GameManager>("/root/GameManager");
            _gameManager.SetLevelCompleted(GetName());
        }
    }

    #endregion
}
