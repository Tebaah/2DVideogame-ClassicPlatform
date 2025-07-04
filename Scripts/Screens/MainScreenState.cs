using Godot;
using System;

public partial class MainScreenState : ScreenStateBase
{
    #region Variables
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        ChangeVisibiliityScreen();
    }
    #endregion

    #region Custom Methods

    public void ChangeVisibiliityScreen()
    {
        DisplayManagerScreen.MainScreenLayer.Visible = true;
        DisplayManagerScreen.HomeScreenLayer.Visible = false;
    }
    

    #endregion
}
