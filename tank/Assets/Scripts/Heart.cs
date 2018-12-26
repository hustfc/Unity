using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private SpriteRenderer sr;
    // Start is called before the first frame update
    public Sprite brokeSprite;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        sr.sprite = brokeSprite;
    }
}
