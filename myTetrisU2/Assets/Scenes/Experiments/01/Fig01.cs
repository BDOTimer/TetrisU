using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fig01 : MonoBehaviour
{

    public GameObject prefab;

    void Start()
    {
        createElem();
        
    }


    void Update()
    {
        
    }

    public void createElem()
    {
        GameObject
        ins = MonoBehaviour.Instantiate(prefab);
        //ins.transform.position = new Vector3(0, 0, 0);
        ins.transform.parent   = transform;
    }
}
