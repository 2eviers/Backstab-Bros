using UnityEngine;
using System.Collections;

public class PushAttack : MonoBehaviour {

    bool canPush = false;
    public int pushForce;
    GameObject objectToPush;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (canPush && Input.GetButton(GetComponentInParent<Player>()._prefixController + "Fire1"))
        {
            objectToPush.GetComponent<Rigidbody>().AddForce(new Vector3(pushForce, 0));
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.gameObject.GetComponentInParent<Player>()._prefixController + "enter");
        canPush = (coll.gameObject.GetComponentInParent<Player>() != null);
        if (canPush) objectToPush = coll.gameObject.GetComponentInParent<Rigidbody>().gameObject;
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.GetComponentInParent<Player>() != null) canPush = false;
    }
}
