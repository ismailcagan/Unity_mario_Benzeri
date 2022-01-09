using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayLevelTime = 1f;
    [SerializeField] int score;
    public static GameManager Instance { get; private set; }
    public event System.Action<bool> OnsceneChange;
    public event System.Action<int> OnScoreChanged;
    private void Awake()
    {
        SigletonThisGameObject();
    }
    private void SigletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadScene(int levelIndex = 0)
    {
        //StartCoroutine(LoadSceneAsync(levelIndex));
        //StartCoroutine((IEnumerator)LoadSceneAsync(levelIndex));
        StartCoroutine(LoadSceneAsync(levelIndex));
    }
    private IEnumerator LoadSceneAsync(int levelIndex)
    {
        yield return new WaitForSeconds(delayLevelTime);

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        yield return SceneManager.UnloadSceneAsync(buildIndex);

        SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
        };
        OnsceneChange?.Invoke(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game method trigger");
        Application.Quit();
    }

    public void LoadMenuAndUi(int delayLoadingTime)
    {
        StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
    }
    private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
    {
        yield return new WaitForSeconds(delayLoadingTime);
        yield return SceneManager.LoadSceneAsync("Menu");
        yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);
        OnsceneChange?.Invoke(true);
       
    }

    // score için oluşturuldu
    public void IncreaseScore(int score=0)
    {
       // GameManager.Instance.IncreaseScore(score);
        this.score += score;
        OnScoreChanged?.Invoke(this.score);
     
    }
}
