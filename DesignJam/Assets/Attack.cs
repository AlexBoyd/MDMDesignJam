using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public ParticleSystem fireCone;
	public float fireballLength = 0.2f;
	public float fireballCooldown = 0.4f;

	private bool isShooting = false;


	void Start()
	{
		fireCone.enableEmission = false;
		}
	// Update is called once per frame
	void Update () 
	{
		if (!isShooting && Input.GetKeyUp(KeyCode.Space)) {
			StartCoroutine(FireCooldown());		
		}
	}

	private IEnumerator FireCooldown()
	{
		isShooting = true;
		fireCone.enableEmission = true;
		yield return new WaitForSeconds(fireballLength);
		fireCone.enableEmission = false;
		yield return new WaitForSeconds(fireballCooldown);
		isShooting = false;
	}
}
