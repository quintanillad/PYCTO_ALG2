using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMeteorito : MonoBehaviour
{
   private Rigidbody2D rb2d;
   [SerializeField] private float runspeed;

   private void Start(){
        rb2d= GetComponent<Rigidbody2D>();
   }
    private void Update(){
        rb2d.velocity= new Vector2(runspeed * transform.right.x, rb2d.velocity.y);
    }
}
