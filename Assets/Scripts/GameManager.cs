using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public GameObject bannerPanel;

    public int startingSeconds = 60; 

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI playerText;

    public Light2D allLights;

    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(Countdown());
        gameOverPanel.SetActive(false);
        InvokeRepeating("AutoSave", 15f, 15f);
    }

    public void AutoSave()
    {
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    IEnumerator Countdown()
    {
        int remainingSeconds = startingSeconds;

        while (remainingSeconds >= 0)
        {
            yield return new WaitForSeconds(1f);

            int minutes = remainingSeconds / 60;
            int second = remainingSeconds % 60;

            timeText.text = minutes.ToString("D2") + ":" + second.ToString("D2");

            remainingSeconds--;

            Debug.Log(remainingSeconds.ToString("D2"));


        }

        Debug.Log("Countdown finished!");
        if (remainingSeconds == -1)
        {
            remainingSeconds = 0;
            GameOver("Shadow Win");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
    public void GameOver(string winnerText)
    {
        allLights.intensity = 1;
        gameOverPanel.SetActive(true);
        playerText.text = winnerText;
    }
}
