using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControl : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset = new Vector3(0f,14f,6f);
    [SerializeField] private float _speed = 45.0f;
    private Vector3 _position;


    private void FixedUpdate()
    {
        _position = _playerTransform.position + _offset;
        transform.position =_position * _speed * Time.deltaTime;
    }
}
