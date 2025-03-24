using Godot;
using System;

public partial class ScoreInterface : CanvasLayer
{
    #region Variables

    private Label _scoreLabel;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("Control/Container/ScoreLabel");
        _scoreLabel.Text = "Score: 0";
    }
    #endregion

    #region Custom Methods

    public void UpdateScore(int newScore)
    {
        _scoreLabel.Text = $"Score: {newScore}";
    }

    #endregion
}
