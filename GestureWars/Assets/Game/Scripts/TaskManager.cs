using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class TaskManager : MonoBehaviour {

	public List<Sprite> gesture = new List<Sprite>();
	public string currentName = "";
	public Image currentSprite;


	public void Init()
	{
		GetNextGesture();
    }

	public void GetNextGesture()
	{
		currentSprite.DOKill();
		currentSprite.DOFade(0,.5f).OnComplete(delegate {
		Sprite obj = gesture[Random.Range(0, gesture.Count)];
		currentName = obj.texture.name;
		currentSprite.sprite = obj;
			currentSprite.DOFade(1, 2f).OnComplete(delegate {
				currentSprite.DOFade(.2f, .5f).SetLoops(10, LoopType.Yoyo);

			});
		});
    }
	
}
