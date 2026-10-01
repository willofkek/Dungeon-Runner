using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private float spawnTime;
    public float swingDuration = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime >= swingDuration) 
        {
            Destroy(gameObject);
        }
    }
}
