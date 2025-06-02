using Godot;
using System;

public partial class EnemyStateGravity : EnemyStateBase
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void OnPhysicsProcess(double delta)
    {
        ApplyGravity(delta);
    }

    #endregion

    #region Custom Methods

    public void ApplyGravity(double delta)
    {
        if (!enemy.IsOnFloor() && enemy.EnemyType == "Ground")
        {
            enemy.AddVelocityY((float)(Gravity * delta));
        }
        else
        {
            enemy.SetVelocityY(0);
        }
    }

    #endregion
}
