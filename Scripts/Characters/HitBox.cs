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
<<<<<<< HEAD
            levelManager.Discountscore(5);
=======
<<<<<<< Updated upstream
            GetTree().Root.GetNode<LevelManager>("Level1").Discountscore(5);
>>>>>>> feature/enemy
            GD.Print("HitBox: Player hit!");
=======
            HandlePlayerHit(levelManager);
>>>>>>> Stashed changes
        }
        else if (body.IsInGroup("Enemy"))
        {
<<<<<<< Updated upstream
            GD.Print("Hitbox collided with enemy!"); // TODO: implement damage system
            var player = GetParent().GetNodeOrNull<PlayerController>("Player");
            if (player == null)
            {
                GD.PrintErr("Player not found in HitBox");
            }
            else
            {
                player.jumpByEnemy = true;
                var stateMachine = player.GetNodeOrNull<StateMachine>("StateMachine");
                if (stateMachine == null)
                {
                    GD.PrintErr("StateMachine not found in Player");
                }
                else
                {
                    stateMachine.ChangeTo(PlayerStatusName.jump);
                }
            }
            body.QueueFree();
=======
            HandleEnemyHit(body);
>>>>>>> Stashed changes
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
        player.jumpByEnemy = true;
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
