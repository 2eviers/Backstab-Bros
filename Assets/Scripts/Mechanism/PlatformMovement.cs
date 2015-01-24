using UnityEngine;
using System.Collections;

public class PlatformMovement : Mechanism {

    public float MovementRange;

    private float Speed = 5;
    private float _timer;
    private Vector3 _direction;
    private float _initialPosition;
    private int _leftFrequency;
    private int _rightFrequency;
    private int _right;

	void Start () {
        _timer = 0;
        _initialPosition = transform.position.x;
        _leftFrequency = 1;
        _rightFrequency = 1;
        _direction = new Vector3(1, 0, 0);
	}

    // Random Movement (with some probability calculus to ensure it doesn't 
    // always go to the same fucking side)
    protected override void backToDefaultPosition()
    {
        _timer += Time.deltaTime;        

        // Randomly change the direction every .7s
        if (_timer > .7)
        {
            float ra = Random.Range(0, 101);

            // Probability to move left = 1 - _rightFrequency / (2 * _leftFrequency)
            // Probability to move right = _rightFrequency / (2 * _leftFrequency) 
            if (ra > 100 - _rightFrequency / (2 * _leftFrequency))
                _direction = new Vector3(-1, 0, 0);
            else
                _direction = new Vector3(1, 0, 0);

        }

        // Can't go farther than allowed range
        if (transform.position.x > _initialPosition + MovementRange / 2)
        {
            _direction = new Vector3(-1, 0, 0);
            _rightFrequency++;
        }
        else if (transform.position.x < _initialPosition - MovementRange / 2)
        {
            _direction = new Vector3(1, 0, 0);
            _leftFrequency++;
        }

        rigidbody.MovePosition(transform.position + _direction * Speed * Time.deltaTime);
    }

    // Common patrol movement in the allowed range
    protected override void runMechanism()
    {
        if (transform.position.x > _initialPosition + MovementRange / 2)
        {
            _direction = new Vector3(-1, 0, 0);
        }
        else if (transform.position.x < _initialPosition - MovementRange / 2)
        {
            _direction = new Vector3(1, 0, 0);
        }

        transform.Translate(_direction * Speed * Time.deltaTime);
    }
}
