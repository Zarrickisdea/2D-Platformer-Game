using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        if (playButton != null && quitButton != null)
        {
            playButton.onClick.AddListener(EnterGame);
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    void EnterGame()
    {
        if (playButton != null) 
        {
            SceneManager.LoadScene(1);
        }
    }

    void QuitGame()
    { 
        if (quitButton != null) 
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
