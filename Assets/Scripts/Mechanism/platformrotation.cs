using UnityEngine;
using System.Collections;

public class platformrotation :  Mechanism {

    protected override void runMechanism()
    {
        if (gameObject.transform.eulerAngles.z < 90 - 30 * Time.deltaTime)
            gameObject.transform.Rotate(0, 0, 30 * Time.deltaTime);
    }

}
