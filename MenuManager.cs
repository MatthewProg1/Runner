using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text moneyText;

    private void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("SaveScoreGame").ToString();
        moneyText.text = PlayerPrefs.GetFloat("SaveMoneyGame").ToString();
      
    }
    public void ShowGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
