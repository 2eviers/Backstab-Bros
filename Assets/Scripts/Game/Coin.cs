using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<Player>().Score++;
        Destroy(gameObject);
        
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 0, 70*Time.deltaTime);
	}
}
