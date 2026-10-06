using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public GameObject swordSwing;
    public GameObject explosion;
    public Transform swordOffset;
    public float swordSpeed;
    public bool dead = false;
    private float deathTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            if (Time.time - deathTime >= 3)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (dead == false)
        {
            if (collision.gameObject.GetComponent<EnemyController>())
            {
                dead = true;
                deathTime = Time.time;
            }
        }
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (dead == false)
        {
            rigidbody.linearVelocity = ctx.ReadValue<Vector2>() * speed;
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (dead == false)
        {
            if (ctx.started)
            {
                swordOffset.localPosition = ctx.ReadValue<Vector2>();
                GameObject attack = Instantiate(swordSwing, swordOffset.position, swordOffset.rotation);
                Rigidbody rigidbody = swordSwing.GetComponent<Rigidbody>(); 

                rigidbody.linearVelocity = swordSpeed * ctx.ReadValue<Vector2>();
            }
        }
    }
}