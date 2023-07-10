using Game;
using Palmmedia.ReportGenerator.Core;
using spaceFigure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Figure : MonoBehaviour
{
    Rigidbody             rb;
    public ControlFigure  CF;
    public GameObject prefab;
    public GameObject   korz;

    private void Awake()
    {
        //korz = GameObject.Find("Korzina").GetComponent<GameObject>();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        CF    = new ControlFigure      (this, transform.position);
        rb.freezeRotation = true;

        //rb.useGravity = false;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if( collision.collider.CompareTag("plane") || 
            collision.collider.name[0] == 't')
        {
            CF.eStopFall();
        }
        if (collision.collider.CompareTag("sides"))
        {
            CF.switch_LR();
        }

        //print(collision.collider.name);
    }
}

///----------------------------------------------------------------------------|
/// spaceFigure
///----------------------------------------------------------------------------:
namespace spaceFigure
{
    public class ControlFigure
    {   public   ControlFigure(Figure f, Vector3 pos)
        {
            fig       = f;
            mov = GameObject.Find("Mover").GetComponent<Mover>();

            rb        = f.GetComponent<Rigidbody>();
            config    = ConfigManager.GetConfig();
            generator = new GenFigure(f);

            startpos  = new Vector3(0.5f, pos.y + config.KOR_Y, 0);

            //MonoBehaviour.print("p.y = " + pos.y);

            fig.transform.GetPositionAndRotation(out foriginalpos, 
                                                 out foriginalrot);

            mov.transform.GetPositionAndRotation(out moriginalpos,
                                                 out moriginalrot);
        }

        Figure          fig;
        Mover           mov;
        ConfigBase   config;
        Rigidbody        rb;
        GenFigure generator;

        public bool  isRight = false;
        public bool  isLeft  = false;
        public bool  isFall  = false;
        public bool  isKeys  =  true;
        public float step    =     0;

        Vector3 velocity = new Vector3(1.0f, 0, 0);
        Vector3 startpos ;

        public void onRight()
        {
            if (!isKeys) return;

            isRight = true;
            if (isLeft)
            {
                step   = config.GRIDSIZE - step;
                isLeft = false;
            }
            else step  = 0;
        }

        public void onLeft()
        {
            if (!isKeys) return;

            isLeft = true;

            if (isRight)
            {
                step    = config.GRIDSIZE - step;
                isRight = false;
            }
            else step   = 0;
        }

        public void Moved()
        {
            if (isRight)
            {
                Vector3 d = velocity * Time.fixedDeltaTime;
                step += d.x;

                if (config.GRIDSIZE < step)
                {
                    float dd = d.x - (step - config.GRIDSIZE);

                    //rb.MovePosition(rb.position + new Vector3(dd, 0, 0));
                    mov.transform.Translate(new Vector3(dd, 0, 0));

                    isRight = false;
                }
                else //rb.MovePosition(rb.position + d);
                    mov.transform.Translate(d);
            }
            else
            if (isLeft)
            {
                Vector3 d = velocity * Time.fixedDeltaTime;
                step += d.x;

                if (config.GRIDSIZE < step)
                {
                    float dd = d.x - (step - config.GRIDSIZE);

                    //rb.MovePosition(rb.position - new Vector3(dd, 0, 0));
                    mov.transform.Translate(-new Vector3(dd, 0, 0));

                    isLeft = false;
                }
                else //rb.MovePosition(rb.position - d);
                    mov.transform.Translate(-d);
            }
        }

        public void switch_LR()
        {   if (isLeft)
            {
                step    = config.GRIDSIZE - step;
                isRight = true;
                isLeft  = false;
            }
            else
            if (isRight)
            {
                step    = config.GRIDSIZE - step;
                isRight = false;
                isLeft  = true;
            }
        }

        public void eStopFall()
        {   isFall = false;
            isKeys = false;
        }

        public bool isStartFall()
        {   return !(isRight || isLeft || isFall);
        }


        Vector3    foriginalpos;
        Quaternion foriginalrot;
        Vector3    moriginalpos;
        Quaternion moriginalrot;

        public void StartFall()
        {   
            isFall = true;
            isKeys = true;
            step   =    0;

            /*
            ////////////////////////////////////////////////////////////////////
            //GameObject a = fig.GetComponentInChildren<GameObject>();

            foreach (Transform g in fig.transform.GetComponentsInChildren
                                                                <Transform>())
            {
                //Debug.Log(">>> " + g.name);
                if (g.name[0] == 't')
                {
                    //Debug.Log(">>> " + g.name + " is null");
                    //g.parent = null;
                }
            }
            //MonoBehaviour.Destroy(gameObject);
            //MonoBehaviour.print(fig.transform.GetComponentsInChildren
            //                                            <Transform>().Length);
            ////////////////////////////////////////////////////////////////////
            */

            generator.done(fig);

            //fig.transform.SetPositionAndRotation(foriginalpos, foriginalrot);
            //mov.transform.SetPositionAndRotation(moriginalpos, moriginalrot);

            //fig.transform.position = Vector3.zero;
            //mov.transform.position = Vector3.zero;

            //mov.transform.Translate(mov.transform.position);

            MonoBehaviour.print("---------------------------------------");

            MonoBehaviour.print("mov.transform.position.x = " + mov.transform.position.x);
            MonoBehaviour.print("mov.transform.position.y = " + mov.transform.position.y);
            MonoBehaviour.print("fig.transform.position.x = " + fig.transform.position.x);
            MonoBehaviour.print("fig.transform.position.y = " + fig.transform.position.y);

            
            //rb.MovePosition         (startpos);

            //mov.transform.position      = Vector3.zero;
            //mov.transform.localPosition = Vector3.zero;

            //mov.rb.MovePosition(Vector3.zero);

            //mov.transform.rotation = Quaternion.Euler(Vector3.zero);
            mov.transform.Translate (startpos);

            

            MonoBehaviour.print("mov.transform.position.x = " + mov.transform.position.x);
            MonoBehaviour.print("mov.transform.position.y = " + mov.transform.position.y);
            MonoBehaviour.print("fig.transform.position.x = " + fig.transform.position.x);
            MonoBehaviour.print("fig.transform.position.y = " + fig.transform.position.y);

            //
            //mov.transform.position = startpos;

            //MonoBehaviour.print("rb.position.x = " + rb.position.x);
            //MonoBehaviour.print("rb.position.y = " + rb.position.y);
        }
    }
}