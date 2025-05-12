using Godot;
using System;

public partial class ObstacleStateRise : ObstacleEnemyBase
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        enemyObstacle.AnimatedSprite.Play("Idle");
        enemyObstacle.CollisionShape.Visible = false;
    }

    public override void OnPhysicsProcess(double delta)
    {
        enemyObstacle.ObstacleRise((float)(enemyObstacle.RiseSpeed * delta));
    }
    
    #endregion

    #region Custom Methods
    #endregion
}