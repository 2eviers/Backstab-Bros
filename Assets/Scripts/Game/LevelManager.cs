using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _end = false;
        _finishP1 = false;
        _finishP2 = false;
	    _deathType = Camera.main.GetComponent<DeathType>();
	}

    //[SerializeField] private GameObject _player1;
    //[SerializeField] private GameObject _player2;
    private DeathType _deathType;
    private bool _end;
    private bool _finishP1;
    private bool _finishP2;

    //utilisation de deathtype
    //dans le trigger on cherche lequel et on regarde ceux qui sont en vie.

    private void EndLevel()
    {
        if (_deathType.Player1State != DeathType.PlayerState.Alive && _deathType.Player1State != DeathType.PlayerState.Alive)
            _end = true;
        if (_finishP1 && _finishP2)
            _end = true;
        if (_finishP1 && _deathType.Player2State != DeathType.PlayerState.Alive)
            _end = true;
        if (_finishP2 && _deathType.Player1State != DeathType.PlayerState.Alive)
            _end = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J1")
            _finishP1 = true;
        if (other.gameObject.GetComponentInParent<Player>()._prefixController == "J2")
            _finishP2 = true;
    }

    private void EndProceed(){
        if(_end)
            Debug.Log("end");
    }

	// Update is called once per frame
	void Update () {
        EndLevel();
        EndProceed();
	}
}
