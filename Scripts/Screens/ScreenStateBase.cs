using Godot;
using System;

public partial class ScreenStateBase : StateBase
{
    #region Variables
    public DisplayManager DisplayManager { get; set; }
    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        if (nodeToControl == null)
        {
            GD.PrintErr("nodeToControl is null in AtStartState");
            return;
        }

        DisplayManager = nodeToControl as DisplayManager;

        if (DisplayManager == null)
        {
            GD.PrintErr("Display Manager is null in AtStartState");
            return;
        }
    }
    
    #endregion

    #region Custom Methods
    #endregion
}
