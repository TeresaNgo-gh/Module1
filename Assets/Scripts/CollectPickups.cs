using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPickups : MonoBehaviour{
    [Header("Set Dynamically")]
    static public bool goalMet = false;
    public int collided;

    public void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Pickup"){
            Destroy(collidedWith);
            collided++;
            if(collided == 7){
                goalMet = true;
            }
        }
    }
}
