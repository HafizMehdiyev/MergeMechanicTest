using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TagManager : SingletoneBase<TagManager>
{
    public string TagReturn(string name, Transform SpawnPos)
    {

        Tags tag = (Tags)Enum.Parse(typeof(Tags), name);
        int returnNumber = (int)tag * 2;
        string ObjName = Enum.GetName(typeof(Tags), returnNumber);
        Spawner.Instance.SpawnNewObject(ObjName, SpawnPos);
        return ObjName;
    }
    public enum Tags : int
    {
        ObjectA = 2,
        ObjectB = 4,
        ObjectC = 8,
        ObjectD = 16,
        ObjectE = 32,
        Last = 64
    }
}
