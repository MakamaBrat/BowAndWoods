using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXRandomActivate1 : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject firework;
    private void OnEnable()
    {
      

    }

    public void makeEffect()
    {
        Instantiate(firework, transform.position, Quaternion.identity, transform);
    }
}
