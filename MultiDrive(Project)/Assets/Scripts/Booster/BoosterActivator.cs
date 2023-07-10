using UnityEngine;
using Zenject;

public sealed class BoosterActivator : MonoBehaviour
{
    [Inject]
    private IEnhancable enhance;

    private void OnCollisionEnter(Collision collision) => enhance.ActivateForce();
}
