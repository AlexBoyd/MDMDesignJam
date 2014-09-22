using UnityEngine;
using System.Collections;

public class walkSound : MonoBehaviour {

	public CharacterController opc = null;
	public AudioSource walkSource = null;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (opc.velocity.sqrMagnitude);
		if (opc.velocity.sqrMagnitude > 0.5f) 
		{
			if(!walkSource.isPlaying)
			{
				walkSource.Play();
			}
		}
		else
		{
			walkSource.Stop();
		}

						
	}
}
