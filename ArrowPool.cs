using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowPool : MonoBehaviour
{
    public ObjectPool<ArrowController> pool { get; private set; }

    [SerializeField] private ArrowController arrowPrefab;

    private Vector3 startPoint = new Vector3(0, 0, 195);

    private void Awake()
    {
        pool = new ObjectPool<ArrowController>(OnCreate, OnGet, OnRelease, OnDestroyElement, false, 10, 20);
    }

    public void SetStartPoint(Vector3 startPoint)
    {
        this.startPoint = startPoint;
    }

    private ArrowController OnCreate()
    {
        var el = Instantiate(arrowPrefab, transform);
        el.transform.position = startPoint;
        el.SetArrowPool(this);
        return el;
    }

    private void OnGet(ArrowController obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = startPoint;
    }

    private void OnRelease(ArrowController obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyElement(ArrowController obj)
    {
        Destroy(obj.gameObject);
    }
}
