using Godot;
using System;

public partial class SplashScreenState : ScreenStateBase
{
    #region Variables

    #endregion

    #region Godot Methods
    public override void AtStartState()
    {

        base.AtStartState();
        displayManager.splashScreen.Visible = true;
        TimerToChangeState();    
    }

    #endregion

    #region Custon Methods

    public async void TimerToChangeState()
    {
        await ToSignal(GetTree().CreateTimer(2), "timeout");
        displayManager.splashScreen.Visible = false;
        stateMachine.ChangeTo("SelectionScreen");
    }

    #endregion
}
