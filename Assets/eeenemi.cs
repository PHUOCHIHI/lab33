using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float angularSpeed = 90f;

    void Update()
    {
        if (centerPoint != null)
        {
            transform.RotateAround(centerPoint.position, Vector3.forward, angularSpeed * Time.deltaTime);
        }
    }
}
