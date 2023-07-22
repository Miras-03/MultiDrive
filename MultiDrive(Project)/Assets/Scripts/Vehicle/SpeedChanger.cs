using UnityEngine;

namespace VehicleOption
{
    public class SpeedChanger : MonoBehaviour, ISpeedChanger
    {
        [SerializeField] private Car car;

        [SerializeField] private float speed = 40f;
        private const float lowSteerAngle = 10f;

        private void OnTriggerEnter()
        {
            DecreaseSteerAngle();
            ChangeSpeed(speed);
        }

        private void DecreaseSteerAngle() => car.steerAngle = lowSteerAngle;

        public void ChangeSpeed(float speed)
        {
            car.moveSpeed = speed;
            car.maxSpeed = speed;
        }
    }
}