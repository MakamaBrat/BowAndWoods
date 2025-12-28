using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Header("Movement")]
    public float baseSpeed = 2f;
    public float acceleration = 0.5f;
    public float maxSpeed = 6f;     // 🔥 максимальная скорость
    public float distance = 3f;

    private float currentSpeed;
    private float offset;
    private int direction = 1;
    private Vector3 startPos;

    private void OnEnable()
    {
        currentSpeed = baseSpeed;
        offset = 0f;
        direction = 1;
        startPos = transform.position;
    }

    private void Update()
    {
        // ускорение с ограничением
        currentSpeed = Mathf.Min(
            currentSpeed + acceleration * Time.deltaTime,
            maxSpeed
        );

        // считаем смещение, а не двигаем напрямую transform
        offset += direction * currentSpeed * Time.deltaTime;

        // отражение от границ БЕЗ телепорта
        if (offset > distance)
        {
            offset = distance - (offset - distance);
            direction = -1;
        }
        else if (offset < -distance)
        {
            offset = -distance - (offset + distance);
            direction = 1;
        }

        transform.position = startPos + Vector3.right * offset;
    }
}
