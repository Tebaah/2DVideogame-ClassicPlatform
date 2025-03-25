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
        enemy.velocity.X = 0;
        ApplyGravity(delta);
        enemy.Velocity = enemy.velocity;
        enemy.MoveAndSlide();


        TimerToChange();
        // enemy.animations.Play("Idle"); TODO: create idle animation
    }

    #endregion  

    #region Methods 

    private async void TimerToChange()
    {
        await ToSignal(GetTree().CreateTimer(2), "timeout");
        stateMachine.ChangeTo("StateWalk");
    }

    #endregion
}
