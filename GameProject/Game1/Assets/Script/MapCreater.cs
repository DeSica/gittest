using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour {
    public GameObject m_Grid;
    public int m_Row;
    public int m_Col;
    public float m_IntervalX;
    public float m_IntervalY;
    public float m_StaggerY;
    // Use this for initialization
    void Start () {
		for(int i = 0; i < m_Row; ++i)
        {
            for(int j = 0; j < m_Col; ++j)
            {
                GameObject GridObj = Instantiate(m_Grid, transform);
                GridObj.transform.localPosition = new Vector3(
                    j * m_IntervalX,
                    i * m_IntervalY + (j % 2 == 1 ? m_StaggerY : 0));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
