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
    #endregion

}
