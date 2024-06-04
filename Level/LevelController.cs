using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour 
{
    [SerializeField] private MoveElement elementController;

    [SerializeField] private Pool pool;

    //[SerializeField] private MonstersPool poolMonsters;

    //private Vector3 startPoint;

    private Transform elementParent;
    private MoveElement startElement;

    [SerializeField] private SpeedController speedController;

    private void Start()
    {
        SpawnElement();
        startElement.gameObject.transform.position -= new Vector3(0, 0, 170);
    }

    public void SpawnElement()
    {
        startElement = pool.pool.Get();
    }

    public void ReleseToPool(MoveElement moveElement)
    {
        pool.pool.Release(moveElement);
    }

    public SpeedController ReturnSpeedController()
    {
        return speedController;
    }

    //public void ReleseToPoolEnemy(GameObject gameObject)
    //{
    //    poolMonsters.pool.Release(gameObject);
    //}


    public Transform ReturnElementParent()
    {
        return elementParent;
    }
}
