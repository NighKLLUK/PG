using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private float verticalRotation = 0f;
    void Start()
    {
         // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Obrót wokół osi Y (obracanie gracza)
        player.Rotate(Vector3.up * mouseXMove);

        // Obrót wokół osi X
        verticalRotation -= mouseYMove;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);  // Ograniczenie kąta nachylenia do -90/+90 stopni
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
