using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float reloadTime = 4;
    float maxReloadTime;
    protected ObjectPool<EnemyBullet> bulletPool;
    private EnemyBullet bullet;
    private Transform gun;

    private void Awake()
    {
        bulletPool = FindFirstObjectByType<ObjectPool<EnemyBullet>>();
        gun = transform.Find("enemyGun");
        maxReloadTime = reloadTime;
    }

    private void Update()
    {
        Attack();
        reloadTime -= Time.deltaTime;
    }

    public void Attack()
    {
        if (reloadTime <= 0)
        {
            bullet = bulletPool.GetBullet();
            bullet.transform.position = gun.position;
            reloadTime = maxReloadTime;
        }
    }
}
