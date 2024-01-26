#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void HandleNameInput(string value)
    {
        GameManager.instance.currentPlayer = value;
    }

    public void HandleStartGameClick()
    {
        SceneManager.LoadScene(1);
    }

    public void HandleBackToMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleExitGameClick()
    {
        GameManager.instance.SaveSession();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
