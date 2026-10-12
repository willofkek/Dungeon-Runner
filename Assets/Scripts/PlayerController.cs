using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public GameObject sprite;
    public GameObject swordSwing;
    private Rigidbody rigidbody;
    public Transform swordOffset;
    private Animator anim;
    public float swordSpeed;
    public bool dead = false;
    private float deathTime;
    public UnityEvent OnScoreChanged;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        anim = sprite.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            anim.SetBool("Dead", true);
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            if (Time.time - deathTime >= 1)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("WalkUp");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("WalkLeft");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("WalkDown");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("WalkRight");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("AttackUp");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetTrigger("AttackLeft");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("AttackDown");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetTrigger("AttackRight");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
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
        rigidbody.linearVelocity = ctx.ReadValue<Vector2>() * speed;
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (dead == false)
        {
            if (ctx.started)
            {
                swordOffset.localPosition = ctx.ReadValue<Vector2>();
                GameObject attack = Instantiate(swordSwing, swordOffset.position, swordOffset.rotation);
            }
        }
    }
}