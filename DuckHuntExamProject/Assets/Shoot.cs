using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shoot : MonoBehaviour
{
    public GameObject FirePos;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Rigidbody bulletRb = Instantiate(BulletPrefab, FirePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        }
    }

}
