using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    private bool up, down, left, right;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float angle;
    [SerializeField] float angleChange;
    [SerializeField] float speedChange;
    [SerializeField] float decChange;
    float maxSpeed;
    [SerializeField] Terrain mud;
    [SerializeField] Terrain grass;
    [SerializeField] Terrain road;
    float decsend;

    bool grassCheck;
    bool mudCheck;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         maxSpeed = 0;
        decsend = 0;
        grassCheck = false;
        mudCheck = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
            up = true;
        if (Input.GetKeyDown(KeyCode.A))
            left = true;
        if (Input.GetKeyDown(KeyCode.S))
            down = true;
        if (Input.GetKeyDown(KeyCode.D))
            right = true;
        if (Input.GetKeyUp(KeyCode.W))
            up = false;
        if (Input.GetKeyUp(KeyCode.A))
            left = false;
        if (Input.GetKeyUp(KeyCode.S))
            down = false;
        if (Input.GetKeyUp(KeyCode.D))
            right = false;
    }
    public void FixedUpdate()
    {

        if (left)
        {
            angle += angleChange * Time.deltaTime;
        }
        if (right)
        {
            angle -= angleChange * Time.deltaTime;
        }
       

            if (up && speed <= maxSpeed)
            {
                    speed += (speedChange) * Time.deltaTime;
            }
          
            if (down && speed>=0 &&  speed <= maxSpeed)
            {
                    speed -= (decChange) * Time.deltaTime;
           
        }
        if(maxSpeed != road.GetMaxSpeed() && speed >= 0) 
        {
            speed -= decsend * Time.deltaTime;
        }

        if (angle < 0)
                angle += 360;
            angle = angle % 360;

            rb.rotation = angle;

            rb.velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime, Mathf.Sin(Mathf.Deg2Rad * angle) * speed * Time.deltaTime);

        if(!mudCheck && grassCheck)
        {
            decsend = grass.GetDecelerate();
            maxSpeed = grass.GetMaxSpeed();
            Debug.Log("Grass");
        }
        }
        
        public void OnCollisionEnter2D(Collision2D collision)
        {
      
       
      
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Mud"))
        {
            decsend = mud.GetDecelerate();
            mudCheck = true;
            maxSpeed = mud.GetMaxSpeed();
            Debug.Log("Mud");
            

        }
        else if (collision.gameObject.name.Equals("Grass"))
        {
            decsend = grass.GetDecelerate();
            maxSpeed = grass.GetMaxSpeed();
            Debug.Log("Grass");
        }
        else if (collision.gameObject.name.Equals("Road"))
        {
            decsend = road.GetDecelerate();
            maxSpeed = road.GetMaxSpeed();
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Mud"))
        {
            grassCheck = true;
            mudCheck = false;
        }
        else if (collision.gameObject.name.Equals("Road"))
        {
            grassCheck = true;
        }
        else if (collision.gameObject.name.Equals("Grass"))
        {
            grassCheck = false;
        }

    }


}

