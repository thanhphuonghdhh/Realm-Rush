using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 5;

    [Tooltip("Add amount to maxHp when enemy dies.")]
    [SerializeField] int difficult = 1;
    int currentHp = 0;
    Enemy enemy;

    void OnEnable()
    {
        enemy = GetComponent<Enemy>();  
        currentHp = maxHp;    
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHp--;
        if (currentHp <= 0)
        {
            enemy.RewardGold();
            maxHp += difficult;
            gameObject.SetActive(false); 
        }
    }
}
