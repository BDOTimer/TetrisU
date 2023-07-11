using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spaceFigure;
using UnityEditor.Build.Reporting;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private Figure    fg;
    public  Rigidbody rb;

    void Start()
    {
        fg = GameObject.Find("Figure").GetComponent<Figure>();
        rb = fg.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !fg.CF.isRight)
        {
            fg.CF.onRight();
        }
        else
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !fg.CF.isLeft)
        {
            fg.CF.onLeft();
        }
    }


    void FixedUpdate ()
    {   fg.CF.Moved();

        if (fg.CF.isStartFall())
        {
            fg.CF.StartFall();
        }

        MonoBehaviour.print(transform.position);
    }
}
