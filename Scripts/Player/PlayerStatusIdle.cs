using Godot;
using System;

public partial class PlayerStatusIdle : PlayerStatusBase
{
    #region Variables

    #endregion

    #region Godot Methods   

    public override void OnInput(InputEvent @event)
    {
        if (Input.IsActionPressed("Left") || Input.IsActionPressed("Right"))
        {
            stateMachine.ChangeTo("StateWalk");
        }
    }
    #endregion  

    #region Methods 

    #endregion
}
