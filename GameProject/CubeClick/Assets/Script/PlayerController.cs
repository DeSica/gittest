using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool m_ClickLock = false;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !m_ClickLock)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if(hit && hit.collider.gameObject.tag == "ClickBG") 
            {
                GameObject obj = PoolManager.instance.GetClickObj();
                obj.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
                obj.GetComponent<ClickEffect>().PlayEffect();
                GameUIController.m_Instance.AddTouchCount(1);
            }
        }
    }

    public void SetClickLock(bool _Lock)
    {
        m_ClickLock = _Lock;
    }
    public static PlayerController m_Instance;
    private void Awake()
    {
        m_Instance = this;
    }
}
