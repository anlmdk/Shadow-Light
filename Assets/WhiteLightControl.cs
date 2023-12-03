using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLightControl : MonoBehaviour
{
    public GameObject player1, player2;
    public GameObject associatedLight;
    public bool isTrigger;

    private bool isLightOn = false;

    private void Update()
    {
        if (isTrigger)
        {
            if (player1.CompareTag("Player1"))
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    // T tuþuna basýldýðýnda, ýþýk durumunu tersine çevir
                    isLightOn = !isLightOn;

                    // Iþýðý duruma göre aç veya kapat
                    if (isLightOn)
                    {
                        ActivateLight();
                    }
                    else
                    {
                        DeactivateLight();
                    }
                }
            }
            else if (player2.CompareTag("Player2"))
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    // K tuþuna basýldýðýnda, ýþýk durumunu tersine çevir
                    isLightOn = !isLightOn;

                    // Iþýðý duruma göre aç veya kapat
                    if (isLightOn)
                    {
                        ActivateLight();
                    }
                    else
                    {
                        DeactivateLight();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            isTrigger = true;
            Debug.Log("isTrigger true");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            isTrigger = false;
            Debug.Log("isTrigger false");
        }
    }

    private void ActivateLight()
    {
        if (associatedLight != null)
        {
            associatedLight.SetActive(true);
            Debug.Log("Light on");
        }
    }

    private void DeactivateLight()
    {
        if (associatedLight != null)
        {
            associatedLight.SetActive(false);
            Debug.Log("Light off");
        }
    }
}
