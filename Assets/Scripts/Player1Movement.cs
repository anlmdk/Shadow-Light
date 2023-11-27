using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            StartCoroutine(MoveCharacter(Vector3.left));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            StartCoroutine(MoveCharacter(Vector3.right));
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
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
