using Godot;
using System;

public partial class Paused : CanvasLayer
{
    private ColorRect _colorRect;
    public override void _Ready()
    {
        _colorRect = GetNode<ColorRect>("ColorRect");
    }
    public override void _Process(double delta)
    {
        GamePaused();
    }

    public void GamePaused()
	{
        if (Input.IsActionJustPressed("Pause"))
        {
            GetTree().Paused = !GetTree().Paused;
            _colorRect.Visible = !_colorRect.Visible;
		}

	}
}
