using UnityEngine;

public class Tunel : MonoBehaviour, IRotable
{
    private const float speed = 5f;

    private void FixedUpdate() => Rotate();

    public void Rotate() => transform.Rotate(0f, speed * Time.fixedDeltaTime, 0f);
}
