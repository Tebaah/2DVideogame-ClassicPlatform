using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

public partial class GameManager : Node
{
    #region Variables

    public Dictionary<string,(PackedScene, bool)> LevelCompletionStatus { get; private set; } = new();
    private string savePath;

    #endregion

    #region Godot Methods

    public override void _Ready()
    {
        // Set the save path to the user data directory
        savePath = Path.Combine(OS.GetUserDataDir(), "progress.json");

        // Register levels and their completion status
        RegisterLevel("Level1", GD.Load<PackedScene>("res://Scenes/Level/level_1.tscn"));
        RegisterLevel("Level2", GD.Load<PackedScene>("res://Scenes/Level/level_2.tscn"));

        // Load the saved progress
        LoadProcess();
    }

    #endregion

    #region Custom Methods

    public void RegisterLevel(string levelName, PackedScene levelScene)
    {
        if (!LevelCompletionStatus.ContainsKey(levelName))
        {
            LevelCompletionStatus[levelName] = (levelScene, false);
        }
        GD.Print($"Level {levelName} registered.");
    }

    public void MarkLevelAsCompleted(string levelName)
    {
        if (LevelCompletionStatus.ContainsKey(levelName))
        {
            var (scene, _) = LevelCompletionStatus[levelName];
            LevelCompletionStatus[levelName] = (scene, true);
            GD.Print($"{levelName} marked as completed.");
        }
    }

    public bool IsLevelCompleted(string levelName)
    {
        return LevelCompletionStatus.TryGetValue(levelName, out var status) && status.Item2;
    }

    public void SaveProcess()
    {
        GD.Print("Save process...");
        var jsonData = new Dictionary<string, bool>();

        foreach (var level in LevelCompletionStatus)
        {
            jsonData[level.Key] = level.Value.Item2;
        }

        string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });

        try
        {
            File.WriteAllText(savePath, jsonString);
            GD.Print("Process saved successfully.");
        }
        catch (System.Exception e)
        {
            GD.PrintErr($"Error {e.Message}");
        }
    }

    public void LoadProcess()
    {
        if (File.Exists(savePath))
        {
            GD.Print("Save file found.");
            string jsonString = File.ReadAllText(savePath);

            try
            {
                var jsonData = JsonSerializer.Deserialize<Dictionary<string, bool>>(jsonString);

                foreach (var level in jsonData)
                {
                    if (LevelCompletionStatus.ContainsKey(level.Key))
                    {
                        var (scene, _) = LevelCompletionStatus[level.Key];
                        LevelCompletionStatus[level.Key] = (scene, level.Value);
                    }
                }

                GD.Print("Progress loaded successfully.");
            }
            catch (System.Exception e)
            {
                GD.PrintErr($"Error loading progress : {e.Message}");
            }
        }
        else
        {
            GD.Print("No save file found.");
        }
        }

    #endregion
}
