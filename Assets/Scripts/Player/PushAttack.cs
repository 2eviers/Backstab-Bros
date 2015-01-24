using UnityEngine;
using System.Collections;

public class PushAttack : MonoBehaviour {

    bool canPush = false;
    public float pushForceRatioX;
    public float pushForceRatioY;
    GameObject objectToPush;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (canPush)
        {

            var pushVectX = Input.GetAxis(GetComponentInParent<Player>()._prefixController + "FireX");
            var pushVectY = Input.GetAxis(GetComponentInParent<Player>()._prefixController + "FireY");
          

            if (pushVectX >= 0) { 
                 Debug.Log("vectX =" + pushVectX + "vectY =" + pushVectY   );
                 objectToPush.GetComponent<Rigidbody>().AddForce(new Vector3(pushForceRatioX*pushVectX, -pushVectY*pushForceRatioY));
            }

            //Timer
            if (gameObject.GetComponentInParent<Player>()._prefixController == "J1")
                Camera.main.GetComponent<DeathType>().ActiveSkillP2 = true;
            if (gameObject.GetComponentInParent<Player>()._prefixController == "J2")
                Camera.main.GetComponent<DeathType>().ActiveSkillP1 = true;
        }
	}

    void OnTriggerEnter(Collider coll)
    {   
        canPush = (coll.gameObject.GetComponentInParent<Player>() != null);
        if (canPush) objectToPush = coll.gameObject.GetComponentInParent<Rigidbody>().gameObject;
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.GetComponentInParent<Player>() != null) canPush = false;
    }
}
