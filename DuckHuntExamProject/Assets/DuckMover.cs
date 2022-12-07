using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class DuckMover : MonoBehaviour
{
    private Vector3 StartPos;
    public GameObject DuckSpawner;
   // public GameObject LeftPos;
   // public Transform RightPos;
    bool FirstMove = true;
    Rigidbody bulletrb;
    // Start is called before the first frame update
    void Start()
    {
        bulletrb = GetComponent<Rigidbody>();
        StartPos = gameObject.transform.position;
        bulletrb.AddForce(transform.right * 3, ForceMode.Impulse);
       // gameObject.transform.Translate(LeftPos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > (StartPos.x + 10))
        {
            bulletrb.AddForce((transform.right * -1) * 3, ForceMode.Impulse);
        }

        if (gameObject.transform.position.x < (StartPos.x - 10))
        {
            bulletrb.AddForce((transform.right) * 3, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody bulletRb = ObjectPoolingDucks.instance.SpawnFromDuckPool("Duck", DuckSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        }
    }
}
