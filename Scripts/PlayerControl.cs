using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float RotationSpeed = 2.0f;
    private float torqueForce;
    private float forwardForce;

    public int Health = 12;
    public int _score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MovedPlayer();
    }
    private void MovedPlayer()
    {
        torqueForce = Input.GetAxis("Horizontal") * RotationSpeed;
        forwardForce = Input.GetAxis("Vertical") * Speed;

        rb.AddRelativeForce(0.0f, 0.0f, forwardForce);
        rb.AddRelativeTorque(torqueForce, 0.0f, 0.0f);

    }
    public float GetSpeed()
    {
        return Speed; 
    }
    public void AlterHealth(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            SceneManager.LoadScene("Games");
        }
    }
    public void AddScore(int score)
    {
        _score += score;
    }
    public int ReturnScore()
    {
        return _score;
    }
    public int ReturnHealth()
    {
        return Health;
    }
}
