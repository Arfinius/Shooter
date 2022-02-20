using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmo : MonoBehaviour
{

    private float slowMo = 0.2f;
    private float normTime = 1f;
    private bool doSlowMo = true;

    public AudioSource Soundtrack;


    public Rigidbody rb;


    void Update()
    {

        if (rb.velocity.magnitude != 0)
        {
            if (!doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Soundtrack.pitch = 1f;
                doSlowMo = true;
            }
        }
        else
        {
            if (doSlowMo)
            {
                Debug.Log("SlowMo");
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Soundtrack.pitch = 0.7f;
                doSlowMo = false;
            }
        }
        
    }
}
