using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scenes 

// Elements of this script were taken from a previous project
public class PauseMenu : MonoBehaviour
{

    public bool paused; 

    public GameObject escapeMenu; // Allow this script to open and close the escape menu
    public GameObject projectileThrower; // Allow the script to disable shooting
    public GameObject playerMouseHandle; // Allow the script to adjust sensitivity

    // I had to disable shooting in the pause script because I encountered a bug
    // where the player could shoot in the pause menu

    void Start() { // When the script is loaded, set the paused variable to false

        paused = false;

    }

    public void PlayPauseGame() { // Check if paused is true or false

        if (paused == true) {
            
            pause();
        
        } else {
            
            resume();            
        
        }
    }

    public void quitToMenu() { // Load the main menu scene

        SceneManager.LoadScene(0);

    }

    public void pause() { 

        Time.timeScale = 0; // Set the timescale to 0 (Time does not go forward)
        paused = true; 
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible

        escapeMenu.SetActive(true); // Set the menu object active 
        projectileThrower.SetActive(false); // Disable the shooting mechanic

    }

    public void resume() {

        Time.timeScale = 1; // Time will run normally
        paused = false; 
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false; // Make cursor invisible

        escapeMenu.SetActive(false); // Set the menu object inactive
        projectileThrower.SetActive(true); // Enable shooting

    }

    void Update() {

        if ( Input.GetKeyDown(KeyCode.Escape) ) { // Check if escape is pressed

            paused = !paused; // Toggle the paused variable
            playerMouseHandle.GetComponent<PlayerRotationScript>().getMouseSensitivity();
            // Retrieve data from the file containing mouse sensitivity in the looking script

        }

        PlayPauseGame();

    }

}
