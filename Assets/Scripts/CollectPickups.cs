using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPickups : MonoBehaviour{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag =="Pickup"){
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 1;
            scoreGT.text = score.ToString();
        }
    }
}
