using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamingPointScript : MonoBehaviour
{   

    public GameObject helper; // Allow this object to access the roam helper


    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 9) { 

            // If the collider is of layer 9 (Wumpus)

            helper.GetComponent<RoamHelper>().sendNextPoint(gameObject.GetComponent<Collider>());            

            // Send the wumpus to its next point

            }

        }
    
}
