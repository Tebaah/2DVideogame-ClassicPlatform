using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    #region Variables

    [Export] public double speed;
    [Export] public double jumpForce;
    public Vector2 velocity;
    public AnimationPlayer animations;
    public AudioStreamPlayer2D audio;
    private Sprite2D _sprite;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        animations = GetNode<AnimationPlayer>("AnimationPlayer");
        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _sprite = GetNode<Sprite2D>("Sprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        if (velocity.X < 0)
        {
            _sprite.FlipH = false;
        }
        else if (velocity.X > 0)
        {
            _sprite.FlipH = true;
        }
    }

    #endregion

    #region Methods
    
    #endregion
}
