using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    //class button to activate any mechanism

    public GameObject Target;
    public float Cooldown;

    private float _timer;

 

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponentInParent<Player>())
        {
            Mechanism m = Target.GetComponent<Mechanism>();
            m.EnableMechanism();
            if (m.audio && !m.audio.isPlaying)
                m.audio.Play();
        }
    }

    void OnTriggerExit(Collider coll)
    {
        _timer = Time.time;
        Target.GetComponent<Mechanism>().DisableMechanism();
    }

    void Update()
    {
       /* if (Time.time - _timer > Cooldown)
            Target.GetComponent<Mechanism>().DisableMechanism();
       y//*/
    }
}
