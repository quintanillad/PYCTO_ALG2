using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour
{
    private Transform theTransform;
    public Vector3 Hrange = Vector3.zero;
    public Vector3 Vrange = Vector3.zero;

void LateUpdate(){
    theTransform.position= new Vector4(
    Mathf.Clamp(transform.position.x, Vrange.x, Vrange.y),
    Mathf.Clamp(transform.position.y, Hrange.x, Hrange.y)
    );
}

 void Start(){
    theTransform= GetComponent <Transform> ();
 }   
}
