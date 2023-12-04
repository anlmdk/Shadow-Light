using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteractive : MonoBehaviour
{
    public Transform[] doors;
    private int beforeDoorIndex = -1; // Ba?lang?çta hiç kap? seçilmemi? durumunda

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

            // Karakterin pozisyonunu seçilen kap?n?n pozisyonuna ayarla
            transform.position = selectedDoor.position;

            // Seçilen kap?y? bir sonraki i?leme geçmeden önce sakla
            beforeDoorIndex = randomIndex;

            Debug.Log("Rastgele olarak seçilen kap?ya ???nland?: " + selectedDoor.name);
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