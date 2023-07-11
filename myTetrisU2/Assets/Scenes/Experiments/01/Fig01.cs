using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fig01 : MonoBehaviour
{

    public  GameObject prefab;
    private GenFigure01   gen;

    void Awake()
    {
        gen = new GenFigure01(this);
    }

    void Start()
    {
        //test_createElem();
        Generator();
    }


    void Update()
    {
        
    }

    public void test_createElem() /// not use
    {
        GameObject
        ins = MonoBehaviour.Instantiate(prefab);
        //ins.transform.position = new Vector3(0, 0, 0);
        ins.transform.parent   = transform;
    }

    public void Generator()
    {
        gen.done();
    }

    
}
