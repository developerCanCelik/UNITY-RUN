using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_clone : MonoBehaviour
{
    public GameObject golden;
    public GameObject police;
    public GameObject taxi;
    public GameObject log;
    public GameObject magnet;
    public GameObject ston;

    public Transform players;

    float deleteTime = 5.0f;


    //float rightX=89.91f;
    float rightZ=237.952f;
    //float leftX=89.91f;
    float leftZ=240.49f;
    void Start()
    {
        InvokeRepeating("objectClone", 0, 0.5f);
    }
    void objectClone(){
        //1035.96
        int randomRange = Random.Range(0,100);
        if(randomRange>0 && randomRange < 75){
            clone(golden, 1035.58f);
        }
        if(randomRange>75 && randomRange < 80){
            clone(log, 1035.0f);
        }
        if(randomRange>80 && randomRange < 85){
            clone(police, 1034.762f);
        }
        if(randomRange>85 && randomRange < 90){
            clone(taxi, 1034.762f);
        }
        if(randomRange>90 && randomRange < 95){
            clone(ston, 1034.629f);
        }
        if(randomRange>95 && randomRange < 100){
            magnet.transform.localScale = new Vector3(2,6,6);
            clone(magnet, 1036.0f);
        }
    }
    void clone(GameObject obje, float Y_koor){
        GameObject newColone = Instantiate(obje);
        int random = Random.Range(0,100);
        if(random<50){
            newColone.transform.position = new Vector3(players.position.x + 20.0f,Y_koor,rightZ);
        }else{
            newColone.transform.position = new Vector3(players.position.x + 20.0f,Y_koor,leftZ);
        }
        Destroy(newColone,deleteTime);
    }

}
