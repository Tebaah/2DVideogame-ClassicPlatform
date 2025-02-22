using Godot;
using System;

public partial class GameManager : Node
{
    #region Variables

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

    #endregion
}
