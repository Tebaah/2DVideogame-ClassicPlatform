using Godot;
using System;

public partial class PlayerStatusFalling : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);

        if (player.Velocity.Y >= 0 && player.IsOnFloor())
        {
            if (Input.IsActionPressed("Left") || Input.IsActionPressed("Right"))
            {
                stateMachine.ChangeTo(PlayerStatusName.walk);
            }
            else
            {
                stateMachine.ChangeTo(PlayerStatusName.idle);
            }
        }

        player.SetVelocityX((float)(Input.GetAxis("Left", "Right") * player.Speed * delta));

        player.Animations.Play("Fall");
        player.MoveAndSlide();
    }

    #endregion

    #region Custom Methods

    #endregion
}
