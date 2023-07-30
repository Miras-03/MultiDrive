using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCurrentLevel : MonoBehaviour, IFinishObserver
{
    const string ReachedIndex = nameof(ReachedIndex);
    const string UnlockedLevel = nameof(UnlockedLevel);

    public void Execute() => UnlockCurrentLevel();
    
    private void UnlockCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt(ReachedIndex);

        if(currentLevel >= reachedIndex)
        {
            PlayerPrefs.SetInt(ReachedIndex, currentLevel + 1);
            PlayerPrefs.SetInt(UnlockedLevel, currentLevel + 1);

            PlayerPrefs.Save();
        }
    }
}
