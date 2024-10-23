using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab Cube
    public int numberOfCubes = 10; // Liczba obiektów do wygenerowania
    public float planeSize = 10f;  // Rozmiar płaszczyzny

    private List<Vector3> occupiedPositions = new List<Vector3>(); // Lista zajętych miejsc

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition(); //losowe pozycje
            Instantiate(cubePrefab, randomPosition, Quaternion.identity); //ułożenie obiektów
        }
    }

    // generowanie losowej pozycji:
    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        do
        {
            float randomX = Random.Range(-planeSize / 2, planeSize / 2);
            float randomZ = Random.Range(-planeSize / 2, planeSize / 2);

            // Ustawiamy Y na 0, bo płaszczyzna leży na wysokości 0
            randomPosition = new Vector3(Mathf.Round(randomX), 0.5f, Mathf.Round(randomZ)); // 0.5f Y to środek sześcianu
        }
        while (occupiedPositions.Contains(randomPosition));

        occupiedPositions.Add(randomPosition); // Dodajemy wygenerowaną pozycję do zajętych

        return randomPosition;
    }
}
