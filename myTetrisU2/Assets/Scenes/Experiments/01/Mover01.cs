using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover01 : MonoBehaviour
{
    Rigidbody  rb ;
    Fig01      fig;
    GameObject  go;

    private void Awake()
    {
        //korz = GameObject.Find("Korzina").GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
        go = GetComponent<GameObject>();
        fig = GameObject.Find("Figure").GetComponent<Fig01>();

        rb.freezeRotation = true;
    }

    void Start()
    {
        //fig.createElem();
        //transform.Translate(new Vector3(0, 6, 0));
        //rb.MovePosition(new Vector3(0, 6, 0));

        rb.useGravity = false;
        fig.Generator();
    }

    void Update()
    {
        if (is_fall)
        {
            print("cnt = " + cnt);

            var q = Quaternion.Euler(0, 0, -90 * ((cnt++) % 4));
            rb.MoveRotation(q);
            rb.MovePosition(new Vector3(0, 6, 0));

            is_fall = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) rb.useGravity = true;
    }

    void FixedUpdate()
    {
        //MonoBehaviour.print(rb.transform.position);
    }

    int  cnt     =    0;
    bool is_fall = true;

    void OnCollisionEnter(Collision collision)
    {
        //if (!is_fall) return;

        is_fall       = true ;
        rb.useGravity = false;

        //rb.isKinematic = true;
        //go.SetActive(false);

        //go.SetActive(true);

        float rnd = Random.Range(0, 3);

        //rb.velocity        = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        //yield return new WaitForFixedUpdate();

        //fig.Generator();
        //rb.MovePosition(new Vector3(0, 6, 0));

        //Reset(rb, new Vector3(0, 7, 0), Quaternion.Euler(0, 0, 90 * rnd));
        //rb.AddTorque(new Vector3(0, 0, 90), ForceMode.Impulse);

        //rb.angularVelocity = new Vector3(0.01f, 0.01f, 0.01f);
        //rb.angularDrag = 10;

        //rb.velocity        = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;


        //rb.position = new Vector3(0, 7, 0);


        //var q = Quaternion.Euler(0, 0, 90 * ((cnt++) % 4));
        //rb.MoveRotation(q);

        //print("cnt = " + cnt);


        // Transport it, the fkin S*** flips in mid air
        //rb.transform.position = new Vector3(0, 7, 0);
        //rb.transform.rotation = Quaternion.Euler(0, 0, 90 * rnd);
        //yield return new WaitForFixedUpdate();

        //rb.isKinematic = false;

        //rb.MovePosition(new Vector3(0, 6, 0));
        //rb.position = new Vector3(0, 6, 0);
    }

    IEnumerator Reset(Rigidbody rB, Vector3 targetPos, Quaternion targetRot)
    {
        // Stop the car
        rB.velocity = Vector3.zero;
        rB.angularVelocity = Vector3.zero;
        yield return new WaitForFixedUpdate();

        // Transport it, the fkin S*** flips in mid air
        rB.transform.position = targetPos;
        rB.transform.rotation = targetRot;
        yield return new WaitForFixedUpdate();

        // Stop the car again, this results in only a very very slight inertia, not enough to flip it
        rB.velocity = Vector3.zero;
        rB.angularVelocity = Vector3.zero;
        yield return new WaitForFixedUpdate();
    }
}
