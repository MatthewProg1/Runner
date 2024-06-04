using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonstersPool : MonoBehaviour
{
    public ObjectPool<GameObject> pool { get; private set; }

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private LevelController levelController;

    private Vector3 startPoint;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroyElement, false, 10, 20);
    }

    public void SetStartPoint(Vector3 startPount)
    {
        this.startPoint = startPount;
    }

    private GameObject OnCreate()
    {
        var el = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], levelController.ReturnElementParent());
        el.transform.position = startPoint;
        return el;
    }

    private void OnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = startPoint;
    }

    private void OnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyElement(GameObject obj)
    {
        Destroy(obj.gameObject);
    }
}
