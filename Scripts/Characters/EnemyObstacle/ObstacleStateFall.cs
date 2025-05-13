using Godot;
using System;

public partial class ObstacleStateFall : ObstacleEnemyBase
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        enemyObstacle.AnimatedSprite.Play("Fall");
        enemyObstacle.CollisionShape.Visible = false;
    }

    public override void OnPhysicsProcess(double delta)
    {
        enemyObstacle.ObstacleFall((float)(enemyObstacle.FallSpeed * delta));
        
        if (enemyObstacle.RayCast.IsColliding())
        {
            stateMachine.ChangeTo("StateRise");
        }
    }
    
    #endregion

    #region Custom Methods
    #endregion
}
