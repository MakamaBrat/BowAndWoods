using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXRandomActivate : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject firework;
    private void OnEnable()
    {
        var k = Random.Range(0,transforms.Length);

        foreach (Transform t in transforms)
        {
            t.gameObject.SetActive(false);
        }
        transforms[k].gameObject.SetActive(true);

    }

    public void makeEffect()
    {
        Instantiate(firework, transform.position, Quaternion.identity, transform.parent.transform);
    }
}
