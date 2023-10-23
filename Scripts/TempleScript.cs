using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleScript : MonoBehaviour
{
    private Rigidbody rb;
    public int Health = 20;
    [SerializeField] int _score = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0f, 10.0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0f, -10.0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-10.0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(10.0f, 0f, 0f);
        }
        //Debug.Log(Health);
        if (Health <= 0)
        {
            this.gameObject.SetActive(false);
            Debug.Log("You are killed!");
        }
    }

    

    public void AlterHealth(int damage)
    {
        //if (Health <= 0)
        //{
        //    Debug.Log("You are killed!");
        //    Destroy(this.gameObject);
        //}
        Health -= damage;
    }
    public void AddScore(int score)
    {
        _score += score;
    }
}
