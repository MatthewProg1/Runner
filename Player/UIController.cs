using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private Image clock;

    public void Died()
    {
        playAgainButton.gameObject.SetActive(true); 
        exitButton.gameObject.SetActive(true);
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Recharge()
    {
        StartCoroutine(ChangeFiledClock());
    }

    private IEnumerator ChangeFiledClock()
    {
        clock.fillAmount = 1;
        clock.gameObject.SetActive(true);   
        for (int i = 0; i < 100; i++)
        {
            clock.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        clock.gameObject.SetActive(false);
    }
}
