using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // needed for managing scenes

//
// This script works in the same way as NoiseTrap.cs, but performs a different action.
//

public class Trapdoor : MonoBehaviour
{

    public GameObject randomPointHandler;

    void Start() {

        transform.position
         = 
        randomPointHandler.GetComponent<RoamHelper>().getRandomPointAwayFromPlayer();

    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 7) {

            SceneManager.LoadScene(4); // Load scene 4 (Game over (Trapdoor) )

        }    

    

    }

}
