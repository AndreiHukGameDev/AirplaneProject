using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 ofset = new Vector3(0, 1, -30);

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerControl>().gameObject.transform;
    }
    void Update()
    {
        transform.position = _playerTransform.position + ofset;
    }
}
