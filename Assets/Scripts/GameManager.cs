using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private int lives;
    private int scores;

    private static GameManager instance;

    private void Start(){
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame(){
        lives = 3;
        scores = 0;

        LoadLevel(1);
    }

    private void LoadLevel(int index){
        level = index;
        
        Camera camera = Camera.main;

        if (camera != null){
            camera.cullingMask = 0;
        }
        
        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene(){
        SceneManager.LoadScene(level);
    }
    public void LevelComplete(){
        scores += 1000;

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings){
            LoadLevel(nextLevel);
        }else{
            LoadLevel(1);
        }
    }

    public void LevelFailed(){
        lives--;
        if(lives <= 0){
            NewGame();
        }else{
            LoadLevel(level);
        }
    }
}
