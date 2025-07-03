using UnityEngine;

public class Dust : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Gán tag "Player" cho RobotVacuum
        {
            Destroy(gameObject);
            GameManager.Instance.DustCollected(); // Báo cho GameManager
        }
    }
}
