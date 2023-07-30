using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    const string UnlockedLevel = nameof(UnlockedLevel);

    private void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt(UnlockedLevel, 1);

        foreach (Button button in buttons)
            button.interactable = false;

        for (int i = 0; i < unlockedLevel; i++)
            buttons[i].interactable = true;
    }
}
