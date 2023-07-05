using System;
using UnityEditor;
using UnityEngine;

namespace Vehicle
{
    public class Plane : Vehicle
    {
        [SerializeField] private FixedJoystick joystick;

        private const float planeSpeed = 5f;

        private float horizontalInput;
        private float verticalInput;

        private float yaw;
        private const float yawAmount = 20f;

        private float pitch;
        private float roll;

        private const float pitchAmount = 10;
        private const float rollAmount = 10;

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
            yaw += horizontalInput * yawAmount * Time.fixedDeltaTime;
            PitchSetting();
            RollSetting();
            YawSetting();
        }

        private void YawSetting() => transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward*roll);

        private void PitchSetting() => pitch = Mathf.Lerp(0, pitchAmount, Math.Abs(verticalInput)) * Mathf.Sign(verticalInput);

        private void RollSetting() => roll = Mathf.Lerp(0,rollAmount,Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
    }
}