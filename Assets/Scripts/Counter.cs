using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour{
    public int numOfPickups;
    static public bool goalMet = false;

    void Update(){
        numOfPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
        if (numOfPickups ==0){
            Counter.goalMet = true;
        }
    }
}
