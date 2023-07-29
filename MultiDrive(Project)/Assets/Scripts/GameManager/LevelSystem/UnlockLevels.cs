using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    const string unlockText = "UnlockedLevel";

    private void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt(unlockText, 1);

        foreach (Button button in buttons)
            button.interactable = false;

        for (int i = 0; i < unlockedLevel; i++)
            buttons[i].interactable = true;
    }
}
