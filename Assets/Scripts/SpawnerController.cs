using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject spawn;
    public bool earlySpawner;
    public float spawnTimeModifier = 1;
    private float lastSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastSpawnTime = Time.time;
        if (earlySpawner)
        {
            GameObject enemy = Instantiate(spawn, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= 10 * spawnTimeModifier)
        {
            GameObject enemy = Instantiate(spawn, transform.position, transform.rotation);
            lastSpawnTime = Time.time;
        }
    }
}
