using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{

    private SpriteRenderer sr;
    // Start is called before the first frame update
    public GameObject explosionPrefab;
    public AudioClip dieAudio;

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
        //explosionPrefab.SetActive(true);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
        PlayerManager.Instance.isDefeat = true;
        Invoke("ReturnToMain", 3f);
    }
    private void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
