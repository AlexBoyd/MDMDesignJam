using UnityEngine;
using System.Collections;

public class CustomFoV : MonoBehaviour {

	public float VertFOV;
	public OVRCameraController ovrCam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ovrCam.VerticalFOV = VertFOV;
	}
}
