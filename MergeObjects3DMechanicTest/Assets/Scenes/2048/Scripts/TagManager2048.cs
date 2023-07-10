using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class TagManager2048 : SingletoneBase<TagManager2048>
{
    public List<Material> mats;
    public void TagReturn(GameObject obj)
    {
        int index = int.Parse(obj.tag);
        int returnTag = (index * 2);
        obj.tag = returnTag.ToString();
        Material materialByName = mats.Find(obj => obj.name == returnTag.ToString());
        obj.GetComponent<Renderer>().material = materialByName;


    }





}
