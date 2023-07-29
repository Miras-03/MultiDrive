using UnityEngine;

public sealed class ManageGame : MonoBehaviour
{
    public void PauseGame() => Time.timeScale = 0;
    public void PlayGame() => Time.timeScale = 1;
}
