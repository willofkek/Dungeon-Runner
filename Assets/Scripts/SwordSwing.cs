using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private float spawnTime;
    public float swingDuration = 0.5f;
    public int killScore;
    private PlayerController scoreHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Time.time;
        scoreHolder = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime >= swingDuration) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<EnemyController>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreHolder.AddScore(killScore);
        }
    }
}
