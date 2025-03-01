using Godot;
using System;

public partial class PlayerStatusWalking : PlayerStatusGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        player.velocity.X = (float)(Input.GetAxis("Left", "Right") * player.speed * delta);
        ApplyGravity(delta);
        player.Velocity = player.velocity;
        player.MoveAndSlide();

        player.animations.Play("Walk");
    }

    public override void OnInput(InputEvent @event)
    {
        if (!Input.IsActionPressed("Left") && !Input.IsActionPressed("Right"))
        {
            stateMachine.ChangeTo("StateIdle");
        }
    }

    #endregion  

    #region Methods 

    #endregion
}
