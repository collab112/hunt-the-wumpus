using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Needed for working with files

//
// This script's read function operates the same as OptionsMenu.cs
//

public class PlayerRotationScript : MonoBehaviour
{

  // Allow an adjustable mouse sensitivity
  public float mouseSens;

  // For player object
  public float hztlRotation;
  private float yRotation;

  // For camera
  public GameObject mainCamera; // Assign via inspector

  public float vertRotation;
  private float xRotation;

  string mouseDataPath;

  void Start() {

    mouseDataPath = Application.persistentDataPath + "mouseSens";
    mouseSens = 2500.0f * (float.Parse(File.ReadAllLines(mouseDataPath)[0]) + .05f);

  }

  public void getMouseSensitivity() {

    mouseSens = 2500.0f * float.Parse(File.ReadAllLines(mouseDataPath)[0]);

  }

    void Update() {

      yRotation = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
      xRotation = -1 * Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
      // the rotations are equal to the Axis of the mouse (Always between -1 and 1)
      // multiplied by the mouse sensitivity and the time since the last frame   

      hztlRotation += yRotation;
      vertRotation += xRotation;

      vertRotation = Mathf.Clamp(vertRotation, -80.0f, 80.0f);
      // Clamp the upwards and downwards looking so the player cannot do a revolution

      transform.rotation = Quaternion.Euler(0.0f, hztlRotation, 0.0f);
      mainCamera.transform.rotation = Quaternion.Euler(vertRotation, hztlRotation, 0.0f);
      // Set the y rotation of the player object to the hztl rotation only
      // set the y rotation of the camera to hztlRotation AND set the 
      // x rotation to vertRotation. The Z rotation for both do not change.

    }
}
