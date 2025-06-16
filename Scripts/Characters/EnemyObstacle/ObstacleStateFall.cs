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
        ObstacleFall((float)(enemyObstacle.FallSpeed * delta));

        if (enemyObstacle.RayCast.IsColliding())
        {
            stateMachine.ChangeTo("StateRise");
        }
    }

    #endregion

    #region Custom Methods
    private void ObstacleFall(float fallSpeed)
    {
        enemyObstacle.Position = new Vector2(enemyObstacle.Position.X, enemyObstacle.Position.Y + (float)fallSpeed);
    }
    #endregion
}
