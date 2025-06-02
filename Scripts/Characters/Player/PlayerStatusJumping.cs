using Godot;
using System;

public partial class PlayerStatusJumping : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);

        ImpulseForTheJump(delta);

        player.SetVelocityX((float)(Input.GetAxis("Left", "Right") * player.Speed * delta));

        player.MoveAndSlide();
  
        ChangeToFalling();
    }

    #endregion

    #region Custom Methods

    private void ImpulseForTheJump(double delta)
    {
        if (player.IsOnFloor() || player.JumpByEnemy)
        {
            ApllySoundAndAnimation();
            player.SetVelocityY((float)(-player.JumpForce * delta));
            player.JumpByEnemy = false; // Resetea la variable
        }
    }

    private void ApllySoundAndAnimation()
    {
        player.Audio.Play();
        player.Animations.Play("Jump");
    }
    private void ChangeToFalling()
    {
        if (player.Velocity.Y > 0)
        {
            stateMachine.ChangeTo(PlayerStatusName.fall);
        }
    }

    #endregion
}
