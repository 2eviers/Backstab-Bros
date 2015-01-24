using UnityEngine;
using System.Collections;

public class CancellingButton : MonoBehaviour {

    public GameObject Target;

    // On Collision, permanently disable mechanism
    void OnCollisionEnter(Collision coll)
    {
        Target.GetComponent<Mechanism>().PermanentlyDisableMechanism();
    }
}
