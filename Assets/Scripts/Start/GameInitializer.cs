using UnityEngine;
using Menu;
using UI;
using Player;

public class GameInitializer : MonoBehaviour
{
    [Header("Core References")]
    public GameManager gameManager;
    public HUDUI hudUI;
    public EndGamePanelUI endGamePanelUI;
    public GameObject player;

    void Awake()
    {
        SetupGameManager();
        SetupHUD();
        SetupPlayer();
    }

    // Прив'язка GameManager до інших систем
    private void SetupGameManager()
    {
        if (!gameManager)
        {
            Debug.LogError("GameManager not assigned!");
            return;
        }

        gameManager.endGameUI = endGamePanelUI;
        GameManager.instance = gameManager;
    }

    // перевірка HUD
    private void SetupHUD()
    {
        if (!hudUI)
        {
            Debug.LogWarning("HUD UI not assigned.");
            return;
        }
    }

    // Прив’язка HUD до гравця
    private void SetupPlayer()
    {
        if (!player)
        {
            Debug.LogError("Player not assigned!");
            return;
        }

        Player.Player playerScript = player.GetComponent<Player.Player>();
        if (playerScript != null && hudUI != null)
        {
            playerScript.hudUI = hudUI;
        }
    }
}
