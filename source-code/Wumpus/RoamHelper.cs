using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamHelper : MonoBehaviour
{

    public GameObject wumpusObj; // Allow this script to access the wumpus
    public GameObject playerObj; // Allow this script to access the player

    public int sphereRadius; // Define a radius for the overlap sphere
    public LayerMask otherRoamPointsLayer; // Define a layer to check for
    public Collider[] otherPoints; // A place to store the colliders from the overlap

    private int randomPoint; // A source of randomness\
    
    void Awake() {

        /*/ / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
        *
        * This function is set in the Awake() sequence because the traps and wumpus cannot
        * spawn on top of the player. The player's object must be randomised before the 
        * trap and wumpus positions are set, and Awake() is guaranteed to run before Start() 
        * which is where the traps and wumpus have their random spawns set in.
        *
        / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /*/

        otherPoints = Physics.OverlapSphere(transform.position, sphereRadius, otherRoamPointsLayer);
        // The array of roam points is setup in Awake()

        playerObj.transform.position = otherPoints[Random.Range(0, otherPoints.Length)].transform.position;
        // Random player spawn

    }

    // There are roampoints scattered around the map that are scanned in during the 
    // overlap sphere in Awake(). These will serve as the random spawns

    // A function is called by roamingPointScript.cs 

    public void sendNextPoint(Collider excludeThis) {

        randomPoint = Random.Range(0, otherPoints.Length);

        while ( otherPoints[randomPoint] == excludeThis) {

            randomPoint = Random.Range(0, otherPoints.Length);

        }

        // Gives a position that is guaranteed not to be the same as the point
        // the wumpus is already on

        wumpusObj.GetComponent<WumpusStates>().roamPoints(otherPoints[randomPoint].transform.position);

        // Send this position to the wumpus AI

    }

    public Vector3 getRandomPointAwayFromPlayer() {

        randomPoint = Random.Range(0, otherPoints.Length);

        while ( otherPoints[randomPoint].transform.position == playerObj.transform.position) {

            randomPoint = Random.Range(0, otherPoints.Length);

        } 

        return otherPoints[randomPoint].transform.position;

        // Similar to the above function, but this function returns a position that is
        // guaranteed not to be the player's position

    }

}
