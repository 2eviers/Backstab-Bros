using UnityEngine;
using System.Collections;

public class ZoneMortel : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.GetComponentInParent<Player>() != null)
            coll.gameObject.GetComponentInParent<Player>().TakeDamage(100);

  
    }
}
