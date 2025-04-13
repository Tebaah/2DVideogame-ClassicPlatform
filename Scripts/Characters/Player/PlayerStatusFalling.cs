using Godot;
using System;

public partial class PlayerStatusFalling : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        
        if (player.velocity.Y >= 0 && player.IsOnFloor())
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

        player.velocity.X = (float)(Input.GetAxis("Left", "Right") * player.speed * delta);

        ApplyGravity(delta);
        player.animations.Play("Fall");
        player.Velocity = player.velocity;
        player.MoveAndSlide();
    }

    #endregion

    #region Custom Methods

    #endregion
}
