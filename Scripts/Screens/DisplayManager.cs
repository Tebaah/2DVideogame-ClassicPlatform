using Godot;
using System;

public partial class DisplayManager : Control
{
    #region Variables

    public Control homeScreen;
    public Control selectionScreen;
    public Control splashScreen;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        homeScreen = GetNode<Control>("StateMachine/HomeScreen/HomeScreen");
        selectionScreen = GetNode<Control>("StateMachine/SelectionScreen/SelectionScreen");
        splashScreen = GetNode<Control>("StateMachine/SplashScreen/SplashScreen");

        homeScreen.Visible = true;
        selectionScreen.Visible = false;
        splashScreen.Visible = false;

    }

    #endregion

    #region Custon Methods

    #endregion
}
