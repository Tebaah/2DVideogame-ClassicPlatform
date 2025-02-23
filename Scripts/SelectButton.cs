using Godot;
using System;

public partial class SelectButton : Button
{
    #region Variables

    GameManager _gameManager;
    public LevelController levelController;
    Button button;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager"); 
    }
    #endregion

    #region custom Methods

    public void OnSelectButtonPressed()
    {
        _gameManager.ChangeBetweenScene(SceneResources.gameScreen);
    }

    #endregion
}
