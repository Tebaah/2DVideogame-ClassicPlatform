using Godot;
using System;

public partial class PlayerStatusIdle : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);
                
        player.SetVelocityX(0);

        player.MoveAndSlide();

        player.Animations.Play("Idle");
    }
    public override void OnInput(InputEvent @event)
    {
        if (Input.IsActionPressed("Left") || Input.IsActionPressed("Right"))
        {
            stateMachine.ChangeTo(PlayerStatusName.walk);
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
