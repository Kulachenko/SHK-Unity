using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _positionSelectionRadius;

    private Vector3 _target;

    private void Start()
    {
        ChooseTargetPosition();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            ChooseTargetPosition();
    }

    private void ChooseTargetPosition()
    {
        _target = Random.insideUnitCircle * _positionSelectionRadius;
    }
}
