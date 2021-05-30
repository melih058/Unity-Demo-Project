using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject MainObject;
    private Vector3 DistanceDelta;
    void Start()
    {
        MainObject = GameObject.FindGameObjectWithTag("MainObject");
        DistanceDelta = transform.position - MainObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Slerp(transform.position, MainObject.transform.position + DistanceDelta, 2f*Time.deltaTime);
    }
}
