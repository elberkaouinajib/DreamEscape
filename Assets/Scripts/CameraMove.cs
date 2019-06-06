using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
     public float speed = 1.0f;

    private Camera camera;
    private void Start() {
        camera=GetComponent<Camera>();
    }
    void Update() => camera.transform.position = camera.transform.position + (new Vector3(0.05f, 0, 0));
    private void LateUpdate() {
         Vector3 v3 = transform.position;
         v3.y = Mathf.Lerp (v3.y, player.transform.position.y, speed);
         transform.position = v3;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject==player)
            GameManager.Instance.GameOver();
    }

}
