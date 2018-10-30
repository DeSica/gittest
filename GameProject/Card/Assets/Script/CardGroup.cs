using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardGroup : MonoBehaviour {

	public GameObject CardPrefab;
	public float GroupWidth;
	public Vector3 CardBegainPos;
	public Vector3 SelectCardPos;
	public Vector2 SelectCardScale;
	List<GameObject> CardList;
	float CardWidth;
	GameObject SelectCardObj;
	int SelectCardIndex;
	Vector2 CardNormalScale;
	// Use this for initialization
	void Start () {
		CardList = new List<GameObject>();
		CardWidth = Global.GetSpriteObjWorldSize(CardPrefab).x;
		CardNormalScale = CardPrefab.transform.localScale;
	}
	

	public void DrawCard()
	{
		GameObject card = Instantiate(CardPrefab);
		card.transform.SetParent(transform);
		card.transform.localPosition = CardBegainPos;
		CardList.Add(card);
		ArrangeCard();
	}

	void ArrangeCard()
	{
		int totalNum = CardList.Count - 1;
		float leftOffest = Mathf.Max(-totalNum / 2.0f * CardWidth, -GroupWidth / 2.0f);
		float interval = totalNum > 0 ? Mathf.Min(GroupWidth / totalNum, CardWidth) : 0;
		for(int i = 0; i < CardList.Count; ++i)
		{
			CardList[i].transform.DOLocalMove(new Vector3(leftOffest + i * interval, 0, -i / 1000), 0.5f);
		}
	}

	public void SelectCard(GameObject selectCard)
	{
		if(selectCard != SelectCardObj)
		{
			CancelSelect();
			int index = CardList.IndexOf(selectCard);
			SelectCardIndex = index;
			SelectCardObj = CardList[index];
			CardList.RemoveAt(index);
			selectCard.transform.DOLocalMove(SelectCardPos, 0.5f);
			selectCard.transform.DOScale(SelectCardScale, 0.5f);
			ArrangeCard();
		}
	}
	void CancelSelect()
	{
		if(SelectCardObj)
		{
			CardList.Insert(SelectCardIndex, SelectCardObj);
			SelectCardObj.transform.DOScale(CardNormalScale, 0.5f);
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
