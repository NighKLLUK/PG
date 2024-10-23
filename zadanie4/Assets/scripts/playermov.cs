using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // Prędkość ruchu

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");// Odczytanie wartości wejścia dla osi X
        float moveZ = Input.GetAxis("Vertical"); // Odczytanie wartości wejścia dla osi Z
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);// Stworzenie wektora kierunku ruchu
        if (moveDirection.magnitude > 1) // Normalizowanie wektora
        {
            moveDirection.Normalize();
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime; // Przemieszczenie obiektu wzdłuż płaszczyzny
    }
}
