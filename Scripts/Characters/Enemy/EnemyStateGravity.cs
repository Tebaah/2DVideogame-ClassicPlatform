using Godot;
using System;

public partial class EnemyStateGravity : EnemyStateBase
{
    #region Variables

    #endregion

    #region Godot Methods

    #endregion

    #region Custom Methods

    public void ApplyGravity(double delta)
    {
        if (!enemy.IsOnFloor())
        {    
            enemy.velocity.Y += (float)(gravity * delta);
        }
    }

    #endregion
}
