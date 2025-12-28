using System.Collections;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;

    [Header("Lifetime")]
    [SerializeField] private float lifeTime = 3f;
     GameManager gameManager;
    private float timer;
    bool go;
    Transform tr;
    private void OnEnable()
    {
        timer = 0f;
      gameManager=  FindAnyObjectByType<GameManager>();
        go = false;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
    private void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;


        timer += Time.deltaTime;
        if (timer >= lifeTime && go==false)
        {
            gameManager.PlayMiss();
        
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Purpose")
        {
            
            StopAllCoroutines();
            go = true;
            StartCoroutine(stoperMethod());
            tr = collision.transform;
            gameManager.AddScore(1);
            FindAnyObjectByType<RandomizeLevel>().makeSecond();
            FindAnyObjectByType<FXRandomActivate1>().makeEffect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    IEnumerator stoperMethod()
    {
        yield return new WaitForSeconds(0.15f);
        transform.parent = tr;
        speed = 0;
    }

}
