using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationParticles : MonoBehaviour
{    
    void Awake()
    {
        GetComponent<ParticleSystem>().Stop();
    }


    public void Play(){
        GetComponent<ParticleSystem>().Play();
    }
}
