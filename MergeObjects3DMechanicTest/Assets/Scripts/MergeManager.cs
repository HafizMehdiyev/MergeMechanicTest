using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == collision.gameObject.tag && gameObject.tag != "Last")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            gameObject.tag = TagManager.Instance.TagReturn(gameObject.tag,transform);
        }
    }

}
