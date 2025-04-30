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
        
        player.Animations.Play("Jump");

        ImpulseForTheJump(delta);

        player.SetVelocityX((float)(Input.GetAxis("Left", "Right") * player.Speed * delta));

        // ApplyGravity(delta);
        
        player.MoveAndSlide();
  
        ChangeToFalling();
    }

    #endregion

    #region Custom Methods

    private void ImpulseForTheJump(double delta)
    {
        if (player.IsOnFloor() || player.JumpByEnemy)
        {
            player.setVelocityY((float)(-player.JumpForce * delta));
            
            player.Audio.Play();
            player.JumpByEnemy = false; // Resetea la variable
        }
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
