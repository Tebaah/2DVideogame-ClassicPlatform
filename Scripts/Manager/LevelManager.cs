using Godot;
using System;
using System.Threading.Tasks;

public partial class LevelManager : Node2D
{
	#region Variables

	[Export] public int pointsToWin;
	public int score;
	[Export] public int timeToWin;
	public Label timeLabel;
	private Timer timer;

	[Export] public int LimitLeft;
	[Export] public int LimitRight;
	[Signal] public delegate void OnScoreUpdatedEventHandler(int score);

	#endregion

	#region Godot Methods

	public override void _Ready()
	{
		var gui = GetNode<CanvasLayer>("CanvasLayer");
		Connect(nameof(OnScoreUpdated), new Callable(gui, "UpdateScore"));
	
		timer = GetNode<Timer>("Timer");
		
		timeLabel = GetNode<Label>("CanvasLayer/Control/Container/TimeLabel");
		timeLabel.Text = $"Time: {timeToWin / 60:D2}:{timeToWin % 60:D2}";

		StartTimer();
	}

	#endregion

	#region Custom Methods

	public void AddScore(int points)
	{
		score += points;
		EmitSignal(nameof(OnScoreUpdated), score);
	}

	public void Discountscore(int points)
	{
		score -= points;
		EmitSignal(nameof(OnScoreUpdated), score);
	}

	public void MultiplyScore(float multiplier)
	{
		score = (int)(score * multiplier);
		EmitSignal(nameof(OnScoreUpdated), score);
	}

	public async void StartTimer()
	{
		await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
		timer.Start();
	}

	public void OnTimerTimeout()
	{
		if (timeToWin > 0)
		{
			timeToWin--;
			int m = (int)(timeToWin / 60);
			int s = timeToWin - m * 60;
			timeLabel.Text = $"Time: {m:D2}:{s:D2}";
		}
	}

	#endregion
}
