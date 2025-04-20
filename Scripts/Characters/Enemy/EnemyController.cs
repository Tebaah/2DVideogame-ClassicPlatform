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

    private Random random = new Random(); // Moved to a class-level variable to avoid creating multiple instances
    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        distance = random.Next(100, 200); // Reuse the class-level Random instance

        initialPosition = Position.X;
        finalPosition = initialPosition - distance;

        sprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");

        if (sprite == null)
        {
            GD.PrintErr("AnimatedSprite2D node not found. Ensure the node exists in the scene.");
        }
    }

    #endregion

    #region Methods
    
    #endregion
}
