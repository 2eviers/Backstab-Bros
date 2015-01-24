﻿using System;
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
        var max = Mathf.Tan(Camera.main.fieldOfView/2)*(_player1.transform.position.z - Camera.main.transform.position.z);
        return pixel/max;
    }

    /// <summary>
    /// Joueur suivi
    /// </summary>
    private void SelectPlayer()
    {
        if (_forward)
            _SelectedPlayer = _player1.transform.position.x > _player2.transform.position.x ? _player1 : _player2;
        else
            _SelectedPlayer = _player1.transform.position.x < _player2.transform.position.x ? _player1 : _player2;
    }

    /// <summary>
    /// Changement de suivi de caméra
    /// </summary>
    private void Switch()
    {
        if (_forward)
        {
            if (LocalPosition(_SelectedPlayer) < 0.25)
                _forward = false;
        }
        if (_forward)
        {
            if (LocalPosition(_SelectedPlayer) > 0.75)
                _forward = true;
        }
    }

    private void SetPosition()
    {
        _positionCible = new Vector3(_SelectedPlayer.transform.position.x, _SelectedPlayer.transform.position.y, Camera.main.transform.position.z);
    }

    private void Move()
    {
        Camera.main.transform.Translate(_positionCible*Time.deltaTime);
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
