using UnityEngine;

public class LerpExample : MonoBehaviour
{
    public Transform target;  // Obiekt, który będzie śledzony
    public float lerpSpeed = 5.0f;  // Szybkość

    void Update()
    {
        // Mathf.Lerp dla osi Y
        float newPositionY = Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime * lerpSpeed);

        // Ustawienie nowej pozycji obiektu śledzącego
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
