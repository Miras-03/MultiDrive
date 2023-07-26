using Health;
using UnityEngine;

public sealed class PlaneDamage : MonoBehaviour, ISoundable, IDamagable
{
    [SerializeField] private HealthController healthController;
    [SerializeField] private AudioSource damageSound;
    private const int damageValue = 5;

    private void OnCollisionEnter() => Damage();

    public void Sound(AudioSource sound) => sound.Play();

    public void Damage()
    {
        Sound(damageSound);
        healthController.TakeDamage(damageValue);
    }
}
