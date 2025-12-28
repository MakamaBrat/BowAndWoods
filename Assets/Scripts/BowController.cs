using UnityEngine;

public class BowController : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 50f;       // скорость вращения
    public float minAngle = -45f;           // минимальный угол по Z
    public float maxAngle = 45f;            // максимальный угол по Z
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float reloadTime = 1.5f;
    public Animator animator;
    private float reloadTimer = 0f;
    private bool rotatingRight = true;      // направление вращения
    public AudioSource bowAttack;
    public GameManager gameManager;
    void Update()
    {
        HandleRotation();
        HandleShooting();
    }

    void HandleRotation()
    {
        // Плавное колебание лука влево-вправо
        float rotationStep = rotationSpeed * Time.deltaTime;

        if (rotatingRight)
        {
            transform.Rotate(0, 0, rotationStep);
            if (transform.localEulerAngles.z >= maxAngle && transform.localEulerAngles.z < 180f)
            {
                rotatingRight = false;
            }
        }
        else
        {
            transform.Rotate(0, 0, -rotationStep);
            float angle = transform.localEulerAngles.z;
            if (angle > 180f) angle -= 360f; // конвертируем в -180..180
            if (angle <= minAngle)
            {
                rotatingRight = true;
            }
        }
    }

    void HandleShooting()
    {
        if (reloadTimer > 0)
            reloadTimer -= Time.deltaTime;

        if (Input.GetMouseButtonUp(0) && reloadTimer <= 0f)
        {
            SpawnArrow();
            animator.Play("BowAttack");
           
            reloadTimer = reloadTime;
        }
    }

    void SpawnArrow()
    {
        Instantiate(arrowPrefab, arrowSpawnPoint.position, transform.rotation,transform.parent.transform);
        gameManager.UseArrow();
        bowAttack.Play();
    }
}
