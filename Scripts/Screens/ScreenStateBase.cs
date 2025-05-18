using Godot;
using System;

public partial class ScreenStateBase : StateBase
{
    #region Variables
    public DisplayManager DisplayManagerScreen { get; set; }
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        if (nodeToControl == null)
        {
            GD.PrintErr("nodeToControl is null in AtStartState");
            return;
        }

        DisplayManagerScreen = nodeToControl as DisplayManager;

        if (DisplayManagerScreen == null)
        {
            GD.PrintErr("Display Manager is null in AtStartState");
            return;
        }
    }
    
    #endregion

    #region Custom Methods
    #endregion
}
