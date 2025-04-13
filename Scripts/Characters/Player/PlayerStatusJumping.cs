using Godot;
using System;

public partial class PlayerStatusJumping : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {

        // JumpingAnimationDirection(); TODO: review correct implementation
        player.animations.Play("Jump");
        // player.audio.Play();

        ImpulseForTheJump(delta);

        player.velocity.X = (float)(Input.GetAxis("Left", "Right") * player.speed * delta);


        ApplyGravity(delta);
        
        player.Velocity = player.velocity;
        player.MoveAndSlide();
  
        ChangeToFalling();
    }

    #endregion

    #region Custom Methods

    private void JumpingAnimationDirection()
    {
        if (player.velocity.X < 0)
        {
            player.animations.Play("JumpLeft");
        }
        else if (player.velocity.X > 0)
        {
            player.animations.Play("JumpRight");
        }
        else if (player.velocity.X == 0)
        {
            player.animations.Play("Jump");
        }
    }

    private void ImpulseForTheJump(double delta)
    {
        if (player.IsOnFloor() && player.velocity.Y > 0)
        {
            player.velocity.Y = (float)(-player.jumpForce * delta);
            player.audio.Play();
        }
    }

    private void ChangeToFalling()
    {
        if (player.velocity.Y > 0)
        {
            stateMachine.ChangeTo(PlayerStatusName.fall);
        }
    }

    #endregion
}
