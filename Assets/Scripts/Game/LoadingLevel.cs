using System;
using UnityEngine;
using System.Collections;

public class LoadingLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Load(String level)
    {
        Application.LoadLevel(level);
    }
    public void Load(int level)
    {
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
