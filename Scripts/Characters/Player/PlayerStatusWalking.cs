using Godot;
using System;

public partial class PlayerStatusWalking : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);
        

        player.SetVelocityX((float)(Input.GetAxis("Left", "Right") * player.Speed * delta));

        player.MoveAndSlide();

        player.Animations.Play("Walk");
    }

    public override void OnInput(InputEvent @event)
    {
        if (!Input.IsActionPressed("Left") && !Input.IsActionPressed("Right"))
        {
            stateMachine.ChangeTo(PlayerStatusName.idle);
        }
        else if (Input.IsActionJustPressed("Jump"))
        {
            stateMachine.ChangeTo(PlayerStatusName.jump);
        }
    }

    #endregion  

    #region Methods 

    #endregion
}
