using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickEffect : MonoBehaviour {

    public float m_EndRadius = 100;
    public float m_EndEffectTime = 1;
    public float m_EffectPower = 2000;
    CircleCollider2D m_Collider;
    Tweener m_EffectTweener;
	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<CircleCollider2D>();
        m_EffectTweener = DOTween.To(() => m_Collider.radius, x => m_Collider.radius = x, m_EndRadius, m_EndEffectTime);
        m_EffectTweener.onComplete = () =>
        {
            m_EffectTweener.Restart();
            m_EffectTweener.Pause();
            PoolManager.instance.PutClickObj(gameObject);
        };
        //m_EffectTweener.Pause();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerCube")
        {
            Rigidbody2D rigid = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 a1 = (other.gameObject.transform.position - transform.position).normalized;
            rigid.AddForce(a1 * m_EffectPower);
        }
    }
	public void PlayEffect() 
    {
        m_EffectTweener.Play();
    }
}
