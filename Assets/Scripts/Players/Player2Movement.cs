using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private bool isMoving = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("isRunning", false);
        }
    }

    IEnumerator MoveCharacter(Vector3 direction)
    {
        while (isMoving)
        {
            // Hareket yönüne göre karakterin yönünü ayarla
            if (direction == Vector3.left && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (direction == Vector3.right && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("isRunning", true);
            yield return null;
        }
    }
}
