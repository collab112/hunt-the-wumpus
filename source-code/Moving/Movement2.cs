using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// This script is taken from a tutorial
//

public class Movement2 : MonoBehaviour
{

  public float moveSpeed; // Adjust the movement speed

  public float groundDrag; // Adjust drag of the rigidbody

  public float jumpForce; // Adjust jumping force
  public float jumpCooldown; // Adjust cooldown for jumping
  public float airMultiplier; // Adjust the multiplier for airtime
  bool readyToJump = true; // Determine if player can jump

  public KeyCode jumpKey = KeyCode.Space; // Set the jump keybind

  public float playerHeight; // Set height
  public LayerMask whatIsGround; // LayerMask of the ground
  public bool isGrounded; // Is the player on the ground?

  public Transform orientation; // Transform of the player

  float HorizontalInput;
  float VerticalInput;

  Vector3 moveDirection;

  public Rigidbody playerBody; 

  void Update() {

    isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .2f, whatIsGround);
    // Send a raycast downwards that goes down around half of the player's height and
    // scans in objects of layer Ground

    if (isGrounded) {

      playerBody.drag = groundDrag;
      // If the player is on the ground, introduce drag

    } else {

      playerBody.drag = 0;
      // No drag if player is not on the ground

    }

    SpeedRegulate();
    // Regulate the max speed of the player

    myInputFunc();

  }

  void FixedUpdate() {

    MovePlayer();

  }

  void myInputFunc() {

    HorizontalInput = Input.GetAxisRaw("Horizontal");
    VerticalInput = Input.GetAxisRaw("Vertical");

    if ( Input.GetKey(jumpKey) && readyToJump && isGrounded) {

      readyToJump = false;

      JumpFunc();

      Invoke(nameof(ResetJump), jumpCooldown);
      // Use invoke run ResetJump() after jumpCooldown amount of seconds

    }

  }

  //
  // The "normalized" attribute returns the vector with a value of 1 or 0 
  //

  void MovePlayer() {

    moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
    // Get the direction the player is moving using the orientation variable of type Transform

    if ( isGrounded ) 

      playerBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); 
      // If the player is on the ground, do not multiply by the airtime multiplier

    else if ( !isGrounded )
      playerBody.AddForce(moveDirection.normalized * moveSpeed * 10 * airMultiplier, ForceMode.Force);
      // If the player is not on the ground, multiply by the airtime multiplier

  }

  void SpeedRegulate() {

    Vector3 flatVel = new Vector3(playerBody.velocity.x, 0f, playerBody.velocity.z); 
    // Create a new Vector3 to contain the player's total velocity vector

    if ( flatVel.magnitude > moveSpeed) {

      Vector3 limitedVel = flatVel.normalized * moveSpeed;
      playerBody.velocity = new Vector3(limitedVel.x, playerBody.velocity.y, limitedVel.z);

      // If the player's velocity is more than the movement speed, limit it by creating
      // a new vector that has the magnitude of the movement speed and assigning it 
      // to the X and Z components of the vector (y does not need to be regulated)

    } 

  }

  void JumpFunc() {

    // At the start of the jump function, set the y velocity of the player to 0. This is
    // needed because sometimes the y velocity can be negative when on the ground, and would
    // lead to some jumps being lower than others.

    playerBody.velocity = new Vector3(playerBody.velocity.x, 0f, playerBody.velocity.z);

    playerBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    // Add force in the upwards direction to simulate jump

  }

  void ResetJump() {

    readyToJump = true;

  }

}
