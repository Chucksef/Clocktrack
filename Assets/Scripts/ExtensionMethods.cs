using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods
{

    public static GameObject FindObject(this GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            Debug.Log(t.name);
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

}