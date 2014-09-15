using UnityEngine;
using System.Collections;

public class UserTestToggles : MonoBehaviour {

	public float Height1 = 15;
	public float Height2 = 1;
	public CharacterController cc;
	public Attack attack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			cc.height = Height1;
			cc.gameObject.transform.position += new Vector3(0, Height1/2f, 0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			cc.height = Height2;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			attack.UseTap = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			attack.UseTap = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}


	}
}
