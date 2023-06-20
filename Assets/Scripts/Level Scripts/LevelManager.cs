using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] private string Level1;

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelState(Level1) == LevelState.Locked)
        {
            SetLevelState(Level1, LevelState.Unlocked);
        }
    }

    public LevelState GetLevelState(string level)
    {
        LevelState levelState = (LevelState) PlayerPrefs.GetInt(level, 0);

        return levelState;
    }

    public void SetLevelState(string level, LevelState state)
    {
        PlayerPrefs.SetInt(level, (int)state);
    }

    public void LevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SetLevelState(currentScene.name, LevelState.Completed);

        int nextSceneIndex = currentScene.buildIndex; //Done because Levels in build settings start from index 2 upto 7
        if (nextSceneIndex < 7)
        {
            string nextSceneName = "Level" + nextSceneIndex;
            SetLevelState(nextSceneName, LevelState.Unlocked);
            LevelDoneUI.Instance.ShowLevelDoneUI(nextSceneName);
        }

        else
        {
            SoundManager.Instance.Play(Sounds.FinishMusic);
            SceneManager.LoadScene("Finish");
        }
    }
}

public enum LevelState
{
    Locked,
    Unlocked,
    Completed
}
