using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour {

    public GameObject canvas;
    public TextMeshProUGUI text;

    public Sprite portalActive;

    private SpriteRenderer spriteRenderer;

    private bool isActive = false; 

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateText(int lights, int lightsToNeed){
        text.text = lights + "/" + lightsToNeed;
        if(lights >= lightsToNeed){
            ActivePortal();
        }
    }

    private void ActivePortal(){
        canvas.SetActive(false);
        spriteRenderer.sprite = portalActive;
        isActive = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" ){
            if(isActive)
                GameManager.Instance.NextLevel();
            else
            {
                GameManager.Instance.GameOver(withAnimation:false);
            }
        }
    }
}