using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 60.0f;
    float maxWalkSpeed = 2.0f;
    float thredshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        { 
            this.rigid2D.AddForce(transform.up * jumpForce);
	    }

        int key = 0;
        //if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;
        if (Input.acceleration.x > this.thredshold) key = 1;
        if (Input.acceleration.x > -this.thredshold) key = 1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ClearScene");
    }

    
}
