using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour {
    // Class template for any Mechanism controled by a button

    bool enableMechanism = false;
    protected bool broken = false;

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

    public virtual void PermanentlyDisableMechanism()
    {
        broken = true;
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
	protected virtual void FixedUpdate () {


        if (broken)
            return;
        if (enableMechanism)
        {
            runMechanism();
        }
        else backToDefaultPosition();
          
	}
}
