using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    }
}