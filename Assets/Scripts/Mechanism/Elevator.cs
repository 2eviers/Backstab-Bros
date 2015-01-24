using UnityEngine;
using System.Collections;

public class Elevator : Mechanism {

    public GameObject Platform;
    public GameObject Axis;
    public float Speed;

    private int _upward;
    private float _originalHeight;

    void Start()
    {
        _upward = 1;
        _originalHeight = Platform.transform.position.y;
    }

    protected override void runMechanism()
    {
        float height = Axis.transform.localScale.y;
        float dist = Platform.transform.position.y - Axis.transform.position.y;

        // si on est en haut, _upward = false
        if (Platform.transform.position.y - Axis.transform.position.y >= height)
            _upward = -1;
        else if (Platform.transform.position.y - Axis.transform.position.y <= -height)
            _upward = 1;

        Vector3 dir = new Vector3(0, 1, 0);

        Platform.transform.Translate(dir * Speed * _upward * Time.deltaTime);
    }

    protected override void backToDefaultPosition()
    {
        Vector3 dir = new Vector3(0, 1, 0);
        if (Platform.transform.position.y > _originalHeight)
            _upward = -1;
        else if (Platform.transform.position.y < _originalHeight)
            _upward = 1;
        else
            return;
        Platform.transform.Translate(dir * Speed * _upward * Time.deltaTime);
    }
}
