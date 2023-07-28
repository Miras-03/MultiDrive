using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class Congratulate : MonoBehaviour, ISoundable, IFinishObserver
{
    [SerializeField] private List<AudioSource> congratulateSounds;

    public void Execute()
    {
        foreach (AudioSource source in congratulateSounds)
            StartCoroutine(PlaySound(source));
    }

    public void Sound(AudioSource sound) => sound.Play();

    private IEnumerator PlaySound(AudioSource sound)
    {
        yield return new WaitForSeconds(1.5f);
        Sound(sound);
    }
}
