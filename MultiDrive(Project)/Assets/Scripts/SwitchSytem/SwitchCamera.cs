using UnityEngine;
using CameraOption;

namespace SwitchOption
{
    public sealed class SwitchCamera : MonoBehaviour, ISwitchable
    {
        [SerializeField] private CameraManager cameraManager;

        public void SwitchToCar() => cameraManager.MoveCameraCloser();
        public void SwitchToPlane() => cameraManager.MoveCameraAway();
    }
}