using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 2f; // publiczne pole speed
    private Vector3 startPosition;   // Pozycja startowa
    private Vector3 targetPosition;  // Pozycja docelowa
    private bool movingForward = true; //kierunek ruchu

    private float moveDistance = 10f; //odległośc na jaką kostka ma się poruszać

    void Start()
    {
        // Ustawienie pozycji startowej
        startPosition = transform.position;

        // Ustawienie pozycji docelowej
        targetPosition = startPosition + new Vector3(moveDistance, 0, 0); 
    }

    void Update()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Ruch w docelowym kierunku
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f) //sprawdzenie czy obiekt dotrł do celu
            {
                movingForward = false; // Zmiana kierunku na powrotny
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime); //ruch w kierunku pozycji startowej
            if (Vector3.Distance(transform.position, startPosition) < 0.001f) // sprawdzenie czy obiekt dotarł do stratowej pozycji
            {
                movingForward = true; // Zmiana kierunku
            }
        }
    }
}
