using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead; //是否死亡
    public bool isDefeat;


    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeText;
    public GameObject isDefeatUI;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance   //单例
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;  //单例初始化
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDefeat == true)
        {
            isDefeatUI.SetActive(true);
            return;
        }
        if (isDead == true)
        {
            Recover(); 
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeText.text = lifeValue.ToString();

    }

    private void Recover()   //复活方法
    {
        if(lifeValue <= 0)
        {
            isDefeat = true;
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }
}
