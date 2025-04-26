using Godot;
using System;
using System.Threading.Tasks;

public partial class EnemyStateDead : EnemyStateGravity
{
    #region Variables
    [Signal] public delegate void RequestQueueFreeEventHandler();

    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        OnDead();
    }

    #endregion  

    #region Custom Methods

    public void OnDead()
    {
        EmitSignal(nameof(RequestQueueFree));
    }
    #endregion
}
