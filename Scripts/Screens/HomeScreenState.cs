using Godot;
using System;
using System.Threading.Tasks;

public partial class HomeScreenState : ScreenStateBase
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        TimerToChangeState();    
    }

    #endregion

    #region Custon Methods

    public async void TimerToChangeState()
    {
        await ToSignal(GetTree().CreateTimer(5), "timeout");
        displayManager.homeScreen.Visible = false;
        stateMachine.ChangeTo("SplashScreen");
    }

    #endregion
}
