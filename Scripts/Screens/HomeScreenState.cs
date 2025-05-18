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
        DisplayManager.Visible = true;
    }
    #endregion

    #region Custom Methods
    #endregion
}
