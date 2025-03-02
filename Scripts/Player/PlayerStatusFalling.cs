using Godot;
using System;

public partial class PlayerStatusFalling : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        if (player.velocity.Y > 0 && player.IsOnFloor())
        {
            if (Input.IsActionJustPressed("Left") || Input.IsActionJustPressed("Right"))
            {
                stateMachine.ChangeTo("StateWalk");
            }
            else
            {
                stateMachine.ChangeTo("StateIdle");
            }
        }

        ApplyGravity(delta);
        player.Velocity = player.velocity;
        player.MoveAndSlide();
    }

    #endregion

    #region Custom Methods

    #endregion
}
