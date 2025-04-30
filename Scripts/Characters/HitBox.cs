using Godot;
using System;

public partial class HitBox : Area2D
{
    #region Variables

    #endregion

    #region Godot Methods

    #endregion

    #region Custom Methods

    public void OnHitBoxAreaEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            GetTree().Root.GetNode<LevelManager>("Level1").Discountscore(5);
            GD.Print("HitBox: Player hit!");
        }

        if (body.IsInGroup("Enemy"))
        {
            GD.Print("Hitbox collided with enemy!"); // TODO: implement damage system
            body.QueueFree();
        }
    }

    private void HandlePlayerHit(LevelManager levelManager)
    {
        levelManager?.Discountscore(5);
        GD.Print("HitBox: Player hit!");
    }

    private void HandleEnemyHit(Node2D body)
    {
        HandlePlayerJumpByEnemy();
        HandleEnemyDeath(body);
    }

    private void HandlePlayerJumpByEnemy()
    {
        var player = GetParent().GetNodeOrNull<PlayerController>("../Player");
        if (player == null)
        {
            GD.PrintErr("Player not found in HitBox");
            return;
        }
        player.JumpByEnemy = true;
        var stateMachine = player.GetNodeOrNull<StateMachine>("StateMachine");
        if (stateMachine == null)
        {
            GD.PrintErr("StateMachine not found in Player");
            return;
        }
        stateMachine.ChangeTo(PlayerStatusName.jump);
    }

    private void HandleEnemyDeath(Node2D body)
    {
        var enemy = body.GetParent().GetNodeOrNull<EnemyController>($"{body.Name}");
        if (enemy == null)
        {
            GD.PrintErr("EnemyController not found in Enemy");
            return;
        }
        var stateMachine = enemy.GetNodeOrNull<StateMachine>("StateMachine");
        if (stateMachine == null)
        {
            GD.PrintErr("StateMachine not found in Enemy");
            return;
        }
        stateMachine.ChangeTo("StateDead");
    }

    #endregion

}
