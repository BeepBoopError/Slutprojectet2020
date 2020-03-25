using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBase : MonoBehaviour
{
    public Sprite idle;
    public Sprite hover;
    public Sprite selected;
    bool isHover;
    public bool isSelect;
    Queue<Action> actions;
    SpriteRenderer spriteRender;
    public GameObject selector;

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
    }
}
