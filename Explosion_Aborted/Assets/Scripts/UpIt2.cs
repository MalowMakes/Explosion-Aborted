using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpIt2 : MonoBehaviour
{
    public AmmoDisplay ammodisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        ammodisplay.fillSpeed = 0.15f;
    }
}
