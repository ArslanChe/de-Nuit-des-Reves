using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Вызывается при нажатии кнопки "Выход"
    public void QuitGame()
    {
        Debug.Log("Выход из игры...");

#if UNITY_EDITOR
        // Если игра запущена в редакторе Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
