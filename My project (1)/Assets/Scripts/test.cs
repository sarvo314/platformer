using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Delta Tiems" + Time.deltaTime);
        Debug.Log("Normal time" + Time.deltaTime);

    }
    private void FixedUpdate()
    {
        //Debug.Log("");
    }
}
