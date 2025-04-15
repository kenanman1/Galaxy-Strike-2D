using System.Collections;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected ObjectPool<PlayerBullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();
        bulletPool = FindFirstObjectByType<ObjectPool<PlayerBullet>>();
        gun = GameObject.Find("playerGun").transform;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.up * speed;
    }

    public override IEnumerator ReturnBulletToPool()
    {
        yield return new WaitForSeconds(destroyTime);
        bulletPool.ReturnBullet(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().DecreaseHealth(damage);
            bulletPool.ReturnBullet(this);
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        transform.position = gun.position;
        transform.rotation = gun.rotation;
    }
}
