using UnityEngine;
using UnityEngine.UI;

public sealed class AudioManager : MonoBehaviour
{
    [SerializeField] Image[] images;
    private bool isAudioEnabled = false;
    private const string enabledText = "EnabledSound";

    private void Start()
    {
        isAudioEnabled = PlayerPrefs.GetInt(enabledText, 0) == 1;

        PauseAudioListener(isAudioEnabled);
        SwapButtons(isAudioEnabled);
    }

    public void SwitchAudio()
    {
        isAudioEnabled = !isAudioEnabled;

        PlayerPrefs.SetInt(enabledText, isAudioEnabled ? 1 : 0);
        PlayerPrefs.Save();

        PauseAudioListener(isAudioEnabled);
        SwapButtons(isAudioEnabled);
    }

    private void PauseAudioListener(bool isAudioEnabled) => AudioListener.pause = isAudioEnabled;

    private void SwapButtons(bool isAudioEnabled)
    {
        images[0].enabled = !isAudioEnabled;
        images[1].enabled = isAudioEnabled;
    }
}