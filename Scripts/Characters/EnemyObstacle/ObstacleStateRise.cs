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
        ObstacleRise((float)(enemyObstacle.RiseSpeed * delta));

        if (enemyObstacle.Position.Y <= enemyObstacle.PositionInitialY)
        {
            stateMachine.ChangeTo("StateIdle");
        }
    }

    #endregion

    #region Custom Methods
    private void ObstacleRise(float riseSpeed)
    {
        enemyObstacle.Position = new Vector2(enemyObstacle.Position.X, enemyObstacle.Position.Y - riseSpeed);
    }
    #endregion
}