using UnityEngine;
using System.Collections;

public class Mechanism : MonoBehaviour {

    bool enableMechanism = false;

	// Use this for initialization
	void Start () {
	
	}

    public void EnableMechanism()
    {
        enableMechanism = true;
    }

    protected virtual void runMechanism()
    {

    }
   

	// Update is called once per frame
	void Update () {
        if (enableMechanism)
        {
            runMechanism();
        }
             
	}
}
