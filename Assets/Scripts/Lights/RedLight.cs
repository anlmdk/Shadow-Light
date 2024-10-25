using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class RedLight : MonoBehaviour
{
    Light2D  redLight;
    public float burningTime = 2f; // Iþýðýn açýk kalma süresi
    public float waitingTime = 1f; // Iþýðýn kapalý kalma süresi

    void Start()
    {
        redLight = GetComponent<Light2D>();
        StartCoroutine(RedLightControl());
    }

    IEnumerator RedLightControl()
    {
        while (true)
        {
            redLight.enabled = true; // Iþýðý aç
            yield return new WaitForSeconds(burningTime); // Belirtilen süre boyunca beklet

            redLight.enabled = false; // Iþýðý kapat
            yield return new WaitForSeconds(waitingTime); // Belirtilen süre boyunca beklet
        }
    }
}
