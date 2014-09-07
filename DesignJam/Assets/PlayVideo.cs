using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public MovieTexture VideoFile = null;
	// Use this for initialization
	void OnGUI () 
	{

		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),VideoFile,ScaleMode.StretchToFill);
	}

	void Awake ()
	{
		VideoFile.Play ();
		audio.clip = VideoFile.audioClip;
		audio.Play ();
		}
	
	// Update is called once per frame
	void Update () 
	{
		if (!VideoFile.isPlaying) {
			Application.LoadLevel(1);		
		}
	}
}
