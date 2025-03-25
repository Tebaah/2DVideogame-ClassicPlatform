using Godot;
using System;

public partial class EnemyStateWalking : EnemyStateGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        // enemy.velocity.X = (float)(-enemy.speed * delta);
        ApplyGravity(delta);
        Move(delta);
        // enemy.Velocity = enemy.velocity;
        // enemy.MoveAndSlide();

    }

    #endregion  

    #region Methods 

    private void Move(double delta)
    {
        enemy.velocity = enemy.Velocity;

        if(enemy.initialPosition > enemy.finalPosition)
        {
            enemy.animations.Play("Walk");
            enemy.velocity.X -= (float)(enemy.speed * delta);
            if(enemy.Position.X <= enemy.finalPosition)
            {
                enemy.velocity.X = 0;
                enemy.initialPosition = enemy.finalPosition;
                enemy.finalPosition = enemy.initialPosition + enemy.distance; // Change this value to the distance you want the enemy to walk
                // stateMachine.ChangeTo(EnemyStatesNames.Idle);
            }
        }
        else if(enemy.initialPosition < enemy.finalPosition)
        {
            enemy.animations.Play("Walk");
            // enemy.sprite.FlipH = false;
            enemy.velocity.X += (float)(enemy.speed * delta);
            if(enemy.Position.X >= enemy.finalPosition)
            {
                enemy.velocity.X = 0;
                enemy.initialPosition = enemy.finalPosition;
                enemy.finalPosition = enemy.initialPosition - enemy.distance; // Change this value to the distance you want the enemy to walk
                // stateMachine.ChangeTo(EnemyStatesNames.Idle);
            }
        }
        enemy.Velocity = enemy.velocity;
        enemy.MoveAndSlide();

    }

    #endregion
}
