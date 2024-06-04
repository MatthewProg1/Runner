using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElement : MonoBehaviour
{
    [SerializeField] private float speed;
    private LevelController levelController;
    private SpeedController speedController;

    private void OnEnable()
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if(transform.position.z < -220)
        {
            levelController.ReleseToPool(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            levelController.SpawnElement();
        }
    }

    public void SetLevelController(LevelController levelController)
    {
        this.levelController = levelController;
        SetSpeedController();
    }

    public LevelController ReturnLevelController()
    {
        return levelController;
    }

    private void SetSpeedController()
    {
        speedController = levelController.ReturnSpeedController();
    }

    private void OnDisable()
    {

        speed = speedController.ReturnCurrentSpeed();

        Debug.Log(speed);
    }
    


}
