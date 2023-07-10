using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager2048 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == collision.gameObject.tag && gameObject.tag != "512")
        {
            TagManager2048.Instance.TagReturn(gameObject);
            Destroy(collision.gameObject);

        }
    }




}
