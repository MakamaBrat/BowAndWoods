using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLevel : MonoBehaviour
{
    public Transform[] levels;
    private int currentLevelIndex = 0; // индекс текущего уровня

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(LongRecreate());
    }

    public void RecreateLevel()
    {
        
        var k = FindAnyObjectByType<Level>();
  
        if (k != null)
        {
           Destroy(k.gameObject);
        }

 
        if (levels.Length == 0) return;

        Instantiate(levels[currentLevelIndex],
            new Vector3(transform.position.x, transform.position.y + 13, transform.position.z),
            Quaternion.identity,
            transform);

        // Переходим к следующему уровню (по кругу)
        currentLevelIndex = (currentLevelIndex + 1) % levels.Length;
    }
    
    public void makeSecond()
    {
        StopAllCoroutines();
        StartCoroutine(LongRecreate2());
    }
    IEnumerator LongRecreate()
    {
        yield return new WaitForSeconds(0.01f);
        RecreateLevel();
    }

    IEnumerator LongRecreate2()
    {
        yield return new WaitForSeconds(1f);
        RecreateLevel();
    }
}
