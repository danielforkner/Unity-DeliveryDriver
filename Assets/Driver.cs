using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    float currentMoveSpeed = 20f;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Boost")
        {
            currentMoveSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        currentMoveSpeed = slowSpeed;
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        if (moveAmount == 0) 
        {
            steerAmount = 0;
        }
        if (moveAmount < 0)
        {
            steerAmount *= -1;
        }
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
