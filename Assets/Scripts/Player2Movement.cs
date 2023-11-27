using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private bool isMoving = false;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMoving = true;
            StartCoroutine(MoveCharacter(Vector3.left));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMoving = true;
            StartCoroutine(MoveCharacter(Vector3.right));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMoving = false;
        }
    }

    IEnumerator MoveCharacter(Vector3 direction)
    {
        while (isMoving)
        {
            transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
    }
}
