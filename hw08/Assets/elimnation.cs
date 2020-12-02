using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class elimnation : MonoBehaviour
{
    ParticleSystem elimnate;
    public float size = 4f;
    void Start()
    {
        elimnate = GetComponent<ParticleSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        size = size * 0.99f;
        var main = elimnate.main;
        main.startSize = size;
    }

}


