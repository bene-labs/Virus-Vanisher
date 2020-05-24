using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public bool valid;
    private float next_move = 0f;
    public bool isClone;
    private Vector3 start_pos = new Vector3(100, 100, 0);
    private Vector3 move_vec = new Vector3(0.00f, 0.00f, 0);
    private float speed = 0.001f;
    public GameObject player;
    //public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        valid = false;
        next_move = Time.time;
        start_pos = new Vector3(100, 100, -2);
        int x = UnityEngine.Random.Range(-10, 10);
        int y = UnityEngine.Random.Range(-10, 10);
        if (x >= 0 && y >= 0)  
            transform.position = new Vector3(x + 10, y + 10 , -2);
        else if (x >= 0)
            transform.position = new Vector3(x + 10, y - 10, -2);
        else
            if (x >= 0)
                transform.position = new Vector3(x + 10, y - 10, -2);
            else
                transform.position = new Vector3(x - 10, y - 10, -2);
        start_pos = transform.position;
        move_vec = get_moving_vec();
        //rb = GetComponent<Rigidbody>();
    }
    /*void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }*/
    // Update is called once per frame
    void Update()
    {
        if (isClone == true) {
                next_move = Time.time + speed;
                transform.position += move_vec * 10;
        }
        if (valid == false) {
            if ((-10 < transform.position.x  && transform.position.x < 10) && (-10 < transform.position.y && transform.position.y  < 10)) {
                valid = true;
            }
        }
        if (valid == true) {
            if (!((-10 < transform.position.x  && transform.position.x < 10) && (-10 < transform.position.y && transform.position.y  < 10))) {
                valid = false;
                Destroy(gameObject);
            }
        }
    }

    public Vector3 get_moving_vec()
    {
        float rad = player.GetComponent<defender_controller>().Rad;
        int rnd = RandomNumber(1, 89);
        var ret = new Vector3(Mathf.Sin(rnd) * rad - transform.position.x, Mathf.Cos(rnd) * rad - transform.position.y, 0) * 0.0001f;
        return (ret);
    }
    public int RandomNumber(int min, int max)  
    {  
        System.Random rand = new System.Random();  
        int ret = rand.Next(min, max);
        return(ret);  
    }
    /*private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit detected!");
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
            FindObjectOfType<safescoretext>().score += 5;
        valid = false;
        Destroy(gameObject);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(");
    }*/
}
