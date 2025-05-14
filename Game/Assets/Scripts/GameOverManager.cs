using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public PlayerInput playerInput;

    public void ShowGameOver()
    {
        gameOverCanvas.SetActive(true);
        if (playerInput != null)
            playerInput.DeactivateInput();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}