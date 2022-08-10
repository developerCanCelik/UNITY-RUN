using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golden_script : MonoBehaviour
{
    boy_script boy;
    Transform cube;

    float distance;
    void Start()
    {
        boy = GameObject.Find("boy").GetComponent<boy_script>();
        cube = GameObject.Find("boy/magnetTarget").transform;
    }

    void Update()
    {
        if(boy.takeMagnet == true){
            distance = Vector3.Distance(transform.position, cube.position);
            if(distance <= 10){
                transform.position = Vector3.MoveTowards(transform.position, cube.position, Time.deltaTime*10.0f);
            }
        }
    }
}
