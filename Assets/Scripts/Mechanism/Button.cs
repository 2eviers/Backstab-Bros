using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    //class button to activate any mechanism

    public GameObject Target;

    private float _timer;

 

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponentInParent<Player>() || coll.GetComponentInParent<Pushable>())
        {
            Mechanism m = Target.GetComponent<Mechanism>();
            m.EnableMechanism();
            if (m.GetComponent<AudioSource>() && !m.GetComponent<AudioSource>().isPlaying)
                m.GetComponent<AudioSource>().Play();
            //Timer
            if (coll.GetComponentInParent<Player>()._prefixController == "J1")
                Camera.main.GetComponent<DeathType>().ActivePuzzleP2 = true;
            if (coll.GetComponentInParent<Player>()._prefixController == "J2")
                Camera.main.GetComponent<DeathType>().ActivePuzzleP1 = true;
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
