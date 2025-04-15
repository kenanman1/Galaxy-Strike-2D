using System.Collections;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected ObjectPool<EnemyBullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();
        bulletPool = FindFirstObjectByType<ObjectPool<EnemyBullet>>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * speed;
    }

    public override IEnumerator ReturnBulletToPool()
    {
        yield return new WaitForSeconds(destroyTime);
        bulletPool.ReturnBullet(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().DecreaseHealth(damage);
            bulletPool.ReturnBullet(this);
        }
    }
}
