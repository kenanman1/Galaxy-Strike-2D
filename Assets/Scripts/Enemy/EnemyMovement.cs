using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -6)
            enemySpawner.ReturnEnemy(gameObject);
    }
}
