using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for working with UI Elements
using System.IO; // Needed for working with files
using System; // Needed to convert to string


//
// This script works the same way as the main menu script for sensitivity (OptionsMenu.cs).
// It handles the sensitivity option in the pause menu
//


public class PauseSensitivity : MonoBehaviour
{
 
    string mouseDataPath; 
    
    public float mouseSens;
    public Slider mouseSensSlider;

    void Start() {

        mouseDataPath = Application.persistentDataPath + "mouseSens";
        getMouseData();
        mouseSensSlider.value = mouseSens;

    }

    public void getMouseData() {

        if( !File.Exists(mouseDataPath) ) {

            mouseSens = .2f;

        } else {

            mouseSens = float.Parse(File.ReadAllLines(mouseDataPath)[0]);

        }

    }

    public void saveMouseData() {

        File.WriteAllText(mouseDataPath, mouseSens.ToString());

    }



    void Update() {

        mouseSens = mouseSensSlider.value;
        saveMouseData();

    }

}
