using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : MonoBehaviour
{

    [SerializeField] private GameObject tableSkil;

   [SerializeField] private Dictionary<string, int> skilsValue = new Dictionary<string, int>()
    {
        { "Fast", 1 },
        { "Force", 1 },
        { "Dexterity", 1 },
        { "Luck", 1 },
    }; 

    public void OpenSkilsTable()
    {
        tableSkil.SetActive(true);
    }

    public void AddSkil(string key)
    {
        skilsValue[key] += 1;
        tableSkil.SetActive(false);
    }
}
