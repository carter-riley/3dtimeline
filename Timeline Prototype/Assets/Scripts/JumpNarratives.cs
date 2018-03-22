using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNarratives : MonoBehaviour {
	
	public void JumpToComingOfAge() {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, 353);
    }

    public void JumpToPhilanthropy() {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, 53);
    }

    public void JumpToGonzaga() {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 11, -247);
    }

    public void ResetToStart()
    {
        Camera.main.transform.position = new Vector3(-50, 11, Camera.main.transform.position.z);
    }
}
