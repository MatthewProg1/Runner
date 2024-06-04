using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{

    [SerializeField] private float startSpeed;
    private WaitForSeconds waitTime = new WaitForSeconds(10);
   
    void Start()
    {
        StartCoroutine(SpeedUpdate());
    }

    private IEnumerator SpeedUpdate()
    {
        yield return waitTime;
        startSpeed += 1f;
        StartCoroutine(SpeedUpdate());
    }

    public float ReturnCurrentSpeed()
    {
        return startSpeed;
    }


}
