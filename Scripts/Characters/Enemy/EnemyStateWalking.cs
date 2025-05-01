using Godot;
using System;

public partial class EnemyStateWalking : EnemyStateGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        ApplyGravity(delta);
        Move(delta);
    }

    #endregion  

    #region Methods 

    private void Move(double delta)
    {
        enemy.velocity = enemy.Velocity;

        if(enemy.initialPosition > enemy.finalPosition)
        {
            enemy.sprite.Play("Walk");
            enemy.velocity.X -= (float)(enemy.speed * delta);
            enemy.sprite.FlipH = false;
            if(enemy.Position.X <= enemy.finalPosition)
            {
                enemy.velocity.X = 0;
                enemy.initialPosition = enemy.finalPosition;
                enemy.finalPosition = enemy.initialPosition + enemy.distance; 
            }
        }
        else if(enemy.initialPosition < enemy.finalPosition)
        {
            enemy.sprite.Play("Walk");
            enemy.velocity.X += (float)(enemy.speed * delta);
            enemy.sprite.FlipH = true;
            if(enemy.Position.X >= enemy.finalPosition)
            {
                enemy.velocity.X = 0;
                enemy.initialPosition = enemy.finalPosition;
                enemy.finalPosition = enemy.initialPosition - enemy.distance;
            }
        }
        enemy.Velocity = enemy.velocity;
        enemy.MoveAndSlide();

    }

    #endregion
}
