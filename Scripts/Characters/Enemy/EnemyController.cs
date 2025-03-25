using Godot;
using System;

public partial class EnemyController : CharacterBody2D
{
    #region Variables
    [Export] public double speed;
    [Export] public double jumpForce;
    public float initialPosition;
    public float finalPosition;
    public float distance;
    public Vector2 velocity;
    public AnimationPlayer animations;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        Random random = new Random();
        distance = random.Next(100, 200);

        initialPosition = Position.X;
        finalPosition = initialPosition - distance;
        
        animations = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    #endregion

    #region Methods
    
    #endregion
}
