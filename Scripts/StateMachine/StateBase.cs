using Godot;
using System;

public partial class StateBase : Node
{
    #region Variables
    public Node nodeToControl;
    public StateMachine stateMachine;

    #endregion

    #region Godot Methods

    #endregion

    #region Methods

    public virtual void AtStartState() { }
    public virtual void AtEndState() { }
    public virtual void OnProcess(double delta) { }
    public virtual void OnPhysicsProcess(double delta) { }
    public virtual void OnInput(InputEvent @event) { }
    public virtual void OnUnhandledInput(InputEvent @event) { }
    public virtual void OnUnhandledKeyInput(InputEvent @event) { }

    #endregion
}