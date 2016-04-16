using UnityEngine;
using System.Collections;

public class Yoda : MonoBehaviour {
	public Animator Exp, Exp1;

	void Boom() {
		Exp.SetTrigger("Shoot");
		Exp1.SetTrigger("Shoot");

	}
}
