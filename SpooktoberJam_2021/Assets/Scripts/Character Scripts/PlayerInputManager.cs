using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInputManager : MonoBehaviour
{
    [Header("Jump Mechanics:")]
    [Tooltip("Maximum number of jumps.")]
    [SerializeField] int maxNumOfAdditionalJumps = 1;
    // Number of jumps the player has currently.
    int numOfAdditionalJumps;
    [Tooltip("Insert the ground check transform here.")]
    [SerializeField] Transform groundCheck;

    [Range(0.01f, 1)]
    [Tooltip("Radius from the ground check point to be considered 'Grounded'.")]
    [SerializeField] float checkRadius = 0.03f;

    // Bool to tell if we're grounded.
    bool isGrounded;
    // Reference to the character movement script.
    CharacterMovement characterMovement;
    // Reference to the animator.
    Animator animator;
    // Keeps track of the horizontal input from the player.
    float xInput;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the character movement script.
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the horizontal input.
        xInput = Input.GetAxis("Horizontal");
        // If we got horizontal input.
        if (xInput != 0)
        {
            // Move in the direction of the input.
            characterMovement.Move(xInput);
            // If we have an animator.
            if(animator != null)
            {
                // Set the speed variable to our input.
                animator.SetFloat("Speed", xInput);
            }
        }
        // If we hit the space bar and have jumps to use.
        if (Input.GetKeyDown(key: KeyCode.Space) && numOfAdditionalJumps > 0)
        {
            characterMovement.Jump();
            // Subtract a jump.
            numOfAdditionalJumps -= 1;
        }

        // If the character is grounded and has used an additional jump.
        if (isGrounded && numOfAdditionalJumps < maxNumOfAdditionalJumps)
        {
            numOfAdditionalJumps = maxNumOfAdditionalJumps;
        }
        // Check to see if we're grounded or not.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

        // If we have cats and attempt to throw one, throw it
        if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.CatsRescued > 0)
        {
            GameManager.instance.SacrificeThrowCat();
        }
    }
}
