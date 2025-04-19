using Godot;
using System;

public partial class EnemyController : CharacterBody2D
{
    #region Variables
    [Export] public double speed;
    [Export] public double jumpForce;
    [Export(PropertyHint.Enum, "Flying,Ground")] public string enemyType = "Ground";
    public float initialPosition;
    public float finalPosition;
    public float distance;
    public Vector2 velocity;
    public AnimatedSprite2D sprite;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        Random random = new Random();
        distance = random.Next(100, 200);

        initialPosition = Position.X;
        finalPosition = initialPosition - distance;
    }

    #endregion

    #region Methods
    
    #endregion
}
