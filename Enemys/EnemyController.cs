using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Animator animator;

    private ElementController elementController;


    private Collider collider;
    private void Awake()
    {
       collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        collider.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            Died();
        }
        else if (collision.gameObject.TryGetComponent<ArrowController>(out var arrow))
        {
            arrow.Died();
            Died();
        }
    }

    private void Died()
    {
        GetComponent<BoxCollider>().enabled = false;
        animator.SetTrigger("Died");
    //    elementController.ReleaseMonster(gameObject);
        Debug.Log("Argh...");
    }

    //public void SetElementController(ElementController elementController)
    //{
    //    this.elementController = elementController;
    //}
}
