using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur_caractere_controleur : MonoBehaviour
{
    // Rigidbody s'occupe du mouvement
    public Rigidbody2D Rigidbody2D = null;

    // Velocity
    private Vector3 velocity = Vector3.zero;

    // Move damp
    [Range(0f, 3.0f)]
    public float moveDampFactor = 0f;

    // input
    [Range(-1.0f, 1.0f)]
    public float horizontalInput = 0f;
    public bool jumpInput = false;

    // Jump
    public float jumpForce = 400f;

    void Update()
    {
        // Input for horizontal movement
        this.horizontalInput = Input.GetAxisRaw("Horizontal");

        // Input for jumping
        this.jumpInput = Input.GetKeyDown(KeyCode.Space);
        
        // Handle flip
        this.handleFlip();

        // Check if grounded
        this.updateGroundedStatus();

         // Jump
        if (this.jumpInput && this.isGrounded) {
            this.Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        // Handle horizontal movement
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(this.horizontalInput * 10f, this.Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            this.Rigidbody2D.velocity = Vector3.SmoothDamp(this.Rigidbody2D.velocity, targetVelocity, ref velocity, this.moveDampFactor);
        }
    }

    // Flip
    private bool facingRight = true;

    private void handleFlip()
    {
        // If the input is moving the player right and the player is facing left
        if (this.horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (this.horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is oriented
        facingRight = !facingRight;

        // Invert the local scale
        Vector3 invertedScale = transform.localScale;
        invertedScale.x *= -1;

        // Apply
        transform.localScale = invertedScale;
    }

    // Ground check
    [Header("Physics")]
    public Transform groundChecker = null;
    public bool isGrounded = false;
    public LayerMask groundCheckLayersMask;

    private void updateGroundedStatus() {
        // Unset flag
        this.isGrounded = false;

        if (this.groundChecker != null) {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.groundChecker.transform.position, 0.2f, this.groundCheckLayersMask);
            if (colliders != null && colliders.Length > 0) {
                for (int i=0; i<colliders.Length; i++) {
                    if (colliders[i].gameObject != this.gameObject) {
                        // Log
                        // Debug.Log("Grounded " + colliders[i].gameObject);

                        this.isGrounded = true;
                    }
                }
            }
        }
    }


}
