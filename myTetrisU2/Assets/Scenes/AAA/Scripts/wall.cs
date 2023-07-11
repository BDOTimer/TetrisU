using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    ConfigBase config;

    void Start()
    {
        config = ConfigManager.GetConfig();

        transform.localScale = new Vector3(config.KOR_X ,
                                           config.KOR_Y ,
                                           config.KOR_Z);

        transform.localPosition = new Vector3(0, config.KOR_Y / 2, 2);

        //MonoBehaviour.print("config.KOR_Y = " + config.KOR_Y);

        //MeshRenderer render = GetComponent<MeshRenderer>();

        Renderer renderer = GetComponent<Renderer>();

        if (0 == renderer.materials.Length) print("ERROR");
        else
        {   Material m = renderer.materials[0];
            m.mainTextureScale = new Vector2(config.KOR_X,
                                             config.KOR_Y);
        }

        //print(m.name);
    }

    void Update()
    {   
    }
}
