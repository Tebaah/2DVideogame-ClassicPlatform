using Godot;
using System;

public partial class Coin : Area2D
{
    #region Variables

    private AudioStreamPlayer2D _audio;
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
            GD.Print("Coin collected!"); // TODO incorporate into score system and audio
            QueueFree();
        }
    }

    #endregion 
}
