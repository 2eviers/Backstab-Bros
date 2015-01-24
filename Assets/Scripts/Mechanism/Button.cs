using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    //class button to activate any mechanism

    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        Target.GetComponent<Mechanism>().EnableMechanism();
    }

    void OnTriggerExit(Collider coll)
    {
        Target.GetComponent<Mechanism>().DisableMechanism();
    }
}
