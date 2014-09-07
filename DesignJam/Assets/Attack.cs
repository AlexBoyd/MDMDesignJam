using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Attack : MonoBehaviour {

	public ParticleSystem fireCone;
	public ParticleSystem shockWave;
	public float fireballLength = 0.2f;
	public float fireballCooldown = 0.4f;

	public static bool Tapped {get; set;}
	
	// Tap calculation variables 
	public float RequiredMultipleOfAverage = 4;
	public int MinMagnitudeToCheck = 1;
	public int NumAccelerationSamples = 6;
	public Queue<float> YAccels = new Queue<float>();
	public List<float> Dadtvalues = new List<float>();
	
	// 
	private float lastXAccel = 0;
	private float lastYAccel = 0;
	private float lastZAccel = 0;


	private bool isShooting = false;
	
	void Start()
	{
		fireCone.enableEmission = false;
		shockWave.enableEmission = false;
		}
	// Update is called once per frame
	void Update () 
	{
		//Update y accelerations
		if (OVRDevice.GetAcceleration(ref lastXAccel, ref lastYAccel, ref lastZAccel))
		{
			YAccels.Enqueue(lastYAccel);
			
			if(YAccels.Count > NumAccelerationSamples)
			{
				YAccels.Dequeue();
			}
		}
		if(YAccels.Count == NumAccelerationSamples)
		{
			
			//Update differences
			Dadtvalues.Clear();
			
			for (int i = 1; i < YAccels.Count; i++)
			{
				Dadtvalues.Add(Mathf.Abs(YAccels.ElementAt(i) - YAccels.ElementAt(i-1)));
			}
			
			//Check for taps
			float avg = Dadtvalues.Average((val) => Mathf.Abs(val));
			Tapped = Dadtvalues.Any(val => Mathf.Abs(val) > avg * RequiredMultipleOfAverage && Mathf.Abs(val) > MinMagnitudeToCheck); 
			
		}

		if (!isShooting && Tapped) {
			StartCoroutine(FireCooldown());		
			shockWave.Emit(100);
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
