using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    public GameObject player;

    public float deadDuration = 2;

    private PlayerControl playerControl;

    void Start(){
        
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
}