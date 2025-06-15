using Godot;
using System;

public partial class EnemyObstacle : Area2D
{
    #region Variables

    [Export] public double FallSpeed { get; set; } = 100;
    [Export] public double RiseSpeed { get; set; } = 100;
    public double PositionInitialY { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; private set; }
    public CollisionShape2D CollisionShape { get; private set; }
    public AudioStreamPlayer AudioPlayer { get; private set; }
    public RayCast2D RayCast { get; private set; }
    public RayCast2D RayCastPlayer { get; private set; }
    public RayCast2D RaycastPlayer2 { get; private set; }
    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        InitializeSprite();
        InitializeCollisionShape();
        InitializeAudioPlayer();
        InitializeRayCast();
        InitializePosition();
        InitializeRayCastPlayer();
    }
    #endregion

    #region Custom Methods

    public void InitializeSprite()
    {
        AnimatedSprite = GetNodeOrNull<AnimatedSprite2D>("Sprite");
        if (AnimatedSprite == null)
        {
            GD.PrintErr("AnimatedSprite2D node not found.");
            return;
        }
    }

    public void InitializeCollisionShape()
    {
        CollisionShape = GetNodeOrNull<CollisionShape2D>("Collision");
        if (CollisionShape == null)
        {
            GD.PrintErr("CollisionShape2D node not found.");
            return;
        }
    }

    public void InitializeAudioPlayer()
    {
        AudioPlayer = GetNodeOrNull<AudioStreamPlayer>("Audio");
        if (AudioPlayer == null)
        {
            GD.PrintErr("AudioStreamPlayer node not found.");
            return;
        }
    }

    public void InitializeRayCast()
    {
        RayCast = GetNodeOrNull<RayCast2D>("RayCast");
        if (RayCast == null)
        {
            GD.PrintErr("RayCast2D node not found.");
            return;
        }
    }

    public void InitializeRayCastPlayer()
    {
        RayCastPlayer = GetNodeOrNull<RayCast2D>("RayCast2");
        if (RayCastPlayer == null)
        {
            GD.PrintErr("RayCast2 node not found.");
            return;
        }
        RaycastPlayer2 = GetNodeOrNull<RayCast2D>("RayCast3");
        if (RaycastPlayer2 == null)
        {
            GD.PrintErr("RayCast3 node not found.");
            return;
        }
    }

    public void InitializePosition()
    {
        PositionInitialY = Position.Y;
    }
    #endregion
}
