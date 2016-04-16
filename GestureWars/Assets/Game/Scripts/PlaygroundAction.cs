using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class PlaygroundAction : MonoBehaviour {
	public delegate void CallBack();
	public static event CallBack GameScore_event;
	public static event CallBack GameOver_event;
	public Animator WinAnim;
	private bool winner = true;
	private string[] DarthSays = { "No, i am your father", "i have you now", "you underestimate the power of the Dark Side.", "i find your lack of faith disturbing", "impressive. most impressive.", " obi-wan has taught you well.", "you have controlled your fear.", " now, release your anger.", "join the darck side" };
	public Text Timer;
	public Text ScoreT;
	public Text EndScore;
	public Image StatusBar;
	public Text DarthSay;
	public int score_int = 0;
	public int leveltime = 40;
	public int leveltimeStep = 4;
	private float current_time = 0;
	private float time = 0;
	public PlayerDraw playerDraw;
	public TaskManager targManager;



	void OnEnable() {
		GUIManager.OnGameBegin_event += Init;
	}

	void OnDisable() {
		GUIManager.OnGameBegin_event -= Init;
	}

	void Init() {
		targManager.Init();
		DarthSay.DOFade(0, 0);
		winner = false;
	}

	void Update() {
		if (!winner) {
			current_time += Time.deltaTime;
			Timer.text = System.String.Format("{0:00}", leveltime - current_time);

			StatusBar.fillAmount = (leveltime - current_time) / leveltime;
			if ((leveltime - current_time) <= 0) {
				Timer.text = "0";
				GameOver();
			}
		}
	}

	public void Score() {
		score_int++;
		ScoreT.text = score_int.ToString();
		EndScore.text = score_int.ToString();

	}

	public void GameOver() {
		if (!winner) {
			winner = true;
			WinAnim.SetTrigger("Shoot");
			DG.Tweening.DOVirtual.DelayedCall(3.5f, delegate {
				if (GameOver_event != null) {
					GameOver_event();
				}
			});
		}

	}

	private void DarthQuotes() {
		DarthSay.DOKill();
		DarthSay.text = DarthSays[Random.Range(0, DarthSays.Length)];
		DarthSay.DOFade(1, .5f);
		StartCoroutine(FinnishAnimation(2.0f));
	}


	IEnumerator FinnishAnimation(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		DarthSay.DOFade(0, .5f);
	}

	private void Time4Gesture() {
		leveltime = leveltime > leveltimeStep ? leveltime - leveltimeStep : leveltimeStep;
		current_time = 0;

	}

	void OnCustomGesture(PointCloudGesture gestures) {
		if (!winner) {
			Debug.Log(gestures.RecognizedTemplate.name);
			if (gestures.RecognizedTemplate.name.Equals(targManager.currentName)) {
				targManager.GetNextGesture();
				Score();
				GameScore_event();
				DarthQuotes();
				Time4Gesture();
			}

		}
	}
}
