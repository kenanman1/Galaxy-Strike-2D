using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] float hp;

    public virtual void DecreaseHealth(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
