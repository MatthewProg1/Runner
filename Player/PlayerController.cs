using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int pos = 1;

    [SerializeField] private float speed;

    private Vector3 targetMove;

    [SerializeField] private Transform attackPos;

    [SerializeField] private UIController uIController;

    public event Action died;

    [SerializeField] private bool canShoot;

    [SerializeField] private ArrowPool arrowPool;

    [SerializeField] SkillsController skillsController;

    private float coolDown;

    private int money;

    public bool isAlive { get; private set; } = true;
    
    private void Start()
    {
        targetMove = new Vector3(0, 0, -167);
        canShoot = true;
        coolDown = PlayerPrefs.GetFloat("SaveCoolDownGame");
        if(coolDown == 0)
        {
            coolDown = 1;
            PlayerPrefs.SetFloat("SaveCoolDownGame", coolDown);
        }
    }




    void Update()
    {
        if (transform.position != targetMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMove, Time.deltaTime * speed);
        }

        if (isAlive)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (pos == 0)
                    return;

                pos--;
                SwitchPos();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (pos > 1)
                    return;

                pos++;
                SwitchPos();
            }


            if (Input.GetKeyDown(KeyCode.Space) && canShoot)
            {
                arrowPool.SetStartPoint(attackPos.position);
                arrowPool.pool.Get();

                StartCoroutine(Recharge());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<CoinScript>(out var coin))
        {
            coin.StopRotate();
            money++;
            return;
        }
        if (collision.gameObject.tag != "Skil")
        {
            Died();
        }
        else
        {
            skillsController.OpenSkilsTable();
        }
    }

    public void PlusPos()
    {
        if (pos > 1)
            return;

        pos++;
        SwitchPos();
    }

    public void MinusPos()
    {
        if (pos == 0)
            return;

        pos--;
        SwitchPos();
    }

    private void SwitchPos()
    {
        switch (pos)
        {
            case 0:
                targetMove = new Vector3(-11, 0, -167);
                break;
            case 1:
                targetMove = new Vector3(0, 0, -167);
                break;
            case 2:
                targetMove = new Vector3(11, 0, -167);
                break;
        }

    }

    private IEnumerator Recharge()
    {
        canShoot = false;
        uIController.Recharge();
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

    private void Died()
    {
        uIController.Died();
        isAlive = false;
        var mon = PlayerPrefs.GetFloat("SaveMoneyGame");
        mon += money;
        PlayerPrefs.SetFloat("SaveMoneyGame", mon);
        died?.Invoke();
    }
}
