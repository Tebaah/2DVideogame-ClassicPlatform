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
        if (!enemy.IsOnFloor() && enemy.enemyType == "Ground")
        {
            enemy.velocity.Y += (float)(gravity * delta);
        }
        else
        {
            enemy.velocity.Y = 0;
        }
    }

    #endregion
}
