using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover01 : MonoBehaviour
{
    Rigidbody  rb ;
    Fig01 fig;

    private void Awake()
    {
        //korz = GameObject.Find("Korzina").GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
        fig = GameObject.Find("Figure").GetComponent<Fig01>();
    }

    void Start()
    {
        //fig.createElem();
        //transform.Translate(new Vector3(0, 6, 0));
        rb.MovePosition(new Vector3(0, 6, 0));
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        MonoBehaviour.print(rb.transform.position);
    }
}
