using Godot;
using System;

public partial class CheckPointLevel : Area2D
{
    #region Variables

    private AnimatedSprite2D _animatedSprite;
    [Signal] public delegate void OnCheckpointReachedEventHandler();

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        InitializeAnimatedSprite();
    }

    #endregion

    #region Custom Methods

    private void InitializeAnimatedSprite()
    {
        _animatedSprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        if (_animatedSprite == null)
        {
            GD.PrintErr("AnimatedSprite2D not found as a child node.");
        }
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            _animatedSprite?.Play("default");
            EmitSignal(nameof(OnCheckpointReached));
        }
    }

    #endregion
}
