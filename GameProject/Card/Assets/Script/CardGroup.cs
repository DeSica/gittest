using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardGroup : MonoBehaviour {

	public GameObject CardPrefab;
	public float GroupWidth;
	public Vector3 CardBegainPos;
	List<GameObject> CardList;
	float CardWidth;
	// Use this for initialization
	void Start () {
		CardList = new List<GameObject>();
		SpriteRenderer sr = CardPrefab.GetComponent<SpriteRenderer>();
		CardWidth = Global.GetSpriteObjWorldSize(CardPrefab).x;
	}
	

	public void DrawCard()
	{
		GameObject card = Instantiate(CardPrefab);
		card.transform.SetParent(transform);
		card.transform.localPosition = CardBegainPos;

		int totalNum = CardList.Count;
		float leftOffest = Mathf.Max(-totalNum / 2.0f * CardWidth, -GroupWidth / 2.0f);
		float interval = Mathf.Min(GroupWidth / totalNum, CardWidth);
		CardList.Add(card);
		for(int i = 0; i < CardList.Count; ++i)
		{
			CardList[i].transform.DOLocalMove(new Vector3(leftOffest + i * interval, 0, -i / 1000), 0.5f);
		}
	}
	public void PlayCard()
	{

	}
	// Update is called once per frame
	void Update () {
		
	}
	public static CardGroup Instance = null;
	private void Awake() {
		Instance = this;
	}
}
