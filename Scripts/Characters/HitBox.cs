using Godot;
using System;

public partial class HitBox : Area2D
{
    #region Variables

    private Node _levelNode;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _levelNode = GetTree().CurrentScene;
    }

    #endregion

    #region Custom Methods

    public void OnHitBoxAreaEntered(Node2D body)
    {
        var levelManager = _levelNode.GetNodeOrNull<LevelManager>("LevelManager");

        if (body.IsInGroup("Player"))
        {
            HandlePlayerHit(levelManager);
        }
        else if (body.IsInGroup("Enemy"))
        {
            HandleEnemyHit(body);
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

        var levelManager = _levelNode.GetNodeOrNull<LevelManager>("LevelManager");
        levelManager?.AddScore(enemy.Point);

        stateMachine.ChangeTo("StateDead");

    }
    #endregion

}
