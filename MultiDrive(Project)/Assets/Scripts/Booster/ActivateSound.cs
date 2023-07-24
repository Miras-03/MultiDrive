using UnityEngine;

public class ActivateSound : MonoBehaviour, ISoundable
{
    [SerializeField] private AudioSource activateSound;
    
    private void OnTriggerEnter() => Sound(activateSound);
    public void Sound(AudioSource sound) => sound.Play();
}
