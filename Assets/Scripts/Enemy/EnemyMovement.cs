﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Animator anim;
    public float speed;
    public float dist;
    //public bool isDead;

    Transform player;
    Transform enemy;

    void Start() {

        anim = GetComponent<Animator>();
        enemy = this.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () {

        AI_movement();
    }

    void AI_movement() {

        anim.SetFloat("Move", Mathf.Abs(Input.GetAxis("Horizontal")));

        // move to player after locating it on target.position
        // player is left of enemy, move left

        if ((player.position.x+dist) < enemy.position.x) 
        { 
            enemy.position -= enemy.right * speed * Time.deltaTime;
            enemy.eulerAngles = new Vector2(0, 0);

        }
        // player is right of enemy, move right
        else if ((player.position.x-dist) > enemy.position.x) 
        { 
            enemy.position -= enemy.right * speed * Time.deltaTime;
            enemy.eulerAngles = new Vector2(0, 180);
        }
    }
}

