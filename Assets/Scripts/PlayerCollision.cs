using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }
}
