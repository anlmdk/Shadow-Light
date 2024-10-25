using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class RedLight : MonoBehaviour
{
    Light2D  redLight;
    public float burningTime = 2f; // I����n a��k kalma s�resi
    public float waitingTime = 1f; // I����n kapal� kalma s�resi

    void Start()
    {
        redLight = GetComponent<Light2D>();
        StartCoroutine(RedLightControl());
    }

    IEnumerator RedLightControl()
    {
        while (true)
        {
            redLight.enabled = true; // I���� a�
            yield return new WaitForSeconds(burningTime); // Belirtilen s�re boyunca beklet

            redLight.enabled = false; // I���� kapat
            yield return new WaitForSeconds(waitingTime); // Belirtilen s�re boyunca beklet
        }
    }
}
