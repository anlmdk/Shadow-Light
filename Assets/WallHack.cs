using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHack : MonoBehaviour
{
    public GameObject player1;
    public float startX, lastX;

    public Collider2D collider1, collider2; 

    void Update()
    {
        float player1X = player1.transform.position.x;

        // Sa�dan girince soldan ��kma
        if (player1X < lastX)
        {
            player1.transform.position = new Vector3(startX, player1.transform.position.y, player1.transform.position.z);
        }
        // Soldan girince sa�dan ��kma
        else if (player1X > startX)
        {
            player1.transform.position = new Vector3(lastX, player1.transform.position.y, player1.transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            collider1.isTrigger = true;
            collider2.isTrigger = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            collider1.isTrigger = false;
            collider2.isTrigger = false;
        }
    }
}
