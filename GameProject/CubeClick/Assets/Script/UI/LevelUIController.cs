using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour {

	public Button[] m_LevelBtnArr;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < m_LevelBtnArr.Length; ++i)
		{
			int _LevelIndex = i;
			m_LevelBtnArr[i].onClick.AddListener(() => {
				GameManager.Instance.ShowLevel(_LevelIndex);
				GameManager.Instance.HidePanel(PanelType.LevelPanel);
				GameManager.Instance.ShowPanel(PanelType.GamePanel);
			});
		}
	}
	
}
