using Godot;
using System;

public partial class PlayerStatusGravity : PlayerStatusBase
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        ApplyGravity(delta);
    }

    #endregion

    #region Methods

    public void ApplyGravity(double delta)
    {
        if (!player.IsOnFloor())
        {    
            player.AddVelocityY((float)(gravity * delta));
        }
    }

    #endregion
}
