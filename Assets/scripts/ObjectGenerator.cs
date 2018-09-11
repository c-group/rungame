using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{

    [SerializeField]
    public GameObject[] Train;
    

    void Start()
    {
        InvokeRepeating("Generate",0, 16);
        

    }
    void Generate()
    {
     
        Instantiate(Train[Random.Range(0, Train.Length)], new Vector3(322,6,32),Quaternion.identity);

    }

}