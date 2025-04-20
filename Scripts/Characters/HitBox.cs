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
            // body.GetNode<EnemyStateDead>("StateDead").OnDead();
        }
    }
    #endregion

}
