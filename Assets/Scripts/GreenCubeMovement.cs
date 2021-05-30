using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeMovement : MonoBehaviour
{
    private GameObject MainObject;
    private float MoveSpeed = 5f;
    private Vector3 MoveVector;
    private bool CanMove = false;
    // Start is called before the first frame update
    void Start()
    {
        MainObject = GameObject.FindGameObjectWithTag("MainObject");
        MoveVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToCenter();
    }

    void MoveToCenter()
    {
        if (CanMove)
        {
            MoveVector = Vector3.MoveTowards(transform.position, MainObject.transform.position, 0.5f * Time.deltaTime * MoveSpeed);
            MoveVector.y = 1.3f;
            transform.position = MoveVector;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "StackedCube")
        {
            CanMove = true;
            StartCoroutine(MoveRoutine());
        }

    }
    IEnumerator MoveRoutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GetComponent<GreenCubeMovement>());
    }


}
