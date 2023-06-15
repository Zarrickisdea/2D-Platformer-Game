using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Button mainMenu;
    private void Start()
    {
        for (int i = 0;  i < buttons.Length; i++)
        {
            int levelIndex = i + 1;
            buttons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }

        mainMenu.onClick.AddListener(() => LoadLevel(0));
    }

    private void LoadLevel (int levelIndex)
    {
        string levelName = "Level" + levelIndex;
        LevelState levelState = LevelManager.Instance.GetLevelState(levelName);

        switch (levelState)
        {
            case LevelState.Locked:
                Debug.Log("Cannot play until unlocked");
                break;

            case LevelState.Unlocked: 
                SceneManager.LoadScene(levelName);
                break;

            case LevelState.Completed: 
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
