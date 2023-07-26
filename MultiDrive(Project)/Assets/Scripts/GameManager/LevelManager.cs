using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections;

public class LevelManager : MonoBehaviour
{
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

    public void RestartScene() => StartCoroutine(LoadScene());

    public void NextScene() => StartCoroutine(LoadScene(1));

    private IEnumerator LoadScene(int level = 0)
    {
        yield return new WaitForSeconds(waitSeconds);
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(currentScene + level);
    }
}
