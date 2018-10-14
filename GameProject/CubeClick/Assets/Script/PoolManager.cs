using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public GameObject m_ClickPrefab;
    public int m_ClickObjCacheNum = 10;

    private List<GameObject> m_ClickObjPool;
    // Use this for initialization

    void Start () {
        m_ClickObjPool = new List<GameObject>();
        for (int i = 0; i < 10; ++i)
        {
            GameObject obj = Instantiate(m_ClickPrefab);
            obj.SetActive(false);
            m_ClickObjPool.Add(obj);
        }
    }

    public GameObject GetClickObj()
    {
        if(m_ClickObjPool.Count > 0)
        {
            GameObject obj = m_ClickObjPool[0];
            m_ClickObjPool.Remove(obj);
            obj.SetActive(true);
            return obj;
        } else
        {
            return Instantiate(m_ClickPrefab);
        }
    }

    public void PutClickObj(GameObject obj)
    {
        if(!m_ClickObjPool.Contains(obj))
        {
            obj.SetActive(false);
            m_ClickObjPool.Add(obj);
        }
    }
    public static PoolManager instance;
    private void Awake()
    {
        instance = this;
    }
}
