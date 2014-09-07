using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour {

	// Use this for initialization

	public float ParticleForce = 1000f;
	private void OnParticleCollision(GameObject other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb != null) 
		{
			Vector3 dir = other.transform.position - transform.position;
			rb.AddForce(dir.normalized * ParticleForce);
		}
	}




}
