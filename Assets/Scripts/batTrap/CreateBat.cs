using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBat : MonoBehaviour
{

    public GameObject m1;

    public Transform spawner;
    private bool playerIsInTrap = false;
    public float waitTime=1.0f;
    float timer=0;


     [System.Serializable] public enum BatType
     {
          Normal,Crazy
     }

	[SerializeField]
	float moveSpeed = 6f;

	[SerializeField]
	float frequency = 10f;

	[SerializeField]
	float magnitude = 1f;

     public BatType batType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsInTrap)
        {
            timer+=Time.deltaTime;
            if(timer>=waitTime){
                Bat bat= Instantiate(m1,spawner.position,Quaternion.identity).GetComponent<Bat>();
                bat.frequency=frequency;
                bat.magnitude=magnitude;
                bat.moveSpeed=moveSpeed;
                switch (batType)
                {
                    case BatType.Crazy:bat.batMove="Crazy";break;
                    default:bat.batMove="Normal";break;
                }
                timer=0;
            }
        }
        else if(timer>0)
            timer=0;

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            playerIsInTrap=true;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
          {
            playerIsInTrap=false;
            Debug.Log("out");
          }

        if(other.gameObject.tag=="Bat")
            Destroy(other.gameObject);
    
    }
}
