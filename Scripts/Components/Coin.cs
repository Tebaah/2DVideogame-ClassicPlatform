using Godot;
using System;
using System.Security.Principal;

public partial class Coin : Area2D
{
    #region Variables

    private AudioStreamPlayer2D _audio;
    [Export] private int _pointCoin;
    #endregion

    #region Godot Methods
    
    public override void _Ready()
    {
        _audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    #endregion

    #region Custom Methods

    public void OnCoinBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            GetTree().Root.GetNode<LevelManager>("Level1").AddScore(_pointCoin);
            GD.Print("Coin collected!"); // TODO incorporate into score system and audio
            QueueFree();
        }
    }

    #endregion 
}
