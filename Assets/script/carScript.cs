using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour
{
    float speed = 5;
    private void Update() {
        transform.Translate(0,0,speed*Time.deltaTime);
    }
}
