using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace UnityEngine
{

	public class Global : MonoBehaviour {
		public static void RemoveChildrenByComponentType(Transform parent, Type ComponentType)
		{
			Component[] cptArr = parent.GetComponentsInChildren(ComponentType, true);
			parent.DetachChildren();
			foreach(Component cpt in cptArr)
			{
				if(cpt.transform != parent)
				{
					Destroy(cpt.gameObject);
				}
			}
		}
	}
}
