using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnityEngine;

public class alexkid : MonoBehaviour
{
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private float spinAngle;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private bullet bulletPrefab;
    [SerializeField] private float health;
    public float speed;
    private float currentBulletDelay;
    [SerializeField] private float bulletDelay = 0.5f;
     
    // Start is called before the first frame update
    void Start()
    {
          transform.position += offsetPosition;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Si el personaje esta vivo lo muevo y lo roto
        if (health > 0)
        {
          SetDirection();

        }
    currentBulletDelay += Time.deltaTime;
       
    }

    private void Shoot()
    {
        currentBulletDelay = 0;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    public void SetDirection() 
    {

        float horizontal= Input.GetAxis("Horizontal");
        float vertical =  Input.GetAxis("Vertical");
        Vector3 rightAxis = horizontal * transform.right;
        Vector3 forwardAxis = vertical * transform.forward;
        Vector3 direction = rightAxis + forwardAxis;
       
        direction.y = 0;

       
        if (Input.GetButton("Fire1") && currentBulletDelay >= bulletDelay )
        {
            Shoot();
           
        }

        if (Input.GetButton("Rotate")) 
        {

            Vector3 rotationx = Vector3.right * speed;
            Vector3 rotationy = Vector3.up * speed;
            Vector3 rotationAxis = rotationy;
            transform.Rotate(rotationAxis, spinAngle, Space.World);

        }
   
        direction = direction.normalized;
        transform.position += direction * (speed * Time.deltaTime);
    }
   

}
