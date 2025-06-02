using Godot;
using System;

/// <summary>
/// HitBox gestiona la detección de colisiones para aplicar daño, sumar o restar puntaje,
/// y controlar la interacción entre el jugador y los enemigos.
/// </summary>
public partial class HitBox : Area2D
{
    #region Variables

    /// <summary>
    /// Referencia al nodo principal del nivel, utilizada para buscar otros nodos como ScoreManager.
    /// </summary>
    private Node _levelNode;

    #endregion

    #region Godot Methods

    /// <summary>
    /// Inicializa la referencia al nodo principal del nivel al cargar la escena.
    /// </summary>
    public override void _Ready()
    {
        _levelNode = GetTree().CurrentScene;
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// Método principal de colisión. Detecta si el cuerpo que entra es el jugador o un enemigo
    /// y delega la acción correspondiente.
    /// </summary>
    /// <param name="body">El nodo que entra en el área de colisión.</param>
    public void OnHitBoxAreaEntered(Node2D body)
    {
        // Busca el ScoreManager en la ruta LevelManager/ScoreManager
        var scoreManager = _levelNode.GetNodeOrNull<ScoreManager>("LevelManager/ScoreManager");

        if (body.IsInGroup("Player"))
        {
            HandlePlayerHit(scoreManager);
        }
        else if (body.IsInGroup("Enemy"))
        {
            HandleEnemyHit(body);
        }
    }

    /// <summary>
    /// Resta puntaje al jugador cuando es golpeado.
    /// </summary>
    /// <param name="scoreManager">Referencia al ScoreManager para descontar puntos.</param>
    public void HandlePlayerHit(ScoreManager scoreManager)
    {
        scoreManager?.DiscountScore(5);
        GD.Print("HitBox: Player hit!");
    }

    /// <summary>
    /// Gestiona la lógica cuando un enemigo es golpeado: hace saltar al jugador y elimina al enemigo.
    /// </summary>
    /// <param name="body">El nodo enemigo que fue golpeado.</param>
    private void HandleEnemyHit(Node2D body)
    {
        HandlePlayerJumpByEnemy();
        HandleEnemyDeath(body);
    }

    /// <summary>
    /// Hace que el jugador realice un salto especial al golpear a un enemigo.
    /// </summary>
    private void HandlePlayerJumpByEnemy()
    {
        var player = GetParent().GetNodeOrNull<PlayerController>("../Player");
        if (player == null)
        {
            GD.PrintErr("Player not found in HitBox");
            return;
        }
        player.JumpByEnemy = true;
        var stateMachine = player.GetNodeOrNull<StateMachine>("StateMachine");
        if (stateMachine == null)
        {
            GD.PrintErr("StateMachine not found in Player");
            return;
        }
        stateMachine.ChangeTo(PlayerStatusName.jump);
    }

    /// <summary>
    /// Elimina al enemigo, suma puntaje y cambia su estado a muerto.
    /// </summary>
    /// <param name="body">El nodo enemigo que fue golpeado.</param>
    private void HandleEnemyDeath(Node2D body)
    {
        var enemy = body.GetParent().GetNodeOrNull<EnemyController>($"{body.Name}");
        if (enemy == null)
        {
            GD.PrintErr("EnemyController not found in Enemy");
            return;
        }
        var stateMachine = enemy.GetNodeOrNull<StateMachine>("StateMachine");
        if (stateMachine == null)
        {
            GD.PrintErr("StateMachine not found in Enemy");
            return;
        }

        var scoreManager = _levelNode.GetNodeOrNull<ScoreManager>("LevelManager/ScoreManager");
        if (scoreManager == null)
        {
            GD.PrintErr("ScoreManager not found in LevelManager");
            return;
        }
        scoreManager?.AddScore(enemy.Point);

        stateMachine.ChangeTo("StateDead");
    }
    #endregion

}
