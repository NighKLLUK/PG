using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 2f; // Prędkość ruchu
    public float rotationSpeed = 90f; // Prędkość obrotu

    private Vector3[] corners; // Tablica wierzchołków kwadratu
    private int currentCorner = 0; // aktualny wierzchołek
    private bool rotating = false; //czy obiekt jest w trakcie rotacji

    void Start()
    {
        Vector3 startPosition = transform.position; // Startowa pozycja
        corners = new Vector3[4];
        corners[0] = startPosition;
        corners[1] = startPosition + new Vector3(10f, 0, 0); // W prawo o 10 jednostek
        corners[2] = startPosition + new Vector3(10f, 0, -10f); // W dół
        corners[3] = startPosition + new Vector3(0, 0, -10f); // W lewo
    }

    void Update()
    {
        if (!rotating)
        {
            MoveTowardsNextCorner(); // Ruch w kierunku aktualnego wierzchołka
        }
    }

    void MoveTowardsNextCorner()
    {
        if (Vector3.Distance(transform.position, corners[currentCorner]) < 0.1f) // jeśli obiekt zbliżył się do wierzchołka
        {
            currentCorner = (currentCorner + 1) % corners.Length; //kolejny wierzchołek
            StartCoroutine(RotateTowardsNextDirection()); //rotacja kostki
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, corners[currentCorner], speed * Time.deltaTime); // przemieszczanie do wierzcholka
        }
    }
    IEnumerator RotateTowardsNextDirection()
    {
        rotating = true; // wykonanie rotacji
        Quaternion targetRotation = Quaternion.LookRotation(corners[currentCorner] - transform.position);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f) //stopniowy obrót
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        // Ustawiamy dokładnie docelową rotację
        transform.rotation = targetRotation;
        rotating = false; // Zakończenie rotacji
    }
}
