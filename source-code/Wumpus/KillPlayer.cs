using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for working with scenes

public class KillPlayer : MonoBehaviour
{

    /*/ / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
    *
    * This script is attached to a sphere without a mesh renderer (an invisible sphere) 
    * that is a child object of the wumpus, meaning it will always stay in front of the
    * wumpus.
    *
    / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /*/

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 7) {

            // If something collides with this sphere and is of layer 7 (Player)

            SceneManager.LoadScene(3); // Load scene 3 (Death by Wumpus)

        }

    }

}
