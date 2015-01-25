using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    //gameObject.GetComponent<AudioSource>().enabled = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>() != null)
        {
            other.gameObject.GetComponentInParent<Player>().Score++;
            //gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.audio.Play();
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 70 * Time.deltaTime, 0);
	}
}
