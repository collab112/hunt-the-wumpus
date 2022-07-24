using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{

    public GameObject optionsPanel; // Allow this script to manage the optionsPanel
    public GameObject fileHandler;

    public void openOptionsMenu() { // Called on button "Options" click

        optionsPanel.SetActive(!optionsPanel.activeSelf); // Toggle the panel on and off

        fileHandler.GetComponent<OptionsMenu>().writeToFile();

        /*/ / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / 
        *
        * Call a function from the script OptionsMenu that is attached to
        * the optionsPanel game object. The function is writeToFile() and
        * saves the data on the sliders into a file.
        *
        / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /*/

    }

}
