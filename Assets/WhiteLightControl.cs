using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLightControl : MonoBehaviour
{
    public GameObject player1, player2;
    public GameObject associatedLight;
    public bool isTrigger;

    public Sprite openSprite;
    public Sprite closeSprite;

    private bool isPlayer1InTrigger = false;
    private bool isPlayer2InTrigger = false;

    private bool isLightOn = false;

    private SpriteRenderer buttonSpriteRenderer;

    private void Start()
    {
        // SpriteRenderer bileþenini al
        buttonSpriteRenderer = GetComponent<SpriteRenderer>();
        // Baþlangýçta kapalý sprite'ý kullan
        buttonSpriteRenderer.sprite = closeSprite;
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (isPlayer1InTrigger && player1.CompareTag("Player1") && Input.GetKeyDown(KeyCode.T))
            {
                ToggleLight();
            }

            if (isPlayer2InTrigger && player2.CompareTag("Player2") && Input.GetKeyDown(KeyCode.L))
            {
                ToggleLight();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isPlayer1InTrigger = true;
            Debug.Log("Player 1 is in trigger");
        }
        else if (other.CompareTag("Player2"))
        {
            isPlayer2InTrigger = true;
            Debug.Log("Player 2 is in trigger");
        }

        if (isPlayer1InTrigger || isPlayer2InTrigger)
        {
            isTrigger = true;
            Debug.Log("isTrigger true");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isPlayer1InTrigger = false;
            Debug.Log("Player 1 left trigger");
        }
        else if (other.CompareTag("Player2"))
        {
            isPlayer2InTrigger = false;
            Debug.Log("Player 2 left trigger");
        }

        if (!isPlayer1InTrigger && !isPlayer2InTrigger)
        {
            isTrigger = false;
            Debug.Log("isTrigger false");
        }
    }

    private void ToggleLight()
    {
        isLightOn = !isLightOn;

        if (associatedLight != null)
        {
            associatedLight.SetActive(isLightOn);
            Debug.Log("Light is " + (isLightOn ? "on" : "off"));

            // Sprite'ý duruma göre deðiþtir
            buttonSpriteRenderer.sprite = isLightOn ? openSprite : closeSprite;
        }
    }
}
