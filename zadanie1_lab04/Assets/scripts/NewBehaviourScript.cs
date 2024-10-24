using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int numberOfObjects = 10;  // liczba obiektów do wygenerowania
    public GameObject block;          // obiekt do generowania
    public Material[] materials;      // tablica materiałów
    private int objectCounter = 0;

    private float platformSizeX;      // rozmiar platformy w osi X
    private float platformSizeZ;      // rozmiar platformy w osi Z

    void Start()
    {
        // wymiary platformy
        platformSizeX = transform.localScale.x * 10;
        platformSizeZ = transform.localScale.z * 10;

        //losowanie pozycji
        List<int> pozycje_x = new List<int>(Enumerable.Range(-(int)platformSizeX / 2, (int)platformSizeX).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range(-(int)platformSizeZ / 2, (int)platformSizeZ).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));

        for (int i = 0; i < numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt()); //generowanie obiektow
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            // obiekt w losowej pozycji
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            // losowy material
            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            objectCounter++;
            yield return new WaitForSeconds(this.delay);  // opoznienie miedzy generowaniem kolejnych obiektow
        }

        StopCoroutine(GenerujObiekt());
    }
}
