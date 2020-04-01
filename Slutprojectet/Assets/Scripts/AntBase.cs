﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBase : MonoBehaviour
{
    public Sprite idle;
    public Sprite hover;
    public Sprite selected;
    public bool isHover;
    public bool isSelect;
    protected SpriteRenderer spriteRender;
    public GameObject selector;

    private Vector3 destination;
    public Vector3 Destination
    {
        get { return destination; }
        set { destination = value; }
    }
    private Vector3[] wayPoints;

    protected int maxHealth;
    protected float speed = 1;
    protected int maxStamina;

    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private int stamina;
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public bool isAlive;

    protected Queue<Action> actions;



    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selector.transform.position.x - (selector.transform.localScale.x/2f) < GetComponent<Transform>().transform.position.x && selector.transform.position.x + (selector.transform.localScale.x/2f) > GetComponent<Transform>().transform.position.x && selector.transform.position.y - (selector.transform.localScale.y/2f) < GetComponent<Transform>().transform.position.y && selector.transform.position.y + (selector.transform.localScale.y/2f) > GetComponent<Transform>().transform.position.y)
        {

            isHover = true;
            
        }
        else
        {
            isHover = false;
        }


        if (isHover)
        {
            spriteRender.sprite = hover;
        }
        else if (isSelect)
        {
            spriteRender.sprite = selected;
        }
        else
        {
            spriteRender.sprite = idle;
        }

        if (transform.position != Destination)
        {
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - Destination.x, 2) + Mathf.Pow(transform.position.y - Destination.y, 2)) > speed * Time.deltaTime)
            {
                transform.position = Destination;
            }
            else
            {
                transform.position = new Vector3 ( speed * Time.deltaTime * Mathf.Cos((Destination.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow(transform.position.x - Destination.x, 2) + Mathf.Pow(transform.position.y - Destination.y, 2))), speed * Time.deltaTime * Mathf.Sin((Destination.y - transform.position.y ) / Mathf.Sqrt(Mathf.Pow(transform.position.x - Destination.x, 2) + Mathf.Pow(transform.position.y - Destination.y, 2))), 0) ;

            }
        }
    }
}
