using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour {
    // Class template for any Mechanism controled by a button

    bool enableMechanism = false;

	// Use this for initialization
	void Start () {
	
	}

    public void EnableMechanism()
    {
        enableMechanism = true;
    }

    public void DisableMechanism()
    {
        enableMechanism = false;
    }

    // To run the mechanism, this function must be reimplemented
    // Called every frame if mechanism is enabled
    protected virtual void runMechanism()
    {

    }

    // To go back to the default position, this function must be reimplemented
    // Called every frame if mechanism is disabled
    protected virtual void backToDefaultPosition()
    {

    }
   

	// Update is called once per frame
	void Update () {
        if (enableMechanism)
        {
            runMechanism();
        }
        else backToDefaultPosition();
          
	}
}
