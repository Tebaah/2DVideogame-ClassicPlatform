using Godot;
using System;

public partial class PlayerStatusJumping : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        if (player.IsOnFloor() && player.velocity.Y > 0)
        {
            player.velocity.Y = (float)(-player.jumpForce * delta);
        }


        player.animations.Play("Jump");
        ApplyGravity(delta);
        player.Velocity = player.velocity;
        player.MoveAndSlide();
  
        if (player.velocity.Y > 0)
        {
            stateMachine.ChangeTo(PlayerStatusName.fall);
        }
    }

    #endregion

    #region Methods

    #endregion
}
