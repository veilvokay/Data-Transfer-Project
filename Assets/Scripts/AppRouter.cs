using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class AppRouter : MonoBehaviour
{
    static readonly AppRouter Routes;

    public static AppRouter GetRouter()
    {
        return Routes;
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        GameManager.GetGameManager().SaveSesionData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
