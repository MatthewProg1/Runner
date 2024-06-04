using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    [SerializeField] private PlayerController playerController;
    private WaitForSeconds waitTime = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(ScoreUpdate());
        playerController.died += UpdateNewScore;
    }

    private IEnumerator ScoreUpdate()
    {
        while (playerController.isAlive)
        {
            yield return waitTime;
            if (playerController.isAlive)
            {
                score++;
                Debug.Log(playerController.isAlive);
                scoreText.text = score.ToString();
            }
        }
    }

    private void UpdateNewScore()
    {
        var bestSc = PlayerPrefs.GetInt("SaveScoreGame");
        if(bestSc < score) 
        {
            PlayerPrefs.SetInt("SaveScoreGame", score);
        }
    }

    private void OnDestroy()
    {
        playerController.died -= UpdateNewScore;
    }
}
