using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HoldAndRelease : SingletoneBase<HoldAndRelease>
{
    public static UnityAction OnReadyToSpawn;
    public GameObject cube2go;
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float force;
    public Transform HoldPos;
    public GameObject currentCube;
    public float lastCollisionTime = 0f;
    private float timer = 0f;
    public float cooldown = 5f;
    private bool isActive = false;



    private void Start()
    {
        OnReadyToSpawn += StartSpawnCube;
        OnReadyToSpawn?.Invoke();
    }
    private void Update()
    {

        TouchController();
        //OnReadyToSpawn?.Invoke();

    }


    private void TouchController()
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
                OnReadyToSpawn?.Invoke();
                EndPos = touch.position;
                currentCube.GetComponent<Collider>().isTrigger = false;
                currentCube.GetComponent<Rigidbody>().isKinematic = false;
                if (StartPos.y > EndPos.y)
                {
                    float forceValue = StartPos.y - EndPos.y;
                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, forceValue / 50f, 0f), ForceMode.Impulse);
                }
                if (StartPos.y < EndPos.y)
                {
                    float forceValue = EndPos.y - StartPos.y;
                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, -(forceValue / 50f), 0f), ForceMode.Impulse);
                }
                if (StartPos.y > EndPos.y && StartPos.x > EndPos.x) //saga ve yuxari gedir
                {
                    float forceUp = StartPos.y - EndPos.y;
                    float forceSide = StartPos.x - EndPos.x;

                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(forceSide / 50f, forceUp / 50f, 0f), ForceMode.Impulse);
                }

                if (StartPos.y < EndPos.y && StartPos.x > EndPos.x) //saga ve asagi gedir
                {
                    float forceUp = EndPos.y - StartPos.y;
                    float forceSide = StartPos.x - EndPos.x;

                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(forceSide / 50f, -(forceUp / 50f), 0f), ForceMode.Impulse);
                }

                if (StartPos.y < EndPos.y && EndPos.x > StartPos.x) //sola ve asagi gedir
                {
                    float forceUp = EndPos.y - StartPos.y;
                    float forceSide = EndPos.x - StartPos.x;

                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-(forceSide / 50f), -(forceUp / 50f), 0f), ForceMode.Impulse);
                }

                if (StartPos.y > EndPos.y && EndPos.x > StartPos.x) //sola ve yuxari gedir
                {
                    float forceUp = StartPos.y - EndPos.y;
                    float forceSide = EndPos.x - StartPos.x;

                    currentCube.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-(forceSide / 50f), forceUp / 50f, 0f), ForceMode.Impulse);
                }
            }
        }
    }
    public void StartSpawnCube()
    {
        StartCoroutine(spawnCube());
    }
    IEnumerator spawnCube()
    {
        yield return new WaitForSeconds(3f);
        isActive = true;
        currentCube = Instantiate(cube2go, HoldPos.position, Quaternion.identity);
        currentCube.transform.position = HoldPos.position;
        currentCube.GetComponent<Rigidbody>().isKinematic = true;
        currentCube.GetComponent<Collider>().isTrigger = true;
    }



}