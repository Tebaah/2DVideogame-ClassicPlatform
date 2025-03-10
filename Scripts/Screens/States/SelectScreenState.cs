using Godot;
using System;

public partial class SelectScreenState : ScreenStateBase
{
    #region Variables

    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        base.AtStartState();
        displayManager.selectionScreen.Visible = true;
    }
    #endregion

    #region Custon Methods

    #endregion
}
