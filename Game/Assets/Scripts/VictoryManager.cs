using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryCanvas;
    public PlayerInput playerInput;

    public void ShowVictory()
    {
        victoryCanvas.SetActive(true);
        if (playerInput != null)
            playerInput.DeactivateInput();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}