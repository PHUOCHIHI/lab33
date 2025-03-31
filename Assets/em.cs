using UnityEngine;

public class CircleGroupRotator : MonoBehaviour
{
    [Header("Vòng 1")]
    public Transform circle1;
    public float speed1 = 100f;
    public bool clockwise1 = true;

    [Header("Vòng 2")]
    public Transform circle2;
    public float speed2 = 100f;
    public bool clockwise2 = false;

    [Header("Vòng 3")]
    public Transform circle3;
    public float speed3 = 100f;
    public bool clockwise3 = true;

    void Update()
    {
        // Xoay vòng 1
        if (circle1 != null)
        {
            float direction1 = clockwise1 ? -1f : 1f;
            circle1.Rotate(0, 0, direction1 * speed1 * Time.deltaTime);
        }

        // Xoay vòng 2
        if (circle2 != null)
        {
            float direction2 = clockwise2 ? -1f : 1f;
            circle2.Rotate(0, 0, direction2 * speed2 * Time.deltaTime);
        }

        // Xoay vòng 3
        if (circle3 != null)
        {
            float direction3 = clockwise3 ? -1f : 1f;
            circle3.Rotate(0, 0, direction3 * speed3 * Time.deltaTime);
        }
    }
}
