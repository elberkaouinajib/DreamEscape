using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    private GameObject player;

    public string[] scenes;
    public int sceneIndex = 0;

    public float deadDuration = 2;

    public PlayerControl playerControl;

    private int coins;
    private TextMeshProUGUI coinsText;

    Image winScreen;
    
    void Start(){
        Init();
    }

    void Update(){}

    void Init(){
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        coinsText = GameObject.Find("LightNumber").GetComponent<TextMeshProUGUI>();
        winScreen = GameObject.Find("WinScreen").GetComponent<Image>();
        Debug.Log(winScreen);
        SetCoins();
    }

    void SetCoins(){
        coinsText.text = "" + coins;
    }

    public void AddCoins(){
        coins +=1;
        SetCoins();
    }

    public void RemoveCoins(){
        coins -=1;
        SetCoins();
    }

    void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void GameOver(bool withAnimation=true){
        StartCoroutine(_GameOver(withAnimation));
        
    }

    IEnumerator _GameOver(bool withAnimation)
    {
        if(withAnimation){
            /*if(!player)
                player = GameObject.FindWithTag("Player");
            if(!playerControl){
                playerControl = player.GetComponent<PlayerControl>();
            }*/

            playerControl.Die();
        }
        yield return new WaitForSeconds(withAnimation?deadDuration:0);
        AsyncOperation loaded = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while(!loaded.isDone){
            yield return null;
        }
        // Wait a frame so every Awake and Start method is called
        yield return new WaitForEndOfFrame();
        Init();
    }

    public void NextLevel(){
       
        if(sceneIndex + 1 < scenes.Length){
            sceneIndex ++;
            SceneManager.LoadScene(sceneName: scenes[sceneIndex]);
        }else if(winScreen){
            Debug.Log("WIN");
            winScreen.enabled = true;
            Time.timeScale = 0f;
        }

    }
}