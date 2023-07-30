using UnityEngine;
using VehicleOption;

public sealed class SetEngineSound : MonoBehaviour
{
    [SerializeField] private Car car;

    [Space(10)]
    [Header("VehicleSounds")]
    [SerializeField] private AudioSource carEngine;
    [SerializeField] private AudioSource planeEngine;

    private bool isPlane;

    public void EnableSounds()
    {
        isPlane = car.isPlane;

        if (!isPlane)
            carEngine.Play();
        else
            planeEngine.Play();
    }

    public void DisableSounds()
    {
        carEngine.Stop();
        planeEngine.Stop();
    }
}
