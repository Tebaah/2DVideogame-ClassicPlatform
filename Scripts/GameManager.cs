using Godot;
using System;
using System.Threading.Tasks;

public partial class GameManager : Node
{
    #region Variables

    #endregion

    #region Godot Methods

    #endregion

    #region Custom Methods

    public async Task TimerTochangeScene()
    {
        await ToSignal(GetTree().CreateTimer(3), "timeout");
        // TODO: Add ChangeBetweenScene method
    }

    public void ChangeBetweenScene(string scene)
    {
        GetTree().ChangeSceneToFile(scene);
    }

    #endregion
}
