using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private SpriteRenderer sr;
    // Start is called before the first frame update
    public GameObject explosionPrefab;

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
        //if(explosionPrefab != null)
        explosionPrefab.SetActive(true);
        Instantiate(explosionPrefab, transform.position, transform.rotation);


    }
}
