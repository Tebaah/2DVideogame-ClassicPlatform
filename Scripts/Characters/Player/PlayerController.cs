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
    private Camera2D _camera;

    private LevelManager _levelManager;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        // Initialize variables
        animations = GetNode<AnimationPlayer>("AnimationPlayer");
        audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _sprite = GetNode<Sprite2D>("Sprite2D");
        _camera = GetNode<Camera2D>("Camera2D");

        // Initialize the level manager
        _levelManager = GetParent().GetNode<LevelManager>("../LevelManager");

        _camera.LimitLeft = _levelManager.LimitLeft;
        _camera.LimitRight = _levelManager.LimitRight;
    }

    public override void _PhysicsProcess(double delta)
    {
        AnimationDirection();
    }


    #endregion

    #region Methods
    private void AnimationDirection()
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
}
