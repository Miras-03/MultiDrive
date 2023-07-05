using UnityEngine;

public class Cube : MonoBehaviour
{
    private float speed = 5f;
    private Transform cubeTransform;

    private void Start()
    {
        cubeTransform = transform;
    }

    public void Move()
    {
        cubeTransform.Translate(transform.forward * speed * Time.fixedDeltaTime);
    }
}
