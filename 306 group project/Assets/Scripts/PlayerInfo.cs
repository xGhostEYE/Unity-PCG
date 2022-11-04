using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    [Header("Player's Name")]
    public string playerName = "Riley"; 

    [Header("HP")]
    public int hp = 100; 

    [Header("Movement Speed")]
    public float moveSpeed = 3f; 

    [Header("Jump")]
    public float jumpSpeed = 30f; 

    [Header("Double Jump")]
    public float doubleJumpSpeed = 30f;

    [Header("Skill Point")]
    public int skillNum = 0;

    [Header("Shield Damage")]
    public int damage = 10;


    public Text skillNumText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        skillNumText.text = "SkillNum: " + skillNum.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameObject.Find("SkillTreePanel").transform.localScale==Vector3.zero)
            {
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.one;
            }
            else if (GameObject.Find("SkillTreePanel").transform.localScale == Vector3.one)
            {
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.zero;
            }
        }
    }



}
