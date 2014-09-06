using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public ParticleSystem fireCone;
	public float fireballForce = 10;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		fireCone.enableEmission = Input.GetKey(KeyCode.Space);
	}
}
