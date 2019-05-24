using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m1Move : MonoBehaviour
{
    public float xStart;
    public float xEnd;
    public float yHeigh;

    public GameObject player;
    public Camera camera;


    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.x>=xStart && player.transform.position.x<=xEnd)
        {
            transform.position=transform.position-(new Vector3(0.1f,0,0));
            if(transform.position.x<camera.transform.position.x-(camera.transform.localScale.y)-5)
                transform.position=new Vector3(camera.transform.position.x+(camera.transform.localScale.y)+5,yHeigh,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject==player)
            GameOverDetect.GameOver();
    }
}
