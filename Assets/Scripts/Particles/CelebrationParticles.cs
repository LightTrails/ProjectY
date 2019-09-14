using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }


    public void Play(){
        GetComponent<ParticleSystem>().Play();
    }
}
