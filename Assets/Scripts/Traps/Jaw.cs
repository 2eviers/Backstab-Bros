using UnityEngine;
using System.Collections;

public class Jaw : MonoBehaviour {
    // Jaw trap : munches the player if they try to go through

    public GameObject UpperJaw;
    public GameObject LowerJaw;
    public float Speed;

    private bool _opening = false;
    private float _jawDistance;
    private Vector3 _direction;

	void Start () {
        _jawDistance = UpperJaw.transform.position.y - LowerJaw.transform.position.y;
        _direction = new Vector3(0, 0, 0);
        _direction = UpperJaw.transform.position - LowerJaw.transform.position;
	}

    // If we find a player we MUNCH THE FUCK OUTTA EM
    void OnTriggerStay(Collider coll)
    {
        _opening = false;
        CloseJaw();
    }

    // Player left, open the jaws
    void OnTriggerExit(Collider coll)
    {
        _opening = true;
    }

    void CloseJaw()
    {
        if (UpperJaw.transform.position.y - transform.position.y > _jawDistance / 4)
        {
            UpperJaw.transform.Translate(- _direction * Speed * Time.deltaTime);
            LowerJaw.transform.Translate(_direction * Speed * Time.deltaTime);
        }
    }

    void OpenJaw()
    {
        if (UpperJaw.transform.position.y - transform.position.y < _jawDistance / 2)
        {
            UpperJaw.transform.Translate(_direction * Speed * Time.deltaTime);
            LowerJaw.transform.Translate(-_direction * Speed * Time.deltaTime);
        }
    }

	
	void Update () {
        if (_opening)
            OpenJaw();
	}
}
