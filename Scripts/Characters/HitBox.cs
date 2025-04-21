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
            levelManager.Discountscore(5);
            GD.Print("HitBox: Player hit!");
        }

        if (body.IsInGroup("Enemy"))
        {
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
        }
    }
    #endregion

}
