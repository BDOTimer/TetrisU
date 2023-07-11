using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Korzina : MonoBehaviour
{
    public static Korzina inst; /// Korzina.inst

    void Awake()
    {   inst = this;      /// print("Awake()");
    }

    public static List<Korzina> all = new List<Korzina>();
    void OnEnable()
    {
        all.Add(this);    /// print("OnEnable()");
    }

    void OnDisable()
    {
        all.Remove(this); /// print("OnDisable()");
    }

    void Start()
    {
        
    }

    void Update()
    {
    }

    public List<GameObject> cargo = new List<GameObject>();
}
