using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    //class button to activate any mechanism

    public GameObject objet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        objet.GetComponent<platformrotation>().EnableMechanism();
    }
}
