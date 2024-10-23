using UnityEngine;

public class SmoothDampExample : MonoBehaviour
{
    public Transform target;  // Obiekt, który będzie śledzony
    public float smoothTime = 0.3f;  // wygładzanie ruchu
    private float yVelocity = 0.0f;  // Zmienna, która przechowuje aktualną prędkość Y

    void Update()
    {
        // Mathf.SmoothDamp dla osi Y
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        
        // Ustawienie nowej pozycji obiektu śledzącego (Follower)
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
