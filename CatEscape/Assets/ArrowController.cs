using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
	    }

        // あたりjudge
        Vector2 arrow_pos = transform.position;
        Vector2 player_pos = this.player.transform.position;
        Vector2 dir = arrow_pos - player_pos;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);	
	    }


    }
}
