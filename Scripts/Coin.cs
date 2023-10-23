using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerControl _playerScript;

    [SerializeField] private int _amount = 10;
    [SerializeField] private float _rotationSpeed = 100.0f;

    [SerializeField] private CoinsGenerator _coinsGeneratorScript;

    private void Awake()
    {
        _playerScript = FindObjectOfType<PlayerControl>();
        _coinsGeneratorScript = FindObjectOfType<CoinsGenerator>();
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        _playerScript.AddScore(_amount);
        _coinsGeneratorScript.RemoveCoinsFromList(gameObject);
        Destroy(gameObject);
        //add counter
    }
}
