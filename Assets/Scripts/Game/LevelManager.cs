using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _end = false;
        _finishP1 = false;
        _finishP2 = false;
	    _respawn = false;
	    _deathType = Camera.main.GetComponent<DeathType>();
        //_deathType.Player1.GetComponent<Player>().
	}

    //[SerializeField] private GameObject _player1;
    //[SerializeField] private GameObject _player2;
    private DeathType _deathType;
    private bool _end;
    private bool _finishP1;
    private bool _finishP2;
    private bool _respawn;

    //utilisation de deathtype
    //dans le trigger on cherche lequel et on regarde ceux qui sont en vie.

    private void EndLevel()
    {
        if (_deathType.Player1State != DeathType.PlayerState.Alive &&
            _deathType.Player2State != DeathType.PlayerState.Alive)
            //_end = true;
            _respawn = true;
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

    private void Respawn()
    {
        if (_respawn)
        {
            _deathType.Player1.GetComponent<Player>().enabled = true;
            _deathType.Player1.GetComponent<Player>().ressucite();
            _deathType.Player1State = DeathType.PlayerState.Alive;

            _deathType.Player2.GetComponent<Player>().enabled = true;
            _deathType.Player2.GetComponent<Player>().ressucite();
            _deathType.Player2State = DeathType.PlayerState.Alive;

            _respawn = false;
        }
    }

    private void Upgrade()
    {
        _deathType.Player1.GetComponentInChildren<PushAttack>().pushForceRatioX +=
            _deathType.Player1.GetComponentInChildren<PushAttack>().InitPushX*0.0025f*
            _deathType.Player1.GetComponentInParent<Player>().Score;

        _deathType.Player1.GetComponentInChildren<PushAttack>().pushForceRatioY +=
            _deathType.Player1.GetComponentInChildren<PushAttack>().InitPushY * 0.0025f *
            _deathType.Player1.GetComponentInParent<Player>().Score;

        _deathType.Player1.GetComponentInParent<Player>().Score = 0;

        _deathType.Player2.GetComponentInChildren<PushAttack>().pushForceRatioX +=
            _deathType.Player2.GetComponentInChildren<PushAttack>().InitPushX * 0.0025f *
            _deathType.Player2.GetComponentInParent<Player>().Score;

        _deathType.Player2.GetComponentInChildren<PushAttack>().pushForceRatioY +=
            _deathType.Player2.GetComponentInChildren<PushAttack>().InitPushY * 0.0025f *
            _deathType.Player2.GetComponentInParent<Player>().Score;

        _deathType.Player2.GetComponentInParent<Player>().Score = 0;
    }

    private void EndProceed(){
        if (_end)
        {
            if (_finishP1 && _deathType.Player2State != DeathType.PlayerState.Alive)
                _deathType.Player1.GetComponentInParent<Player>().Score += 40;
            if (_finishP2 && _deathType.Player1State != DeathType.PlayerState.Alive)
                _deathType.Player2.GetComponentInParent<Player>().Score += 40;
            if (_finishP1 && _finishP2)
            {
                _deathType.Player1.GetComponentInParent<Player>().Score += 20;
                _deathType.Player2.GetComponentInParent<Player>().Score += 20;
            }
            if(_deathType.Player1State == DeathType.PlayerState.Suicide)
                _deathType.Player1.GetComponentInParent<Player>().Score -= 20;
            if (_deathType.Player2State == DeathType.PlayerState.Suicide)
                _deathType.Player2.GetComponentInParent<Player>().Score -= 20;
            Upgrade();
            Application.LoadLevel("Level2");
        }
        
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(_deathType.Player1State);
        Debug.Log(_deathType.Player2State);
        Debug.Log(_respawn);
        EndLevel();
        EndProceed();
        Respawn();
	}
}
