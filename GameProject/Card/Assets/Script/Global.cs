using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Global : MonoBehaviour {
	public static void RemoveChildrenByComponentType(Transform parent, Type componentType)
	{
		Component[] cptArr = parent.GetComponentsInChildren(componentType, true);
		parent.DetachChildren();
		foreach(Component cpt in cptArr)
		{
			if(cpt.transform != parent)
			{
				Destroy(cpt.gameObject);
			}
		}
	}
	public static Vector2 GetSpriteObjWorldSize(GameObject spriteObj)
	{
		Sprite sp = spriteObj.GetComponent<SpriteRenderer>().sprite;
		Vector3 scale = spriteObj.transform.localScale;
		return new Vector2(sp.rect.width / sp.pixelsPerUnit * scale.x, sp.rect.height / sp.pixelsPerUnit * scale.y);
	}
}
