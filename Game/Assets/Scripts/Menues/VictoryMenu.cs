using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryCanvas;
    public PlayerInput playerInput;

    public void ShowVictory()
    {
        victoryCanvas.SetActive(true);
        Time.timeScale = 0f;

        string currentLevel = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("achieved_" + currentLevel, 1);

        if (playerInput != null)
            playerInput.DeactivateInput();

        GameStatsManager.AddLevelCompleted();
        SaveProgress();
    }

    private void SaveProgress()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.StartsWith("Level "))
        {
            string numberPart = sceneName.Substring("Level ".Length);

            if (int.TryParse(numberPart, out int levelCode))
            {
                int levelNumber = levelCode / 10;
                int mode = levelCode % 10;

                string key = mode == 1 ? "unlockedLevelSweet" : "unlockedLevelNightmare";
                int currentUnlocked = PlayerPrefs.GetInt(key, 1);

                if (levelNumber + 1 > currentUnlocked)
                {
                    PlayerPrefs.SetInt(key, levelNumber + 1);
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void LoadLevelMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Menu");
    }
}