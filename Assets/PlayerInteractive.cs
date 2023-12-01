using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerInteractive : MonoBehaviour
{
    public Transform[] doors;
    private int beforeDoorIndex = -1; // Baþlangýçta hiç kapý seçilmemiþ durumunda

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

           // Karakterin pozisyonunu seçilen kapýnýn pozisyonuna ayarla
           transform.position = selectedDoor.position;

           // Seçilen kapýyý bir sonraki iþleme geçmeden önce sakla
           beforeDoorIndex = randomIndex;

           Debug.Log("Rastgele olarak seçilen kapýya ýþýnlandý: " + selectedDoor.name);
        }
        else
        {
           Debug.LogError("Kapý dizisi boþ!");
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            RandomDoor();
        }
    }
}