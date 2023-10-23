using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _rotationSpeed = 500.0f;

    private void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, _rotationSpeed * Time.deltaTime);
    }
}
