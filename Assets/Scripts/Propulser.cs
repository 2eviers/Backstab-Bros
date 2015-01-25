using UnityEngine;
using System.Collections;

public class Propulser : MonoBehaviour
{

    public GameObject d1, d2;
    public Player p1, p2;
    public Vector3 Force;

    private Player p;
    private Rigidbody r1, r2;
    private bool _enabled = false;
    private bool ok1 = false;
    private bool ok2 = false;

    void Start()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        p = coll.GetComponentInParent<Player>();
        if (p == p1)
        {
            r1 = coll.GetComponentInParent<Rigidbody>();
            ok1 = true;
        }
        if (p == p2)
        {
            r2 = coll.GetComponentInParent<Rigidbody>();
            ok2 = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        p = coll.GetComponentInParent<Player>();
        if (p == p1)
        {
            ok1 = false;

        }
        if (p == p2)
        {
            ok2 = false;
        }
    }

    void FixedUpdate()
    {
        if (d1.GetComponent<DoubleButton>().done && d2.GetComponent<DoubleButton>().done)
        {
            _enabled = true;
        }
        if (_enabled && ok1)
            r1.AddForce(Force);
        if (_enabled && ok2)
            r2.AddForce(Force);
    }
}
