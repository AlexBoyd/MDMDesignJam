using UnityEngine;
using System.Collections;

public class playerMovement2 : MonoBehaviour {

	public void Start()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("playerMovement"), "time", 1000));
	}
}
