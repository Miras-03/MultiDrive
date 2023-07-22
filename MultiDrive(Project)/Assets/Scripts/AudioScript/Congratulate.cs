using UnityEngine;
using System.Collections.Generic;

public class Congratulate : MonoBehaviour, ISoundable
{
    [SerializeField] private List<AudioSource> congratulateSounds;

    private void OnTriggerEnter()
    {
        foreach (AudioSource source in congratulateSounds)
            Sound(source);
    }

    public void Sound(AudioSource sound) => sound.Play();
}
