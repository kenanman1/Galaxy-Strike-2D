using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float damage = 25;
    [SerializeField] protected float destroyTime = 2;
    public Transform gun;
    protected Rigidbody2D rb;

    public abstract IEnumerator ReturnBulletToPool();

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual void OnEnable()
    {
        StartCoroutine(ReturnBulletToPool());
    }
}
