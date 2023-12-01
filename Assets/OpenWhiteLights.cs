using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class OpenWhiteLights : MonoBehaviour
{
    public Sprite openLight, closeLight;

    public Light2D [] whiteLights;

    private bool isOpening;
    private bool isLightOn;

    void Start()
    {
        isLightOn = false;
    }

    
    void Update()
    {
        if (isOpening)
        {
            // "E" tuþuna basýldýðýnda ýþýðý aç/kapat
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleLights();
            }
        }
    }

    private void ToggleLights()
    {
        isLightOn = !isLightOn;

        // Tüm ýþýklarý döngü ile kontrol et ve duruma göre aç veya kapat
        foreach (var light in whiteLights)
        {
            light.enabled = isLightOn;

            // Eðer sprite deðiþtirmek istiyorsanýz, aþaðýdaki satýrý kullanabilirsiniz.
           // light.sprite = isLightOn ? openLightSprite : closeLightSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            isOpening = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            isOpening = false;
        }
    }
}
