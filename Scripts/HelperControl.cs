using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperControl : MonoBehaviour
{
    private Vector3 _offset = new Vector3(-1, 4, 0);
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private CoinsGenerator _coinsGenerator;
    private Transform _targetTransform;
    private float _speed = 1f;

    private void FixedUpdate()
    {
        transform.position = _playerTransform.position + _offset;
        _targetTransform = _coinsGenerator.ElementTransformFromList();
        Vector3 targetDirection = _targetTransform.position - transform.position;
        float singleStep = _speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

}
