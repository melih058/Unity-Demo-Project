using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float MoveSpeed = 10f;
    private Vector3 MoveVector;
    private bool Jump = false;
    private GameObject TempGreenCube = null;
    private bool CanFall = false;
    public bool IsGameStarted = false;
    private List<GameObject> StackList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        MoveVector = new Vector3(0f, 0f, 0.020f);

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStarted)
        {
            BallMove();
            JumpFunc();
        }
       

    }

    void BallMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        MoveVector.x = inputX * MoveSpeed * Time.deltaTime;
        transform.position += MoveVector;
    }

    void JumpFunc()
    {
        if (Jump)
        {
            Debug.Log("1");
            //Debug.Log(transform.GetChild(0).transform.position.y);
            if (transform.GetChild(0).transform.position.y < 1.3f + 1.5f * transform.GetChild(0).transform.childCount + 1)
            {
                Debug.Log("2");
                transform.GetChild(0).transform.position += new Vector3(0f, 5f, 0f) * Time.deltaTime;
                if (transform.GetChild(0).transform.position.y > 1.3f + 1.5f * transform.GetChild(0).transform.childCount + 1)
                {
                    transform.GetChild(0).transform.position = new Vector3(transform.position.x, 1.3f + 1.5f * transform.GetChild(0).transform.childCount + 1, transform.position.z);
                    Jump = false;
                }

            }

        }
        else
        {
            Debug.Log("4");


            if (transform.GetChild(0).transform.childCount > 0 && transform.GetChild(0).transform.GetChild(transform.GetChild(0).transform.childCount - 1).transform.position.y > 2.79f)
            {
                Debug.Log("5");

                transform.GetChild(0).transform.position -= new Vector3(0f, 5f, 0f) * Time.deltaTime;
                if (transform.GetChild(0).transform.GetChild(transform.GetChild(0).transform.childCount - 1).transform.position.y < 2.9f)
                {
                    Debug.Log("6");
                    transform.GetChild(0).transform.position = new Vector3(transform.position.x, 1.3f + 1.5f * transform.GetChild(0).transform.childCount, transform.position.z);
                    if (TempGreenCube != null)
                    {
                        TempGreenCube.transform.SetParent(transform.GetChild(0).transform);
                        TempGreenCube = null;
                    }


                }
            }
        }




    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GreenCube")
        {
            other.gameObject.tag = "StackedCube";
            other.gameObject.transform.SetParent(transform);
            TempGreenCube = other.gameObject;
            StackList.Add(other.gameObject);
            Jump = true;
        }

        if (!CanFall && other.gameObject.tag == "RedCube")
        {
            CanFall = true;
            StartCoroutine(FallRecoil());
            StackList[StackList.Count - 1].transform.SetParent(null);
            StackList.RemoveAt(StackList.Count - 1);
            transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.GetChild(0).transform.position.y - 1.5f, transform.position.z);
        }

    }

    IEnumerator FallRecoil()
    {
        yield return new WaitForSeconds(1.5f);
        CanFall = false;

    }

}
