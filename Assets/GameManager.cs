using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;

    public int startingSeconds = 60; // Starting seconds for the countdown

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
    }

    IEnumerator Countdown()
    {
        int remainingSeconds = startingSeconds;

        while (remainingSeconds >= 0)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second

            // Dakika ve saniyeyi ayrý ayrý hesapla
            int dakika = remainingSeconds / 60;
            int saniye = remainingSeconds % 60;

            // Zamaný TextMeshProUGUI'ye yazdýr
            timeText.text = dakika.ToString("D2") + ":" + saniye.ToString("D2");

            // Decrease the remaining seconds by 1
            remainingSeconds--;

            // Print the time to the console
            Debug.Log(remainingSeconds.ToString("D2"));


        }

        // Optionally print a message when the countdown is complete
        Debug.Log("Countdown finished!");
        if (remainingSeconds == -1)
        {
            remainingSeconds = 0;
            GameOver("Shadow Win");
        }
    }
    public void Reset()
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
