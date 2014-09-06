using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject fireballPrefab;
	public float fireballForce = 10;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Space))
		{
			GameObject fireball = GameObject.Instantiate(fireballPrefab, transform.position, transform.rotation) as GameObject;
			fireball.rigidbody.AddForce(transform.forward * fireballForce);
		}
	}
}
