using System;
using UnityEngine;

namespace Vehicle
{
    public class Plane : Vehicle
    {
        [SerializeField] private FloatingJoystick joystick;

        private float horizontalInput;
        private float verticalInput;

        private float yaw;
        private float pitch;
        private float roll;

        private const float planeSpeed = PlaneData.planeSpeed;
        private float smoothSpeed = PlaneData.smoothSpeed;

        private const float yawAmount = PlaneData.yawAmount;
        private const float pitchAmount = PlaneData.pitchAmount;
        private const float rollAmount = PlaneData.rollAmount;

        private float currentYawVelocity;
        private float currentPitchVelocity;
        private float currentRollVelocity;

        private void OnEnable()
        {
            yaw = 0f;
            currentYawVelocity = 0f;
            currentPitchVelocity = 0f;
            currentRollVelocity = 0f;
        }

        public override void Move() => transform.Translate(transform.forward * planeSpeed * Time.fixedDeltaTime);

        public override void Control()
        {
            InputOfJoystick();
            ControlSetting();
        }

        private void InputOfJoystick()
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }

        private void ControlSetting()
        {
            yaw = Mathf.SmoothDamp(yaw, horizontalInput * yawAmount, ref currentYawVelocity, smoothSpeed);
            pitch = Mathf.SmoothDamp(pitch, verticalInput * pitchAmount, ref currentPitchVelocity, smoothSpeed);
            roll = Mathf.SmoothDamp(roll, -horizontalInput * rollAmount, ref currentRollVelocity, smoothSpeed);

            transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
        }
    }
}
