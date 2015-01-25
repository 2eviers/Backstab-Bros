using UnityEngine;
using System.Collections;

public class PushAttack : MonoBehaviour {

    bool canPush = false;
    public float pushForceRatioX;
    public float pushForceRatioY;
    GameObject objectToPush;

    public float InitPushX { get; private set; }
    public float InitPushY { get; private set; }

	void Start ()
	{
	    InitPushX = pushForceRatioX;
	    InitPushY = pushForceRatioY;
	}
	
	void FixedUpdate () {
        if (canPush)
        {

            var pushVectX = Input.GetAxis(GetComponentInParent<Player>()._prefixController + "FireX");
            var pushVectY = Input.GetAxis(GetComponentInParent<Player>()._prefixController + "FireY");

            GetComponentInParent<Player>().anim.SetBool("Push", pushVectX < 0 || pushVectY != 0);
            

            objectToPush.GetComponent<Rigidbody>().AddForce(new Vector3(pushForceRatioX*pushVectX, -pushVectY*pushForceRatioY));

            //Timer
            if (gameObject.GetComponentInParent<Player>()._prefixController == "J1")
                Camera.main.GetComponent<DeathType>().ActiveSkillP2 = true;
            if (gameObject.GetComponentInParent<Player>()._prefixController == "J2")
                Camera.main.GetComponent<DeathType>().ActiveSkillP1 = true;
        }
        else GetComponentInParent<Player>().anim.SetBool("Push", false);


	}

    void OnTriggerEnter(Collider coll)
    {
        canPush = true;//(coll.gameObject.GetComponentInParent<Player>() != null);
        if (canPush) objectToPush = coll.gameObject.GetComponentInParent<Rigidbody>().gameObject;
    }

    void OnTriggerExit(Collider coll)
    {
        //if (coll.gameObject.GetComponentInParent<Player>() != null) 
        canPush = false;
    }
}
