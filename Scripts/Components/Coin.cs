using Godot;
using System;
using System.Security.Principal;

public partial class Coin : Area2D
{
    #region Variables

    [Export] public float ScoreMultiplier { get; set; }
    private AudioStreamPlayer2D _audio;
    private Node _levelNode;
    #endregion

    #region Godot Methods
    
    public override void _Ready()
    {
        _audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _levelNode = GetTree().CurrentScene;
    }

    #endregion

    #region Custom Methods

    public void OnCoinBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            var levelManager = _levelNode.GetNodeOrNull<LevelManager>("LevelManager");
            if (levelManager != null)
            {
                levelManager.AddScore(_pointCoin);
                GD.Print("Coin collected!");
                QueueFree();
            }
            else
            {
                GD.PrintErr("LevelManager node not found. Cannot add score.");
            }
        }
    }

    #endregion 
}
