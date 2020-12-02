using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midlight : MonoBehaviour
{
    ParticleSystem midLight;
    float size = 2000f;

    // Use this for initialization
    void Start()
    {
        midLight = GetComponent<ParticleSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        size = size * 0.99f;
        var main = midLight.main;
        main.startSize = size;
    }

}
