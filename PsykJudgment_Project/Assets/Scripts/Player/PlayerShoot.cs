using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    private float LastShoot;
    private float Horizontal;

    
    public bool flipX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


        if (Input.GetKey(KeyCode.E) && Time.time > LastShoot + 0.55f)
        {
            Shoot();
            LastShoot = Time.time;

        }
        else if (Input.GetKey(KeyCode.R) && Time.time > LastShoot + 0.55f)
        {

            Shoot();
            LastShoot = Time.time;
        }
        
    }

    private void Shoot()
    {
        Vector3 direction;
         if (transform.localScale.x == 1f)
         {
             direction =Vector3.right;
             flipX = false;
             
             GameObject bullet = Instantiate(BulletPrefab1, transform.position + direction * 0.1f, Quaternion.identity);
             bullet.GetComponent<Bullet1>().SetDirection(direction);
         }
         else
         {
             direction = Vector3.left;
             flipX = true;
             
             GameObject bullet = Instantiate(BulletPrefab2, transform.position + direction * 0.6f, Quaternion.identity);
             bullet.GetComponent<Bullet1>().SetDirection(direction);

         }
         
        
    }
}
