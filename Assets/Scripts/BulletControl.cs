using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletprefab;
    public GameObject bulletPoint;
    private GameObject bullet;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void shoot()
    {
        bullet = Instantiate(bulletprefab, bulletPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);

        Destroy(bullet, 2f);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "border")
        {
            //Debug.Log("hit hit hit");
            Destroy(this.gameObject);
        }
       
        
    }
}
