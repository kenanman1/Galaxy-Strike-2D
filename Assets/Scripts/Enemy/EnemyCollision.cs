using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private float damage;
    private Health playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerMovement>().GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth.DecreaseHealth(damage);
        }
    }
}
