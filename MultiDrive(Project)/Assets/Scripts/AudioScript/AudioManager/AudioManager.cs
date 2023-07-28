using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Image[] images;
    private bool isAudioEnabled = false;

    private void Start() => SwapButtons();

    public void SwitchAudio()
    {
        isAudioEnabled = !isAudioEnabled;

        PauseAudioListener(isAudioEnabled);
        SwapButtons(isAudioEnabled);
    }

    private void PauseAudioListener(bool isAudioEnabled) => AudioListener.pause = isAudioEnabled;

    private void SwapButtons(bool isAudioEnabled = false)
    {
        images[0].enabled = !isAudioEnabled;
        images[1].enabled = isAudioEnabled;
    }
}
