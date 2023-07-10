using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoldAndRelease : MonoBehaviour
{

    public GameObject cube2go;
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float force;
    public Transform HoldPos;
    public GameObject currentCube;


    private void Start()
    {
        StartCoroutine(spawnCube());

    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartPos = touch.position;
                Debug.Log(StartPos);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndPos = touch.position;
                currentCube.GetComponent<Rigidbody>().isKinematic = false;
                if (StartPos.y > EndPos.y)
                {
                    float forceValue = StartPos.y - EndPos.y;
                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, forceValue / 100f, 0f), ForceMode.Impulse);
                }
                if (StartPos.y < EndPos.y)
                {
                    float forceValue = EndPos.y - StartPos.y;
                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, forceValue / 100f, 0f), ForceMode.Impulse);
                }
                StartCoroutine(spawnCube());
            }
        }

    }
    IEnumerator spawnCube()
    {
        yield return new WaitForSeconds(2f);
        currentCube = Instantiate(cube2go, HoldPos.position, Quaternion.identity);
        currentCube.transform.position = HoldPos.position;
        currentCube.GetComponent<Rigidbody>().isKinematic = true;
    }



}