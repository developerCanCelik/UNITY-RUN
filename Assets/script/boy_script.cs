using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boy_script : MonoBehaviour
{
    public Animator animator;
    public GameObject dust_effect;
    public GameObject golden_effect;
    public GameObject finish;
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI col_golden;

    public Transform way1;
    public Transform way2;

    public Rigidbody rgbody;
    bool right;

    int scoreInt= 0;
    int colGolden= 0;
    public bool takeMagnet = false;

    //Ses dosyalarını sonra ekle
    public AudioSource playerAudio;
    public AudioClip goldAudio;
    public AudioSource dustAudio;
    private void Start() {
        right = false;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name== "EndPoint")
            way2.position = new Vector3(way1.position.x+ 19.8f, way1.position.y, way1.position.z );
        if(other.gameObject.name== "EndPoint2")
            way1.position = new Vector3(way2.position.x+ 19.8f, way2.position.y, way2.position.z);
        if(other.gameObject.tag =="obstacle"){
            finish.SetActive(true);
            dust_effect.SetActive(false);
            //Time 0 yaparak oyunu durduruyoruz.
            Time.timeScale=.0f;
        }
        if(other.gameObject.tag == "golden"){
            playerAudio.PlayOneShot(goldAudio);

            GameObject newGoldenEffect = Instantiate(golden_effect, other.gameObject.transform.position, Quaternion.identity);
            Destroy(newGoldenEffect, 0.5f);
            Destroy(other.gameObject);
            colGolden++;
            scoreInt += 5;

            score.text = scoreInt.ToString("000000");
            col_golden.text = colGolden.ToString();

        }
         if(other.gameObject.tag == "magnet"){
            GameObject[] allMagnet = GameObject.FindGameObjectsWithTag("magnet");

            foreach (GameObject magnet in allMagnet)
            {
                Destroy(magnet);
            }
            takeMagnet = true;
            Invoke("reset_magnet",10.0f);
        }
    }
    void reset_magnet(){
        takeMagnet = false;
    }

    private void OnCollisionStay(Collision other) {
        dust_effect.SetActive(true);
        dustAudio.enabled = true;
    }
    private void OnCollisionExit(Collision other) {
        dust_effect.SetActive(false);
        dustAudio.enabled = false;
    }
    private void LateUpdate() {
       if(Input.GetKeyDown(KeyCode.W)){
            animator.SetBool("jump", true);
            rgbody.velocity = Vector3.up * 300.0f * Time.deltaTime;
            Invoke("move_reset", 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            direction(true);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            direction(false);
        }
        transform.Translate(-5 * Time.deltaTime,0,0);
    }
    void direction(bool value){
        if(right != true && value == true){
            transform.position =  new Vector3(transform.position.x,transform.position.y, 236.50f);
            right = true;
        }
        else if(right != false && value == false){
            transform.position = new Vector3(transform.position.x, transform.position.y, 239.17f);
            right = false;
        }
    }
    void move_reset(){
        animator.SetBool("jump",false);
    }

}
