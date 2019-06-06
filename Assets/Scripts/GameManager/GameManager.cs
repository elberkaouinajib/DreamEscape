using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void GameOver(){
        Application.LoadLevel(Application.loadedLevel);
    }
}