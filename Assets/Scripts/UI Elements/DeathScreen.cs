
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
            SoundManager.Instance.StopMusic();
            playAgainButton.onClick.AddListener(PlayAgain);
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    void PlayAgain () 
    {
        SceneManager.LoadScene(0);
        Spawner.Instance.Burn();
    }

    void QuitGame ()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
