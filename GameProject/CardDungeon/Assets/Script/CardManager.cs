using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour {

	public GameObject m_CardPrefab;
	public Vector2Int m_CardMapSize;
	public Vector2 m_CardInterval;
	private Vector2 m_CardSize;
	private List<GameObject> m_CardList;
	private Vector2 m_CardOffset;
	// Use this for initialization
	void Start () {
		if(m_CardPrefab == null) {
			Debug.Log("CardPrefab is null");
		}
		m_CardSize = m_CardPrefab.GetComponent<SpriteRenderer>().size;
		m_CardOffset = new Vector2(
			-((m_CardMapSize.x - 1) / 2f) * (m_CardSize.x + m_CardInterval.x),
			-((m_CardMapSize.y - 1) / 2f) * (m_CardSize.y + m_CardInterval.y)
		);
		CreateCardMap();
	}
	
	void CreateCardMap() {
		m_CardList = new List<GameObject>();
		for(int row = 0; row < m_CardMapSize.x; ++row) {
			for(int col = 0; col < m_CardMapSize.y; ++col) {
				GameObject tempObj = Instantiate(m_CardPrefab, transform);
				tempObj.transform.localPosition = new Vector3(
					col * (m_CardSize.x + m_CardInterval.x) + m_CardOffset.x, 
					row * (m_CardSize.y + m_CardInterval.y) + m_CardOffset.y, 0);
				tempObj.GetComponent<Card>().GridPos = new Vector2Int(col, row);
				m_CardList.Add(tempObj);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
