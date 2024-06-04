using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{
    [SerializeField] private List<GameObject> furniture = new List<GameObject>();

    [SerializeField] private MoveElement moveElement;
    [SerializeField] private List<GameObject> enemys= new List<GameObject>();

    private void Start()
    {
        SpawnEnemys();
     
    }

    

    private void SpawnEnemys()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Random.Range(0, 100) < 90)
            {
                SpawnMonster();
            }
            else
            {
                var mon = Instantiate(furniture[furniture.Count - 1], transform);
                mon.transform.position = new Vector3(CountPosX(), 0, CountPosZ());
                enemys.Add(mon);
            }
        }
    }


    private float CountPosX()
    {
        var a = 0f;
        switch (Random.Range(0, 3))
        {
            case 0:
                a = transform.position.x - 11f;
                break;
            case 1:
                a = transform.position.x; 
                break;
            case 2:
                a = transform.position.x + 11f;
                break;
        }
        return a;
    }

    private float CountPosZ()
    {
        var a = 0f;
        switch (Random.Range(0, 3))
        {
            case 0:
                a = transform.position.z - 15f; 
                break;
            case 1:
                a = transform.position.z;
                break;
            case 2:
                a = transform.position.z + 15f;
                break;
        }
        return a;
    }

    private void OnDisable()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].gameObject.transform.position = new Vector3(CountPosX(), -0.1f, CountPosZ());
        }
    }

    private void SpawnMonster()
    {
        var mon = Instantiate(furniture[Random.Range(0, furniture.Count - 2)], transform);
        mon.transform.position = new Vector3(CountPosX(), 0, CountPosZ());
        enemys.Add(mon);
    }
}
