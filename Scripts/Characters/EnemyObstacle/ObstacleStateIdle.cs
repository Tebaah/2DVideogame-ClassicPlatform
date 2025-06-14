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

    public override void OnPhysicsProcess(double delta)
    {
        if (enemyObstacle.RayCastPlayer.IsColliding() || enemyObstacle.RaycastPlayer2.IsColliding())
        {
            stateMachine.ChangeTo("StateFall");
        }
    }

    #endregion

    #region Custom Methods
    #endregion
}
