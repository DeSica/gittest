using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Card : MonoBehaviour {

	public Sprite m_BackSprite;
	public Sprite m_FaceSprite;
	private Collider2D m_Collider2D;
	private SpriteRenderer m_SpriteRenderer;
	private Vector2Int m_GridPos;
	// Use this for initialization
	void Start () {
		m_Collider2D = GetComponent<Collider2D>();
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
	}
	private void OnMouseDown() {
		m_Collider2D.enabled = false;
		transform.DOLocalRotate(90 * Vector3.up, 0.2f).onComplete = () => {
			m_SpriteRenderer.sprite = m_FaceSprite;
			transform.DOLocalRotate(Vector3.zero, 0.2f);
		};
	}
	public Vector2Int GridPos {
		set {
			m_GridPos = value;
		}
		get {
			return m_GridPos;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
