using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Button mainMenu;
    void Start()
    {
        for (int i = 0;  i < buttons.Length; i++)
        {
            int levelIndex = i + 2;
            buttons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }

        mainMenu.onClick.AddListener(() => LoadLevel(0));
    }

    void LoadLevel (int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
