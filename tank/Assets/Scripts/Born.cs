using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerPrefab;
    public GameObject[] enemyPrefabList; //敌人预制体列表
    public bool createPlayer;

    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(PlayerPrefab, transform.position, Quaternion.identity);//无旋转
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);//无旋转
        }

    }
}
