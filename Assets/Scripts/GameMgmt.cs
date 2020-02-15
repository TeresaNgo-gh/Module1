using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode{
    idle,
    playing,
    levelEnd
}

public class GameMgmt : MonoBehaviour{
    static private GameMgmt S;

    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitShots;
    public Vector3 collectiblesPos;
    public GameObject[] collectibles;

    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject collectible;
    public GameMode mode = GameMode.idle;

    void Start(){
        S = this;
        level = 0;
        levelMax = collectibles.Length;
        StartLevel();
    }

    void StartLevel(){
        if (collectible != null){
            Destroy(collectible);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos){
            Destroy(pTemp);
        }

        collectible = Instantiate<GameObject>(collectibles[level]);
        collectible.transform.position = collectiblesPos;
        shotsTaken = 0;

        Counter.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI(){
        uitLevel.text = "Level: "+(level+1)+" of "+levelMax;
        uitShots.text = "Shots Taken: "+shotsTaken;
    }

    void Update(){
        UpdateGUI();

        if((mode == GameMode.playing) && Counter.goalMet){
            mode = GameMode.levelEnd;
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel(){
        level++;
        if(level == levelMax){
            level=0;
        }
        StartLevel();
    }

    public static void ShotFired(){
        S.shotsTaken++;
    }
}
