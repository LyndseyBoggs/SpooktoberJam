using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement:")]
    [Tooltip("Speed of the player.")]
    [Range(0, 999)]
    [SerializeField] float runSpeed = 10;

    [Range(0, 99999)]
    [Tooltip("The force applied to the jump.")]
    [SerializeField] float jumpForce = 400;

    // Rigidbody reference.
    Rigidbody2D rigidbody;

    /// <summary>
    /// Moves the player in the specified direction inputed. X > 0 = right. X < 0 = left;
    /// </summary>
    /// <param name="direction">X > 0 = right. X < 0 = left;</param>
    public void Move(float direction)
    {
        transform.position += Vector3.right * (direction * runSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Adds jump force to the character in the upward direction if they have jumps left. 
    /// </summary>
    public void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        // Apply the force.
        rigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Start()
    {
        // Grabs the rigid body.
        rigidbody = GetComponent<Rigidbody2D>();
    }

}
