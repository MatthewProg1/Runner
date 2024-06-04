using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private WaitForSeconds waitTime = new WaitForSeconds(0.05f);
    void Start()
    {
        StartCoroutine(Rotate());
    }

   private IEnumerator Rotate()
    {
        while (true)
        {
            yield return waitTime;
            transform.Rotate(0, 7, 0);
        }
    }

    public void StopRotate()
    {
        StopCoroutine(Rotate());
        gameObject.SetActive(false);
    }
}
