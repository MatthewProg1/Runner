using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheel : MonoBehaviour
{
    private WaitForSeconds wait = new WaitForSeconds(0.05f);

    void Start()
    {
        transform.rotation = Quaternion.Euler(90, 90, 90);
        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        while (true)
        {
            yield return wait;
            transform.Rotate(-5f, 0, 0);
        }
    }

 
}
