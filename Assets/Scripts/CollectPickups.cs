﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPickups : MonoBehaviour{
    [Header("Set Dynamically")]
    public int collided;

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Pickup"){
            Destroy(collidedWith);
            collided++;
        }
    }
}
