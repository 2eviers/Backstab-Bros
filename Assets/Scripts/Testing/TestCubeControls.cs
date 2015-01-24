using UnityEngine;
using System.Collections;

public class TestCubeControls : MonoBehaviour
{

    private Vector3 _Direction;
    private int Speed = 3;

    void Start()
    {
    }

    void GetInput()
    {
        _Direction = new Vector3(0, 0, 0);

        // Continuous movement with Arrows
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _Direction.x += 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _Direction.z -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _Direction.x -= 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _Direction.z += 1;
        }

        if (_Direction != new Vector3(0, 0, 0))
        {
            this.transform.Translate(- _Direction * Time.deltaTime * Speed);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("oki cube collision");
    }

    void Update()
    {
        GetInput();
    }
}

