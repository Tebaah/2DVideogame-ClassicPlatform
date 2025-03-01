using Godot;
using System;

public partial class StateMachine : Node
{
    #region Variables
    [Export] public Node nodeToControl;
    [Export] public StateBase defaultState;
    public StateBase currentState = null;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        if(nodeToControl == null)
        {
            GD.PrintErr("nodeToControl is not assigned");
            return;
        }

        if(defaultState != null)
        {
            CallDeferred(nameof(StateDefaultStart));
        }
    }

    #endregion

    #region Methods

    public void StateStart()
    {
        if (currentState == null || nodeToControl == null)
        {
            GD.PrintErr("currentState or nodeToControl is null in StateStart");
            return;
        }

        GD.Print("StateMachine ", nodeToControl.Name, " State Start ", currentState.Name);

        currentState.nodeToControl = nodeToControl;
        currentState.stateMachine = this;
        currentState.AtStartState();
    }

    public void StateDefaultStart()
    {
        currentState = defaultState;
        StateStart();
    }

    public void ChangeTo(string newState)
    {
        if (currentState != null && currentState.HasMethod("AtEndState"))
        {
            currentState.AtEndState();
        }

        currentState = GetNode<StateBase>(newState);

        if (currentState == null)
        {
            GD.PrintErr("Failed to change to state: ", newState);
            return;
        }

        StateStart();
    }

    public override void _Process(double delta)
    {
        currentState?.OnProcess(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        currentState?.OnPhysicsProcess(delta);
    }

    public override void _Input(InputEvent @event)          
    {
        currentState?.OnInput(@event);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        currentState?.OnUnhandledInput(@event);
    }

    public void _UnhandledKeyInput(InputEventKey @event)
    {
        currentState?.OnUnhandledKeyInput(@event);
    }

    #endregion
}