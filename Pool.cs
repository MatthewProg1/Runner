using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    public ObjectPool<MoveElement> pool { get; private set; }

    [SerializeField] private MoveElement moveElementPrefab;
    [SerializeField] private LevelController levelController;

    private Vector3 startPoint = new Vector3(0, 0, 195);

    private void Awake()
    {
        pool = new ObjectPool<MoveElement>(OnCreate, OnGet, OnRelease, OnDestroyElement, false, 10, 20);
    }

    private MoveElement OnCreate()
    {
        var el = Instantiate(moveElementPrefab, transform);
        el.SetLevelController(levelController);
        return el;
    }

    private void OnGet(MoveElement obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = startPoint;
    }

    private void OnRelease(MoveElement obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyElement(MoveElement obj)
    {
        Destroy(obj.gameObject);
    }
}
