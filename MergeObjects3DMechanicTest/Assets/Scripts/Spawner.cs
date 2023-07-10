using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TagManager;

public class Spawner : SingletoneBase<Spawner>
{
    public List<GameObject> Cubes;
    public void SpawnNewObject(string name,Transform pos)
    {
        GameObject gameObjectByName = Cubes.Find(obj => obj.name == name);
        Instantiate(gameObjectByName,new Vector3(pos.position.x,pos.position.y,pos.position.z),Quaternion.identity);
    }
}
