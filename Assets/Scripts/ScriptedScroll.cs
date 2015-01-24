using UnityEngine;
using System.Collections;

public class ScriptedScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    _perform = false;
        _inside = false;
	}

    //[SerializeField] private GameObject _player1;
    //[SerializeField] private GameObject _player2;
    private bool _inside;
    private bool _perform;

    void OnTriggerEnter(Collider other){

    }

    void OnTriggerExit(Collider other){

    }

	// Update is called once per frame
	void Update () {
	    if(_perform){
            //Camera.main.transform.Translate((_positionCible - Camera.main.transform.position)*4*Time.deltaTime);
        }
	}
}
