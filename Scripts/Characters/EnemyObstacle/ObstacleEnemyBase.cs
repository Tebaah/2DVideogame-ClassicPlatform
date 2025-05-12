using Godot;
using System;

public partial class ObstacleEnemyBase : StateBase
{
    #region Variables
    public EnemyObstacle enemyObstacle;

    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        if (nodeToControl == null)
        {
            GD.PrintErr("nodeToControl is null in AtStartState");
            return;
        }

        enemyObstacle = nodeToControl as EnemyObstacle;

        if (enemyObstacle == null)
        {
            GD.PrintErr("EnemyObstacle is null in AtStartState");
            return;
        }
    }

    public override void AtEndState()
    {

    }

    #endregion

    #region Methods

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnInput(InputEvent @event) { }
    public override void OnUnhandledInput(InputEvent @event) { }
    public override void OnUnhandledKeyInput(InputEvent @event) { }

    #endregion
}
