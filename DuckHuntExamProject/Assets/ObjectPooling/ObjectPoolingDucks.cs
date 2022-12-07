using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolingDucks : MonoBehaviour
{
    public static ObjectPoolingDucks instance;

    public List<Pool> DuckPool;

    Queue<GameObject> DuckObjPool;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in DuckPool)
        {
            DuckObjPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                    GameObject duckObj = Instantiate(pool.prefab);
                    duckObj.SetActive(false);
                    DuckObjPool.Enqueue(duckObj);
            }
            poolDictionary.Add(pool.tag, DuckObjPool);
        }
    }

    public GameObject SpawnFromDuckPool(string tag, Vector3 position, Quaternion roation)
    {
        GameObject ObjectSpawn = poolDictionary[tag].Dequeue();

        ObjectSpawn.SetActive(true);
        ObjectSpawn.transform.position = position;
        ObjectSpawn.transform.rotation = roation;

        poolDictionary[tag].Enqueue(ObjectSpawn);

        return ObjectSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
