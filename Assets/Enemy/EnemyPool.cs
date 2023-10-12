using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.1f, 30f)] float timeSpawn = 2f;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    GameObject[] enemiesPool;

    private void Awake()
    {
        createPool();
    }

    void createPool()
    {
        enemiesPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            enemiesPool[i] = Instantiate(enemyPrefab, transform);
            enemiesPool[i].SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(CreateEnemy());

    }
    IEnumerator CreateEnemy()
    {
        while (true)
        {
            EnableEnemiesInPool();
            yield return new WaitForSeconds(timeSpawn);
        }

    }
    void EnableEnemiesInPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (enemiesPool[i].activeInHierarchy == false)
            {
                enemiesPool[i].SetActive(true);
                return;
            }
        }
    }
}
