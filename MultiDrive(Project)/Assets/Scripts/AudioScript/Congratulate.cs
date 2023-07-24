using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Congratulate : MonoBehaviour, ISoundable
{
    [SerializeField] private List<AudioSource> congratulateSounds;

    private void OnTriggerEnter()
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
