using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(EnterGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
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
