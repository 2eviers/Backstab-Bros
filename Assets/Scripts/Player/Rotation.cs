using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	bool right;
	public float rotatespeed = 45f;

	// Use this for initialization
	void Start () {
		right = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float yAngle = transform.rotation.y;
		float deltaYAngle;
		float targetAngle = right ? 0 : 180;
		deltaYAngle = targetAngle-yAngle;

		float maxAngle = rotatespeed * Time.fixedDeltaTime;
		Quaternion temporaryQuaternion = transform.rotation;
		if (maxAngle > Mathf.Abs (deltaYAngle))
						temporaryQuaternion.y = targetAngle;
		else {
			temporaryQuaternion.y += maxAngle;
		}
		transform.rotation = temporaryQuaternion;
	}
	//*/
	public void turn(){
		right = !right;
	}
	//*/
	//*/
	public void turn(bool right){
		this.right = right;
	}
	//*/
}
