using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour
{
    private float coolDown = 1;
    private float coolDownPrice = 250;
    private float money;
    private int levelProgress;
    [SerializeField]private Text textUpgrades;
    [SerializeField]private Text textPrice;
    [SerializeField]private Text textMoney;


    private void Start()
    {
        ReloadData();
       
    }

    public void UpdateCoolDown()
    {
        if (money >= coolDownPrice && coolDown > 0.2f)
        {
            money -= coolDownPrice;
            coolDownPrice += coolDownPrice * 1.5f;
            coolDown -= 0.1f;
            levelProgress++;
            SaveData();
            ReloadData();
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    

    private void ReloadData()
    {

        levelProgress = PlayerPrefs.GetInt("SaveLevelProgressGame");
        if(levelProgress == 0)
        {
            levelProgress = 1;
            PlayerPrefs.SetInt("SaveLevelProgressGamee", levelProgress);
        }

        coolDown = PlayerPrefs.GetFloat("SaveCoolDownGame");
        coolDownPrice = PlayerPrefs.GetFloat("SaveCoolDownPriceGame");
        if(coolDownPrice == 0)
        {
            coolDownPrice = 250f;
            PlayerPrefs.SetFloat("SaveCoolDownPriceGame", coolDownPrice);
        }
        textPrice.text = coolDownPrice.ToString() + "$";
        money = PlayerPrefs.GetFloat("SaveMoneyGame");
        textMoney.text = money.ToString();

        textUpgrades.text = levelProgress.ToString();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("SaveLevelProgressGame", levelProgress);
        PlayerPrefs.SetFloat("SaveCoolDownGame", coolDown);
        PlayerPrefs.SetFloat("SaveCoolDownPriceGame", coolDownPrice);
        PlayerPrefs.SetFloat("SaveMoneyGame", money);
    }


}
