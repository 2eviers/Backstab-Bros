using UnityEngine;
using System.Collections;

public class MiniCamera : MonoBehaviour {

    void Start()
    {
        _camera = gameObject.GetComponent<Camera>();
    }

    [SerializeField]
    private RenderTexture _renderTexture;
    private Camera _camera;

    // Update is called once per frame
    void Update()
    {
        _camera.targetTexture = _renderTexture;
    }
}
