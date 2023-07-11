using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Collider))]
/// MeshGenerator
/// UVMapping
public class Figelem : MonoBehaviour
{

    ConfigBase config;

    float size;

    void Start()
    {
        config = ConfigManager.GetConfig();

        size = config.SIZECUBIC / 2 - config.SIZECUBICAURA;

        float a = size * (-1);

        Vector3[] vertices =
        {
            new Vector3(a   , size, a),
            new Vector3(a   , a   , a),
            new Vector3(size, size, a),
            new Vector3(size, a   , a),

            new Vector3(a   , a   , size),
            new Vector3(size, a   , size),
            new Vector3(a   , size, size),
            new Vector3(size, size, size),

            new Vector3(a   , size, a),
            new Vector3(size, size, a),

            new Vector3(a, size, a   ),
            new Vector3(a, size, size),

            new Vector3(size, size, a   ),
            new Vector3(size, size, size),
        };

        int[] triangles =
        {
            0,  2,  1, // front
			1,  2,  3,
            4,  5,  6, // back
			5,  7,  6,
            6,  7,  8, // top
			7,  9,  8,
            1,  3,  4, // bottom
			3,  5,  4,
            1, 11, 10, // left
			1,  4, 11,
            3, 12,  5, // right
			5, 12, 13
        };

        Vector2[] uvs =
        {
            new Vector2(0,     0.66f),
            new Vector2(0.25f, 0.66f),
            new Vector2(0,     0.33f),
            new Vector2(0.25f, 0.33f),

            new Vector2(0.5f , 0.66f),
            new Vector2(0.5f , 0.33f),
            new Vector2(0.75f, 0.66f),
            new Vector2(0.75f, 0.33f),

            new Vector2(1, 0.66f),
            new Vector2(1, 0.33f),

            new Vector2(0.25f, 1),
            new Vector2(0.5f , 1),

            new Vector2(0.25f, 0),
            new Vector2(0.5f , 0),
        };

        Mesh 
        mesh           = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices  = vertices;
        mesh.triangles = triangles;
        mesh.uv        = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();

        //transform.position = new Vector3(0, 14, 0);

        //coll = GetComponent<Collider>();
        //coll.enabled  = true;

        //rb = GetComponent<Rigidbody>();
    }

    //public Collider coll;
    //public Rigidbody  rb;

    void Update()
    {
    }

    void Awake()
    {
        //this.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        //this.transform.Rotate(90, 0.0f, 0.0f, Space.Self);
        //this.name = "Self";
    }
}


