using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text TextMenu;
    public GameObject MenuOption;
    // Start is called before the first frame update
    void Start()
    {
        TextMenu.text="Hello it works";   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void activeOption(){
        MenuOption.SetActive(!MenuOption.active);
    }
}
