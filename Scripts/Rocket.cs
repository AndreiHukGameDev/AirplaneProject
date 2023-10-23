using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Transform _decorationRocketTransform;
    [SerializeField] private Transform _baseRocketTransform;
    private float _transformRotationSpeed = 40.0f;


    private Transform _targetTransform;
    private float _speed;
    [SerializeField] private float _changeSpeed = 0.3f;

    private PlayerControl _playerControl;
    private Rigidbody _playerRb;

    [SerializeField] private int _damage = 6;
    [SerializeField] private float _forceValue = 400.0f;

    [SerializeField] private EnemyGenerator _enemyGenerator;


    private void Awake()
    {
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();
        _targetTransform = FindObjectOfType<PlayerControl>().gameObject.transform;
        _playerControl = FindObjectOfType<PlayerControl>();
        _playerRb = FindObjectOfType<PlayerControl>().gameObject.GetComponent<Rigidbody>();
        _speed = _playerControl.GetSpeed() * _changeSpeed;
    }

    private void FixedUpdate()
    {
        MovedRocket();
    }

    private void MovedRocket()
    {
        _decorationRocketTransform.Rotate(0.0f, -(_transformRotationSpeed * Time.deltaTime), 0.0f);
        _baseRocketTransform.Rotate(0.0f, _transformRotationSpeed * Time.deltaTime, 0.0f);

        Vector3 targetDirection = _targetTransform.position - transform.position;
        float singleStep = _speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, singleStep);
    }
    private void OnCollisionEnter(Collision collision)
    {
        TakeDamage();
        _playerRb.AddForceAtPosition(transform.forward * _forceValue, transform.position);
        _enemyGenerator.RemoveRocketFromList(gameObject);
        Destroy(gameObject);
    }
    private void TakeDamage()
    {
        _playerControl.AlterHealth(_damage);
    }
}
