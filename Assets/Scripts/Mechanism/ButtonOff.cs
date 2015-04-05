using UnityEngine;
using System.Collections;

public class ButtonOff : MonoBehaviour {

    //class button to activate any mechanism

    public GameObject Target;
    public GameObject Target2;

    bool isActivated = false;


    void OnTriggerEnter(Collider coll)
    {
        Mechanism m = Target.GetComponent<Mechanism>();
        Mechanism m2 = Target2.GetComponent<Mechanism>();

        if (coll.GetComponentInParent<Player>())
        {


            isActivated = true;


            mechanismTreatment(m);
            mechanismTreatment(m2);



            //Timer
            if (coll.GetComponentInParent<Player>()._prefixController == "J1")
                Camera.main.GetComponent<DeathType>().ActivePuzzleP2 = true;
            if (coll.GetComponentInParent<Player>()._prefixController == "J2")
                Camera.main.GetComponent<DeathType>().ActivePuzzleP1 = true;
        }
    }

    void mechanismTreatment(Mechanism m)
    {
        m.DisableMechanism();

        if (m.GetComponent<AudioSource>() && !m.GetComponent<AudioSource>().isPlaying)
            m.GetComponent<AudioSource>().Play();
    }

}
