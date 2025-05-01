using Godot;
using System;

public partial class EnemyStateWalking : EnemyStateGravity
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnPhysicsProcess(double delta)
    {
        base.OnPhysicsProcess(delta);
        Move(delta);
    }

    #endregion  

    #region Methods 

    private void Move(double delta)
    { 
        if (enemy.InitialPosition > enemy.FinalPosition)
        {
            enemy.Sprite.Play("Walk");
            enemy.RemoveVelocityX((float)(enemy.Speed * delta));
            enemy.Sprite.FlipH = false;
            if(enemy.Position.X <= enemy.FinalPosition)
            {
                enemy.SetVelocityX(0);
                enemy.InitialPosition = enemy.FinalPosition;
                enemy.FinalPosition = enemy.InitialPosition + enemy.Distance; 
            }
        }
        else if(enemy.InitialPosition < enemy.FinalPosition)
        {
            enemy.Sprite.Play("Walk");
            enemy.AddVelocityX((float)(enemy.Speed * delta));
            enemy.Sprite.FlipH = true;
            if(enemy.Position.X >= enemy.FinalPosition)
            {
                enemy.SetVelocityX(0);
                enemy.InitialPosition = enemy.FinalPosition;
                enemy.FinalPosition = enemy.InitialPosition - enemy.Distance;
            }
        }
        enemy.MoveAndSlide();

    }

    #endregion
}
