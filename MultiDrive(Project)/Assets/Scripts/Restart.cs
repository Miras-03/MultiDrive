using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private int currentScene;

    private void Start() => currentScene = SceneManager.GetActiveScene().buildIndex;

    public void RestartGame() => SceneManager.LoadScene(currentScene);
}
