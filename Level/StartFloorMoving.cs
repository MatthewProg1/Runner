using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFloorMoving : MonoBehaviour
{
    private float speed = 15;

    void Start()
    {
        StartCoroutine(DestroyYourself());
    }


    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private IEnumerator DestroyYourself()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
