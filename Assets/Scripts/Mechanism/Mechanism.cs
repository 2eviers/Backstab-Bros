using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour {
    //class template for any Mechanism controled by a button

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

    //to run the mechanism, this function must be reimplemented
    protected virtual void runMechanism()
    {

    }

    //to go back on the default position, this function must be reimplemented
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
