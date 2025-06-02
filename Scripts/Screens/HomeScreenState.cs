using Godot;
using System;

public partial class HomeScreenState : ScreenStateBase
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        DisplayManagerScreen.HomeScreenLayer.Visible = true;
        ChangeToMainScreen();
    }
    #endregion

    #region Custom Methods

    public async void ChangeToMainScreen()
    {
        await ToSignal(GetTree().CreateTimer(3.5f), "timeout");
        stateMachine.ChangeTo("MainScreenState");
    }
    #endregion
}
