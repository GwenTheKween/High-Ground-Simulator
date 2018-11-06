using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playkill : MonoBehaviour {

    private void OnTriggerEnter(Collider col) {
        var ps = col.gameObject.GetComponent<PlayerStatus>();
        if(ps) { 
            //ps.Death();
        }
    }
}
