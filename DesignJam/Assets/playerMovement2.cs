using UnityEngine;
using System.Collections;

public class playerMovement2 : MonoBehaviour {

	public float time = 800;

	public void Start()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("playerMovement"), "time", time));
		Debug.Log ("Debug");
	}
}
