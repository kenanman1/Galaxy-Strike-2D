using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] float maxShield = 5;
    float shield = 5;

    private void Start()
    {
        shield = maxShield;
    }

    private void Update()
    {
        shield -= Time.deltaTime;    
    }

    public override void DecreaseHealth(float damage)
    {
        if (shield <= 0)
        {
            LeanTween.alpha(gameObject, 0, 0.5f).setLoopPingPong(4);
            base.DecreaseHealth(damage);
            shield = maxShield;
        }
    }
}
