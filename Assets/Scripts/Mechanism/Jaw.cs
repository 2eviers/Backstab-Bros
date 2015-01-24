using UnityEngine;
using System.Collections;

public class Jaw : Mechanism {
    // Jaw trap : munches the player if they try to go through

    public GameObject UpperJaw;
    public GameObject LowerJaw;
    public float Speed;

    private bool _opening = false;
    private float _jawDistance;
    private Vector3 _direction;

	void Start () {
        _direction = new Vector3(0, 0, 0);
        _direction = UpperJaw.transform.position - LowerJaw.transform.position;
        _jawDistance = _direction.y;
	}

    protected override void runMechanism()
    {
        _direction = new Vector3(0, 1, 0);
        if (UpperJaw.transform.position.y - transform.position.y > _jawDistance / 4)
        {
            UpperJaw.transform.Translate(- _direction * Speed * Time.deltaTime);
            LowerJaw.transform.Translate(_direction * Speed * Time.deltaTime);
        }
    }

    protected override void backToDefaultPosition()
    {
        if (UpperJaw.transform.position.y - transform.position.y < _jawDistance / 2)
        {
            UpperJaw.transform.Translate(_direction * Speed * Time.deltaTime);
            LowerJaw.transform.Translate(-_direction * Speed * Time.deltaTime);
        }
    }
}
