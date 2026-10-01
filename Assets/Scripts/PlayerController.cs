using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public GameObject swordSwing;
    public Transform swordOffset;
    public float swordSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        GetComponent<Rigidbody>().linearVelocity = ctx.ReadValue<Vector2>() * speed;
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            swordOffset.localPosition = ctx.ReadValue<Vector2>();
            GameObject attack = Instantiate(swordSwing, swordOffset.position, swordOffset.rotation);
            Rigidbody rigidbody = swordSwing.GetComponent<Rigidbody>(); 

            rigidbody.linearVelocity = swordSpeed * transform.up;

        }
    }
}
