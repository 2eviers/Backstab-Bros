using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    //class button to activate any mechanism

    public GameObject Target;

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
