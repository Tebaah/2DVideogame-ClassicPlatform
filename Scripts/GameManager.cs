using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    #region Variables

    Dictionary<string, bool> completedLevels = new();

    #endregion

    #region Godot Methods

    #endregion

    #region Custom Methods

    public async void TimerTochangeScene(string scene)
    {
        await ToSignal(GetTree().CreateTimer(3), "timeout");
        ChangeBetweenScene(scene);
    }

    public void ChangeBetweenScene(string scene)
    {
        GetTree().ChangeSceneToFile(scene);
    }

    public void SetLevelCompleted(string levelName)
    {
        if (!completedLevels.ContainsKey(levelName))
        {
            completedLevels[levelName] = true;
            GD.Print($"Level {levelName} completed");
        }
    }

    public bool IsLevelCompleted(string levelName)
    {
        return completedLevels.ContainsKey(levelName) && completedLevels[levelName];
    }

    #endregion
}
