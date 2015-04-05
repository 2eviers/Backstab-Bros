using UnityEngine;
using System.Collections;

public class ElevatorDoubleButton : Mechanism {

    public GameObject d1, d2;
    public GameObject Platform;
    public GameObject Axis;
    public float Speed;

    private int _right;
    private float _originalWidth;

    void Start()
    {
        _right = 1;
        _originalWidth = Platform.transform.position.x;
    }

    // Go up / down if the platform is on the bottom / top, and loop
    protected override void runMechanism()
    {
        float width = Axis.transform.localScale.x;

        // If it's at the top, _upward = false (going down)
        if (Platform.transform.position.x - Axis.transform.position.x >= width)
            _right = -1;
        else if (Platform.transform.position.x - Axis.transform.position.x <= -width)
            _right = 1;

        Vector3 dir = new Vector3(1, 0, 0);
        Platform.GetComponent<Rigidbody>().MovePosition(Platform.GetComponent<Rigidbody>().position + dir * Speed * _right * Time.fixedDeltaTime);
        // rigidbody.transform.Translate(dir * Speed * _upward * Time.fixedDeltaTime);

        // Platform.transform.Translate(dir * Speed * _upward * Time.deltaTime);
    }

    // Go back to original position
    protected override void backToDefaultPosition()
    {
        Vector3 dir = new Vector3(1, 0, 0);
        if (Mathf.Abs(Platform.transform.position.x - _originalWidth) < .1)
            return;
        if (Platform.transform.position.x > _originalWidth)
            _right = -1;
        else if (Platform.transform.position.x < _originalWidth)
            _right = 1;
        Platform.GetComponent<Rigidbody>().MovePosition(Platform.GetComponent<Rigidbody>().position + dir * Speed * _right * Time.fixedDeltaTime);
        //rigidbody.transform.Translate(dir * Speed * _upward * Time.fixedDeltaTime);

        // Platform.transform.Translate(dir * Speed * _upward * Time.deltaTime);
    }



    protected override void FixedUpdate()
    {
        if (d1.GetComponent<DoubleButton>().done && d2.GetComponent<DoubleButton>().done)
            broken = true;
 	    base.FixedUpdate();
    }
}
