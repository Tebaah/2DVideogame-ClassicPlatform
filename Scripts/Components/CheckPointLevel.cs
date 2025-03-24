using Godot;
using System;

public partial class CheckPointLevel : Area2D
{
    #region Variables

    private GameManager _gameManager;
    private LevelManager _levelManager;

    #endregion

    #region  Godot Methods

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        if (_gameManager == null)
        {
            GD.PrintErr("GameManager not found in the scene tree.");
            return;
        }
        _levelManager = GetNode<LevelManager>("/root/Level1");
        if (_levelManager == null)
        {
            GD.PrintErr("LevelManager not found in the scene tree.");
            return;
        }

    }

    #endregion

    #region  Custom Methods
    
    public void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player") && _levelManager.score == _levelManager.pointsToWin)
        {
            _gameManager.MarkLevelAsCompleted(GetParent().Name);
            _gameManager.SaveProcess();
        }
    }

    #endregion
}
