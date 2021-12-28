using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManger gameManger;
    public GameObject[] healthBar;
   

    public CameraShake cameraShake;
   

    float cameraShakeDuration = 0.5f; 

    float cameraShakeMagnitude = 1f;
    int damage;
    public AudioSource cameraShakeSound;
   
    void Start()
    {
        damage = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if(damage<5){
                healthBar[damage++].SetActive(false);
            }

            //Debug.Log(cameraShakeDuration + " " + cameraShakeMagnitude);
            StartCoroutine(cameraShake.Shake(cameraShakeDuration,cameraShakeMagnitude));
            cameraShakeSound.Play();
            Destroy(other.gameObject);
            gameManger.enemyAlive--;
            
            if(damage>=5){
                gameManger.ShowGameOverPanel();
            }
            //this.transform.position.x = Mathf.Sin(Time.time * speed) * amount;

        }
    }


    
}
