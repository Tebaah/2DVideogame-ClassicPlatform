using Godot;
using System;

public partial class EnemyController : CharacterBody2D
{
    #region Variables
    [Export] public double Speed { get; set; }
    [Export] public double JumpForce { get; set; }
    [Export(PropertyHint.Enum, "Flying,Ground")] public string EnemyType { get; set; } = "Ground";
    public float InitialPosition { get; set; }
    public float FinalPosition { get; set; }
    public float Distance { get; set; }
    public AnimatedSprite2D Sprite { get; private set; }

    private Random Random { get; } = new Random(); // Converted to a read-only property
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
        Distance = Random.Next(50, 100);
        InitialPosition = Position.X;
        FinalPosition = InitialPosition - Distance;
    }

    private void InitializeSprite()
    {
        Sprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        if (Sprite == null)
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

    public void AddVelocityX(float x)
    {
        var velocity = Velocity;
        velocity.X += x;
        Velocity = velocity;
    }

    public void RemoveVelocityX(float x)
    {
        var velocity = Velocity;
        velocity.X -= x;
        Velocity = velocity;
    }
    public void SetVelocityX(float x)
    {
        var velocity = Velocity;
        velocity.X = x;
        Velocity = velocity;
    }
    
    #endregion

    #region Signal Handlers

    private void RequestQueueFree()
    {
        QueueFree();
    }

    #endregion
}
