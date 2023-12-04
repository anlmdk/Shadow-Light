using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteractive : MonoBehaviour
{
    public Transform[] doors;
    private int beforeDoorIndex = -1; // Ba?lang?�ta hi� kap? se�ilmemi? durumunda

    public void RandomDoor()
    {
        if (doors.Length > 0)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, doors.Length);
            }
            while (randomIndex == beforeDoorIndex);

            Transform selectedDoor = doors[randomIndex];

            // Karakterin pozisyonunu se�ilen kap?n?n pozisyonuna ayarla
            transform.position = selectedDoor.position;

            // Se�ilen kap?y? bir sonraki i?leme ge�meden �nce sakla
            beforeDoorIndex = randomIndex;

            Debug.Log("Rastgele olarak se�ilen kap?ya ???nland?: " + selectedDoor.name);
        }
        else
        {
            Debug.LogError("Kap? dizisi bo?!");
        }
    }
    public void player1DoorControl()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomDoor();
        }
    }
    public void player2DoorControl()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RandomDoor();
        }
    }
}