using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;
    private Vector2 targetDirection;
    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>().transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 enemyToPlayerVector = player.position - transform.position;
        targetDirection = enemyToPlayerVector.normalized;
        rigidbody.linearVelocity = targetDirection * speed;
        if (player == null)
        {
            float playerDeath = Time.time;
            if (Time.time - playerDeath >= 3)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}