using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

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
