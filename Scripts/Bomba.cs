using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private GameObject _playerPrefab;
    private PlayerControl _playerScript;
    private Rigidbody _playerRb;


    [SerializeField] private float _rotationSpeed = 35.0f;
    [SerializeField] private float _forceValue = 300.0f;
    [SerializeField] private int _damage = 4;

    [SerializeField] private EnemyGenerator _enemyGenerator;

    private void Awake()
    {
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();
        _playerPrefab = FindObjectOfType<PlayerControl>().gameObject;
        _playerScript = _playerPrefab.GetComponent<PlayerControl>();
        _playerRb = _playerPrefab.GetComponent<Rigidbody>();
        _playerRb.maxLinearVelocity = Mathf.Infinity;
    }
    private void FixedUpdate()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        _playerRb.AddForceAtPosition(transform.forward * _forceValue, transform.position);
        TakeDamage();
        _enemyGenerator.RemoveBombsFromList(gameObject);
        Destroy(gameObject);
    }
    private void TakeDamage()
    {
        _playerScript.AlterHealth(_damage);
    }
}
