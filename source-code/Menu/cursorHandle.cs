using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// During testing I encountered a bug where the cursor did not show up on the end scene
// so I made this script to fix it
//

public class cursorHandle : MonoBehaviour
{

    void Awake() {

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible

    }

}
