using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private ArrowPool arrowPool;
    [SerializeField] private float speed;

    private void Start()
    {
        Invoke(nameof(Died), 4);
    }


    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }


    public void Died()
    {
        arrowPool.pool.Release(this);  
    }

    public void SetArrowPool(ArrowPool arrowPool)
    {
        this.arrowPool = arrowPool;
    }
}
