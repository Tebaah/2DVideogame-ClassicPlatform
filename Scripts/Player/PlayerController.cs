using Godot;
using System;

public partial class PlayerController : Node
{
    #region Variables

    public AnimationPlayer animations;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        animations = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    #endregion

    #region Methods
    
    #endregion
}
