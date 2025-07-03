using UnityEngine;

public class Dust : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // G�n tag "Player" cho RobotVacuum
        {
            Destroy(gameObject);
            GameManager.Instance.DustCollected(); // B�o cho GameManager
        }
    }
}
