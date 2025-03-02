using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    #region Variables

    [Export] public double speed;
    [Export] public double jumpForce;
    public Vector2 velocity;
    public AnimationPlayer animations;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        animations = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    #endregion

    #region Methods
    
    #endregion
}
