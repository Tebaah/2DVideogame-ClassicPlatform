using Godot;
using System;

public partial class CheckPointLevel : Area2D
{
    #region Variables

    private GameManager _gameManager;
    private LevelManager _levelManager;
    private AnimatedSprite2D _animatedSprite;
    private Node _levelNode;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        InitializeGameManager();
        InitializeLevelManager();
        InitializeAnimatedSprite();

  

    }

    #endregion

    #region Custom Methods

    private void InitializeGameManager()
    {
        _gameManager = GetNodeOrNull<GameManager>("/root/GameManager");
        if (_gameManager == null)
        {
            GD.PrintErr("GameManager not found in the scene tree.");
        }
    }

    private void InitializeLevelManager()
    {
        _levelNode = GetTree().CurrentScene;
        
        _levelManager = _levelNode.GetNodeOrNull<LevelManager>("LevelManager");
        if (_levelManager == null)
        {
            GD.PrintErr($"LevelManager not found at path: {_levelManager.GetPath()}");
        }
    }

    private void InitializeAnimatedSprite()
    {
        _animatedSprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        if (_animatedSprite == null)
        {
            GD.PrintErr("AnimatedSprite2D not found as a child node.");
        }
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player") && _levelManager != null && _levelManager.score >= _levelManager.pointsToWin)
        {
            _animatedSprite?.Play("default");
            _gameManager?.MarkLevelAsCompleted(GetParent().Name);
            _gameManager?.SaveProcess();
        }
    }

    #endregion
}
