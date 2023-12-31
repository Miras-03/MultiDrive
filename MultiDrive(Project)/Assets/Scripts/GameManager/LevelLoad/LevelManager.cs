using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections;

public sealed class LevelManager : MonoBehaviour
{
    [SerializeField] private InterstitialAd interstitialAd;
    [SerializeField] private Animator fadeAnimator;

    private GameManager gameManager;

    private const float waitSeconds = 1f;
    private int currentScene;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        this.gameManager = gameManager;
        SetCurrentLevel();
    }

    private void SetCurrentLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        gameManager.SetCurrentLevel(currentScene);
    }

    public void RestartScene()
    {
        interstitialAd.ShowAd();
        StartCoroutine(LoadScene());
    }

    public void NextScene() => StartCoroutine(LoadScene(1));

    public void CertainScene(int sceneIndex)
    {
        currentScene = sceneIndex;
        StartCoroutine(LoadScene());
    }

    public void Home()
    {
        currentScene = 0;
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene(int level = 0)
    {
        yield return new WaitForSeconds(waitSeconds);
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(currentScene + level);
    }
}
