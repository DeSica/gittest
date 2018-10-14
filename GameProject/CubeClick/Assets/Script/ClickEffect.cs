using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickEffect : MonoBehaviour {

    public float m_EndRadius = 1;
    public float m_EndEffectTime = 1;

    CircleCollider2D m_Collider;
    float m_InitialRadius;
    Tweener m_EffectTweener;
	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<CircleCollider2D>();
        m_EffectTweener = DOTween.To(() => m_Collider.radius, x => m_Collider.radius = x, m_EndRadius, m_EndEffectTime);
        m_EffectTweener.onComplete = () =>
        {
            m_EffectTweener.Restart();
            m_EffectTweener.WaitForStart();
            PoolManager.instance.PutClickObj(gameObject);
        };
        m_EffectTweener.WaitForStart();
    }
	public void PlayEffect()
    {
        m_EffectTweener.Play();
    }
}
