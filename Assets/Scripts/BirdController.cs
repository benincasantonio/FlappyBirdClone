using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private float jumopForce = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the GameObject.");
        }
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Jump action performed");
            Jump();
        }
    }

    private void Jump()
    {
        print("Jumping with force: " + jumopForce);
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumopForce);
        }
        else
        {
            Debug.LogError("Rigidbody2D is not assigned. Cannot perform jump.");
        }
    }
    
}
