using Godot;
using System;
using System.Threading.Tasks;

public partial class EnemyStateIdle : EnemyStateGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);

        enemy.SetVelocityX(0);

        enemy.MoveAndSlide();

        TimerToChange();
    }

    #endregion  

    #region Methods 

    private async void TimerToChange()
    {
        await ToSignal(GetTree().CreateTimer(0.5), "timeout");
        stateMachine.ChangeTo("StateWalk");
    }

    #endregion
}
