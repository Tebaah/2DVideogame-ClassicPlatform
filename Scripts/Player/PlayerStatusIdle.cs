using Godot;
using System;

public partial class PlayerStatusIdle : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        player.velocity.X = 0;
        ApplyGravity(delta);
        player.Velocity = player.velocity;
        player.MoveAndSlide();

        player.animations.Play("Idle");
    }
    public override void OnInput(InputEvent @event)
    {
        if (Input.IsActionPressed("Left") || Input.IsActionPressed("Right"))
        {
            stateMachine.ChangeTo("StateWalk");
        }
        else if (Input.IsActionJustPressed("Jump"))
        {
            stateMachine.ChangeTo("StateJump");
        }
    }
    #endregion  

    #region Methods 

    #endregion
}
