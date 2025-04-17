using Godot;
using System;
using System.Threading.Tasks;

public partial class EnemyStateDead : EnemyStateGravity
{
    #region Variables

    #endregion

    #region Godot Methods

    #endregion  

    #region Custom Methods

    public async void OnDead()
    {
        GD.Print("Enemy is dead");
        await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
        QueueFree();
    }
    #endregion
}
