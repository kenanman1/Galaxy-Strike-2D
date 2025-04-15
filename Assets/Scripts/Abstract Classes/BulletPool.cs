using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Bullet
{
    [SerializeField] private T prefab;
    [SerializeField] private int poolSize = 10;

    private Stack<T> pool = new();
    private Transform parent;

    private void Awake()
    {
        GameObject parentObj = new GameObject($"{typeof(T).Name}s");
        parent = parentObj.transform;

        for (int i = 0; i < poolSize; i++)
        {
            T instance = Instantiate(prefab, parent);
            instance.gameObject.SetActive(false);
            pool.Push(instance);
        }
    }

    public T GetBullet()
    {
        T instance;
        if (pool.Count > 0)
            instance = pool.Pop();
        else
            instance = Instantiate(prefab, parent);

        instance.gameObject.SetActive(true);
        return instance;
    }

    public void ReturnBullet(T instance)
    {
        instance.gameObject.SetActive(false);
        pool.Push(instance);
    }
}
