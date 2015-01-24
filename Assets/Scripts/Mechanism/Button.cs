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

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.GetComponentInParent<Player>())
            Target.GetComponent<Mechanism>().EnableMechanism();
    }

    void OnCollisionExit(Collision coll)
    {
        Target.GetComponent<Mechanism>().DisableMechanism();
    }
}
