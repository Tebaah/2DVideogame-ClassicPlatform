using Godot;
using System;

public partial class HomeScreenController : Node2D
{
    #region Variables

    GameManager _gameManager;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");

        _gameManager.TimerTochangeScene(SceneResources.selectionScreen);
    }

    #endregion

    #region Custom Methods

    #endregion
}
