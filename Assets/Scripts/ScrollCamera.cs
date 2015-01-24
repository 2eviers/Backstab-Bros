using System;
using UnityEngine;
using System.Collections;

public class ScrollCamera : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    _forward = true;
        _positionCible = new Vector3(_player1.transform.position.x, _player1.transform.position.y, Camera.main.transform.position.z);
	}

    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    private bool _forward;
    private GameObject _SelectedPlayer;
    private Vector3 _positionCible;

    /// <summary>
    /// calcul la position en pourcentage de l'écran
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private float LocalPosition(GameObject player)
    {
        float pixel = player.transform.position.x - Camera.main.transform.position.x;
        var max = Mathf.Tan((Mathf.Deg2Rad*Camera.main.fieldOfView)/2)*(_player1.transform.position.z - Camera.main.transform.position.z);
        return pixel/max;
    }

    /// <summary>
    /// Joueur suivi
    /// </summary>
    private void SelectPlayer()
    {
        if (_player1 != null && _player2 != null)
        {
            //if (_forward)
            //    _SelectedPlayer = _player1.transform.position.x > _player2.transform.position.x ? _player1 : _player2;
            //else
            //    _SelectedPlayer = _player1.transform.position.x < _player2.transform.position.x ? _player1 : _player2;
            _SelectedPlayer = _player1.transform.position.x > _player2.transform.position.x ? _player1 : _player2;
        }
        else
        {
            if (_player1 != null)
                _SelectedPlayer = _player1;
            if (_player2 != null)
                _SelectedPlayer = _player2;
        }
    }

    /// <summary>
    /// Changement de suivi de caméra
    /// </summary>
    private void Switch()
    {
        if (_forward && LocalPosition(_SelectedPlayer) < -0.8)
            _forward = false;
           
        if (!_forward && LocalPosition(_SelectedPlayer) > 0.8)
                _forward = true;
        //if(!_forward && (LocalPosition(_player1) > 1.5 || LocalPosition(_player2) > 1.5))
        //    _forward = true;
    }

    private void SetPosition()
    {
        if(_forward && LocalPosition(_SelectedPlayer) > 0)
            _positionCible = new Vector3(_SelectedPlayer.transform.position.x, _SelectedPlayer.transform.position.y, Camera.main.transform.position.z);
        if (!_forward && LocalPosition(_SelectedPlayer) < 0)
            _positionCible = new Vector3(_SelectedPlayer.transform.position.x, _SelectedPlayer.transform.position.y, Camera.main.transform.position.z);
    }

    private void Move()
    {
        Camera.main.transform.Translate((_positionCible - Camera.main.transform.position)*4*Time.deltaTime);
    }

	// Update is called once per frame
	void Update ()
	{
        SelectPlayer();
        Switch();
        SetPosition();
        Move();
	}
}
