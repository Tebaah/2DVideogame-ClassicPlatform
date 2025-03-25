using Godot;
using System;

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

        // enemy.animations.Play("Idle"); TODO: create idle animation
    }

    #endregion  

    #region Methods 

    #endregion
}
