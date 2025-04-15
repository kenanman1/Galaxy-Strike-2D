using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<float> enemyWeights;
    private Stack<GameObject> enemyStack = new();
    private Transform enemiesParent;
    private float spawnTime = 2f;
    private float poolSize = 10f;

    private void Start()
    {
        GameObject parentObj = new GameObject("Enemies");
        enemiesParent = parentObj.transform;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(GetWeightedRandomEnemy(), enemiesParent);
            enemy.SetActive(false);
            enemyStack.Push(enemy);
        }
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        GetEnemy();
        StartCoroutine(Spawn());
    }

    public GameObject GetEnemy()
    {
        if (enemyStack.Count > 0)
        {
            GameObject enemy = enemyStack.Pop();
            enemy.transform.position = new Vector3(Random.Range(-8, 8), 10, 0);
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject enemy = Instantiate(GetWeightedRandomEnemy(), enemiesParent);
            enemy.transform.position = new Vector3(Random.Range(-8, 8), 10, 0);
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyStack.Push(enemy);
    }

    private GameObject GetWeightedRandomEnemy()
    {
        float totalWeight = 0f;

        foreach (float weight in enemyWeights)
            totalWeight += weight;

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            cumulativeWeight += enemyWeights[i];
            if (randomValue <= cumulativeWeight)
                return enemyPrefabs[i];
        }

        return enemyPrefabs[enemyPrefabs.Count - 1];
    }

}
