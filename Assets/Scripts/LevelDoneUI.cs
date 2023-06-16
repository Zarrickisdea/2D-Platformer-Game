using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoneUI : MonoBehaviour
{
    private static LevelDoneUI instance;
    public static LevelDoneUI Instance { get { return instance; } }
    [SerializeField] private GameObject levelDoneText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowLevelDoneUI(string nextSceneName)
    {
        levelDoneText.SetActive(true);
        StartCoroutine(LoadNextScene(nextSceneName));
    }

    private IEnumerator LoadNextScene(string nextSceneName)
    {
        yield return new WaitForSeconds(2f);
        levelDoneText.SetActive(false);
        SceneManager.LoadScene(nextSceneName);
    }


}
