using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			CardGroup.Instance.DrawCard();
		}
		if(Input.GetMouseButtonDown(1))
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit2D = Physics2D.Raycast(pos, Vector2.zero);
			if(hit2D.collider.GetComponent<Card>())
			{
				CardGroup.Instance.SelectCard(hit2D.collider.gameObject);
			}
		}
	}
}
