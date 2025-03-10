using Godot;
using System;

public partial class ButtonSelection : Button
{
    #region Variables

    [Export] public PackedScene levelGame;
    [Export] private Button _button;
    private GameManager _gameManager;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        if (_gameManager == null)
        {
            GD.PrintErr("GameManager not found in the scene tree.");
            return;
        }

        ValidateButton();
    }

    #endregion

    #region Custom Methods

    private void ValidateButton()
    {
        _button = this;
        int currentLevelNumber = int.Parse(_button.Name.ToString().Replace("Level", ""));

        if (currentLevelNumber == 1)
        {
            _button.Disabled = false;
        }
        else
        {
            _button.Disabled = !_gameManager.IsLevelCompleted($"Level{currentLevelNumber - 1}");
        }

        if (!_button.Disabled)
        {
            GD.Print($"Button {currentLevelNumber} is enabled.");
        }
    }

    public void OnButtonPressed()
    {
        GetTree().ChangeSceneToFile(levelGame.ResourcePath);
    }

    #endregion
}