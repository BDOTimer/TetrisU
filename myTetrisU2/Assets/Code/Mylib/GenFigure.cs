using Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class GenFigure //: MonoBehaviour
{
    public GenFigure(Figure f)
    {
        fig = f;
    }

    Figure fig;

    void Start()
    {
        MonoBehaviour.print("Start:GenFigure");
    }

    int count = 0;

    public void done(Figure fig)
    {
        MonoBehaviour.print("n=" + (1 + count/4));

        //del();
        toKorzina();

        var cfg = ConfigManager.GetConfig();

        const int N = 4;

        Vector2[] pos = new Vector2[N]
        {   new Vector2(-1, 0),
            new Vector2( 0, 0),
            new Vector2( 1, 0),
            new Vector2( 0, 1)
        };

        for (int i = 0; i < N; i++)
        {
            float rnd1 = Random.Range(0, 3);
            float rnd2 = Random.Range(0, 3);

            GameObject 
            ins = MonoBehaviour.Instantiate(fig.prefab);
            ins.transform.position = 
                new Vector3(pos[i].x * cfg.GRIDSIZE, 
                            pos[i].y * cfg.GRIDSIZE, 0);

            ins.transform.parent = fig.transform;

            ins.transform.Rotate(90.0f * rnd1, 90.0f * rnd2, 0, Space.Self);
            ins.transform.name = "tcubic:" + ++count;

            gameObjects.Add(ins);
        }

        float rnd = Random.Range(0, 3);
        

        //var t = fig.transform.position;
        //fig.transform.position = Vector3.zero;
        //fig.transform.rotation = Quaternion.Euler(0, 0, 90 * rnd);
        fig.transform.Rotate(0, 0, 90.0f, Space.Self);
        //fig.transform.position = t;
    }


    void del()
    {
        //fig.transform.DetachChildren();
        foreach (var o in gameObjects)
        {
            o.transform.parent = null;
            MonoBehaviour.Destroy (o);
        }
        gameObjects.Clear();
    }

    public void toKorzina()//GameObject Korz)
    {
        Korzina Korz = GameObject.FindWithTag("Korzina").GetComponent<Korzina>();

        //Korzina s = Korzina::inst;

        if (Korz == null) Debug.Log("Korz == null");

        foreach (var o in gameObjects)
        {
            o.transform.parent = Korz.transform;
            Korz.cargo.Add(o);
        }
        gameObjects.Clear();
    }

    List<GameObject> gameObjects = new List<GameObject>();
}
