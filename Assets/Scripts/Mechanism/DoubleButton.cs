using UnityEngine;
using System.Collections;

public class DoubleButton : MonoBehaviour {

    public bool done = false;
    public Player p;
	
    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponentInParent<Player>() == p)
            done = true;
    }
}
