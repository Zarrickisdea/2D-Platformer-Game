
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        if (playAgainButton != null && quitButton != null)
        {
            playAgainButton.onClick.AddListener(PlayAgain);
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    void PlayAgain () 
    {
        if (playAgainButton != null)
        {
            SceneManager.LoadScene(0);
        }
    }

    void QuitGame ()
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
