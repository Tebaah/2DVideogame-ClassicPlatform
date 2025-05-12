using Godot;
using System;

public partial class ObstacleStateIdle : ObstacleEnemyBase
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        enemyObstacle.AnimatedSprite.Play("Idle");      
        enemyObstacle.CollisionShape.Visible = true;  
    }
    #endregion

    #region Custom Methods
    #endregion
}
