using UnityEngine;

namespace VehicleOption
{
    public class SpeedChanger : MonoBehaviour, ISpeedChanger
    {
        [SerializeField] private Car car;

        [SerializeField] private float speed = 40f;
        [SerializeField] private float steerAngle = 10f;

        private void OnTriggerEnter()
        {
            ChangeSteerAngle();
            ChangeSpeed(speed);
        }

        private void ChangeSteerAngle() => car.steerAngle = steerAngle;

        public void ChangeSpeed(float speed)
        {
            //car.moveSpeed = speed;
            car.maxSpeed = speed;
        }
    }
}