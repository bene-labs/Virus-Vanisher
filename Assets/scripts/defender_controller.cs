using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class defender_controller : MonoBehaviour
{
    public GameObject projectile;
    private float RotateSpeed = 3f;
    public float Rad = 3f;
    public float looking_to;
    private Vector3 _centre;
    private float _angle;
    public int hp = 5;
 
    // Start is called before the first frame update
    private void Start()
    {
        _centre = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * Rad;
        transform.position = _centre + offset;
        Vector3 dir = _centre - transform.position;
        float angel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);    
        looking_to = transform.rotation.z;

        if (Input.GetMouseButtonUp(0))
        {
            shoot();
            Debug.Log("Pressed left click.");
        }

        if (Input.GetMouseButtonUp(1))
        {
            RotateSpeed *= -1;
            Debug.Log("Pressed right click.");
        }

        if (Input.GetMouseButtonUp(2))
        {
            Debug.Log("Pressed middle click.");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void shoot()
    {
        GameObject go = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        go.GetComponent<prjectile>().isClone = true;
        Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "bullet")
        {
            Debug.Log(hp);
            hp--;
            if (hp <= 0)
            {
                Debug.Log("GAME OVER");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
