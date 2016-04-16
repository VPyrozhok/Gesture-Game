using UnityEngine;
using System.Collections;

public class Dart : MonoBehaviour {
	private Animator DartAnim;

	void Awake() {
		DartAnim = GetComponent<Animator>();
	}


	void OnEnable() {
		GUIManager.OnGameBegin_event += Init;
		PlaygroundAction.GameScore_event += Hit;
	}

	void OnDisable() {
		GUIManager.OnGameBegin_event -= Init;
		PlaygroundAction.GameScore_event -= Hit;
	}


	void Init() {
		DartAnim.SetTrigger("Init");
	}
	void Hit() {
		DartAnim.SetTrigger("Hit");
	}

}
