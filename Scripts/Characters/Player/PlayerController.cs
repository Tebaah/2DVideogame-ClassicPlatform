using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    #region Variables

    [Export] public double Speed { get; set; }
    [Export] public double JumpForce { get; set; }
    public AnimationPlayer Animations { get; set; }
    public AudioStreamPlayer2D Audio { get; set; }
    private Sprite2D _sprite;
    private Camera2D _camera;

    private LevelManager _levelManager;

    public bool JumpByEnemy { get; set; } = false;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        // Initialize variables
        Animations = ComponentInitializer.GetComponent<AnimationPlayer>(this, "AnimationPlayer");
        Audio = ComponentInitializer.GetComponent<AudioStreamPlayer2D>(this, "AudioStreamPlayer2D");
        _sprite = ComponentInitializer.GetComponent<Sprite2D>(this, "Sprite2D");
        _camera = ComponentInitializer.GetComponent<Camera2D>(this, "Camera2D");

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

    #region Custom Methods
    private void AnimationDirection()
    {
        if (Velocity.X < 0)
        {
            _sprite.FlipH = false;
        }
        else if (Velocity.X > 0)
        {
            _sprite.FlipH = true;
        }
    }

    public void AddVelocityY(float y)
    {
        var velocity = Velocity;
        velocity.Y += y;
        Velocity = velocity;
    }

    public void SetVelocityY(float y)
    {
        var velocity = Velocity;
        velocity.Y = y;
        Velocity = velocity;
    }

    public void SetVelocityX(float x)
    {
        var velocity = Velocity;
        velocity.X = x;
        Velocity = velocity;
    }

    #endregion
}
