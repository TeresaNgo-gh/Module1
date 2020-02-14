using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start(){
        S = this;
        level = 0;
        levelMax = collectibles.Length;
        StartLevel();
    }

    void StartLevel(){
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos){
            Destroy(pTemp);
        }

        collectible = Instantiate<GameObject>(collectibles[level]);
        collectible.transform.position = collectiblesPos;
        shotsTaken = 0;
    }

    void UpdateGUI(){
        uitLevel.text = "Level: "+(level+1)+" of "+levelMax;
        uitShots.text = "Shots Taken: "+shotsTaken;
    }

    void Update(){
        UpdateGUI();

        if(collided = 7){
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
