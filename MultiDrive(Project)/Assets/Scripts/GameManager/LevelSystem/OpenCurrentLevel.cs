using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCurrentLevel : MonoBehaviour, IFinishObserver
{
    const string reachedText = "ReachedIndex";
    const string unlockText = "UnlockedLevel";

    public void Execute() => UnlockCurrentLevel();
    
    private void UnlockCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt(reachedText);

        if(currentLevel >= reachedIndex)
        {
            PlayerPrefs.SetInt(reachedText, currentLevel + 1);
            PlayerPrefs.SetInt(unlockText, currentLevel + 1);

            PlayerPrefs.Save();
        }
    }
}
