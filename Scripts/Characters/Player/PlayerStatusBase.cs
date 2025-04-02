using Godot;
using System;

public partial class PlayerStatusBase : StateBase
{
    #region Variables

    public PlayerController player;
    public double gravity;

    #endregion

    #region Godot Methods

    public override void AtStartState()
    {
        if (nodeToControl == null)
        {
            GD.PrintErr("nodeToControl is null in AtStartState");
            return;
        }

        player = nodeToControl as PlayerController;

        if (player == null)
        {
            GD.PrintErr("player is null in AtStartState");
            return;
        }

        gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    }

    public override void AtEndState()
    {

    }

    #endregion

    #region Methods

    public override void OnProcess(double delta) { }
    public override void OnPhysicsProcess(double delta) { }
    public override void OnInput(InputEvent @event) { }
    public override void OnUnhandledInput(InputEvent @event) { }
    public override void OnUnhandledKeyInput(InputEvent @event) { }

    #endregion
}
