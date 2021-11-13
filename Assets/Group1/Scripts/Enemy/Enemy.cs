using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public EnemyType EnemyType { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetProperty(EnemyProperty enemyProperty)
    {
        _spriteRenderer.color = enemyProperty.EnemyColor;
        EnemyType = enemyProperty.EnemyType;
    }
}

public enum EnemyType
{
    Normal,
    IncreasingSpeed
}
