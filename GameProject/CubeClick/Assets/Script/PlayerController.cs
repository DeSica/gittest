using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject obj = PoolManager.instance.GetClickObj();
            obj.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
            obj.GetComponent<ClickEffect>().PlayEffect();
        }
    }


    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }
}
