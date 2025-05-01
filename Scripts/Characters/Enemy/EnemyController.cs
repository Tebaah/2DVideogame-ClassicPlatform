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
        InitializeMovementBounds();
        InitializeSprite();
        ConnectDeadStateSignal();
    }

    #endregion

    #region Initialization Methods

    private void InitializeMovementBounds()
    {
        distance = random.Next(100, 200);
        initialPosition = Position.X;
        finalPosition = initialPosition - distance;
    }

    private void InitializeSprite()
    {
        sprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        if (sprite == null)
        {
            GD.PrintErr("AnimatedSprite2D node not found. Ensure the node exists in the scene.");
        }
    }

    private void ConnectDeadStateSignal()
    {
        var stateMachine = GetNodeOrNull<Node>("StateMachine");
        if (stateMachine != null)
        {
            var deadState = stateMachine.GetNodeOrNull<Node>("StateDead");
            if (deadState != null)
            {
                deadState.Connect("RequestQueueFree", Callable.From(RequestQueueFree));
            }
            else
            {
                GD.PrintErr("StateDead node not found in StateMachine.");
            }
        }
        else
        {
            GD.PrintErr("StateMachine node not found.");
        }
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
