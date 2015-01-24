using UnityEngine;
using System.Collections;

public class ScriptedScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    _player1 = false;
	    _player2 = false;
        _positionCible = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
	}

    private bool _player1;
    private bool _player2;
    [SerializeField] private Vector3 _positionCible; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J1")
            _player1 = true;
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J2")
            _player2 = true;
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J1")
            _player1 = false;
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J2")
            _player2 = false;
    }

    private void SetCamera()
    {
        if (_player1 && _player2)
        {
            Camera.main.GetComponent<ScrollCamera>().enabled = false;
            Camera.main.transform.Translate((_positionCible - Camera.main.transform.position)*1*Time.deltaTime);
        }
        
        if (!_player1 && !_player2)
            Camera.main.GetComponent<ScrollCamera>().enabled = true;
    }


	// Update is called once per frame
	void Update () {
            SetCamera();
    }
}

