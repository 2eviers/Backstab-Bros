using UnityEngine;
using System.Collections;

public class CancellingButton : MonoBehaviour {

    public GameObject Target;

    // On Collision, permanently disable mechanism
    void OnTriggerEnter(Collider coll)
    {
        Target.GetComponent<Mechanism>().PermanentlyDisableMechanism();
    }
}
