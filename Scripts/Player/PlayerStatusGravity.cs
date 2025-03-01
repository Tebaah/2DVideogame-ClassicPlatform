using Godot;
using System;

public partial class PlayerStatusGravity : PlayerStatusBase
{
    #region Variables

    #endregion

    #region Godot Methods

    #endregion

    #region Methods

    public void ApplyGravity(double delta)
    {
        player.velocity.Y += (float)(gravity * delta);
    }

    #endregion
}
