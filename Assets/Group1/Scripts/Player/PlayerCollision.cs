using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction IncreaseSpeed;
    public event UnityAction EnemyKilled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            CheckEnemyType(enemy);
        }
    }

    private void CheckEnemyType(Enemy enemy)
    {
        if (enemy.EnemyType == EnemyType.Normal)
        {
            DisableEnemy(enemy);
        }
        else if(enemy.EnemyType == EnemyType.IncreasingSpeed)
        {
            IncreaseSpeed?.Invoke();
            DisableEnemy(enemy);
        }
    }

    private void DisableEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        EnemyKilled?.Invoke();
    }
}
