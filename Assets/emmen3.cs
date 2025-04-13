using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Transform centerPoint; // Tâm để xoay quanh
    public float speed = 50f;     // Tốc độ xoay

    void Update()
    {
        // Xoay quanh trục Z (2D)
        transform.RotateAround(centerPoint.position, Vector3.forward, -speed * Time.deltaTime);
    }
}
