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
<<<<<<< Updated upstream
        Random random = new Random();
        distance = random.Next(100, 200);
=======
        InitializeMovementBounds();
        ConnectDeadStateSignal();
        InitializeSprite();
    }
>>>>>>> Stashed changes

    #endregion

    #region Initialization Methods

    private void InitializeMovementBounds()
    {
        distance = random.Next(50, 100);
        initialPosition = Position.X;
        finalPosition = initialPosition - distance;
<<<<<<< Updated upstream
=======
    }

    private void ConnectDeadStateSignal()
    {
        var deadState = GetNodeOrNull<EnemyStateDead>("StateMachine/StateDead");
        if (deadState != null)
        {
            deadState.Connect("RequestQueueFree", Callable.From(RequestQueueFree));
        }
        else
        {
            GD.PrintErr("EnemyStateDead node not found. Ensure the node exists in the scene.");
        }
    }

    private void InitializeSprite()
    {
        sprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        if (sprite == null)
        {
            GD.PrintErr("AnimatedSprite2D node not found. Ensure the node exists in the scene.");
        }
>>>>>>> Stashed changes
    }

    #endregion

    #region Custom Methods
    
    #endregion

    #region Signal Handlers

    private void RequestQueueFree()
    {
        QueueFree();
    }

    #endregion
}
