using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    public GameObject player;

    public float deadDuration = 2;

    private PlayerControl playerControl;

    private int coins;
    public TextMeshProUGUI coinsText;

    public GameObject winScreen;

    void Start(){
        
    }

    public void AddCoins(){
        coins +=1;
        coinsText.text = "" + coins;
    }

    void Awake()
    {
        if(Instance == null){
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void GameOver(bool withAnimation=true){
        playerControl = player.GetComponent<PlayerControl>();
        StartCoroutine(_GameOver(withAnimation));
        
    }

    IEnumerator _GameOver(bool withAnimation)
    {
        playerControl.Die();
        yield return new WaitForSeconds(withAnimation?deadDuration:0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(){
        //temporary
        winScreen.SetActive(true);
    }
}