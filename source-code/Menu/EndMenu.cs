using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to manage scenes

// END MENU - This script is a copy of MainMenu except the quit game goes to the
// main menu rather than quitting the game.
public class EndMenu : MonoBehaviour
{

    public void startGame() { // Called on button "Replay" click

        SceneManager.LoadScene("Game"); // Load the game scene again

    }
    
    public void quitGame() { // Called on button "Quit" click

        SceneManager.LoadScene(0); // Load the main menu

    }

}
