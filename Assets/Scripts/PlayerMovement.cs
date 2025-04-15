using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float force = 5;
    ObjectPool<PlayerBullet> bulletPool;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speedY;
    private float speedX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPool = FindFirstObjectByType<ObjectPool<PlayerBullet>>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speedX * force, speedY * force);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

        speedX = Mathf.Abs(movement.x) < 0.1f ? 0 : Mathf.Sign(movement.x);
        speedY = Mathf.Abs(movement.y) < 0.1f ? 0 : Mathf.Sign(movement.y);
    }

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            bulletPool.GetBullet();
        }
    }
}
