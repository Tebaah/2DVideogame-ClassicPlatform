using Godot;
using System;

public partial class DisplayManager : Control
{
    #region Variables

    public CanvasLayer HomeScreenLayer { get; private set; }
    public CanvasLayer MainScreenLayer { get; private set; }
    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        HomeScreenLayer = GetNode<CanvasLayer>("StateMachine/HomeScreenState/HomeScreen");
        MainScreenLayer = GetNode<CanvasLayer>("StateMachine/MainScreenState/MainScreen");
    }

    #endregion

    #region Custom Methods
    #endregion
}
