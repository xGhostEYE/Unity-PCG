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
    public float hp = 100;

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

    [Header("ShieldFrequency")]
    public float shieldSpeed = 0.7f;

    [Header("ShieldRange")]
    public float shieldRange = 0;

    [Header("DoubleDamage")]
    public float doubleDamage = 0.15f;

    [Header("RevivePlayer")]
    public float revivePlayer = 0;



    public Animator shieldAnimator;
    private AnimatorStateInfo info;

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
            if (GameObject.Find("SkillTreePanel").transform.localScale == Vector3.zero)
            {
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.one;
            }
            else if (GameObject.Find("SkillTreePanel").transform.localScale == Vector3.one)
            {
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.zero;
            }
        }

        info = shieldAnimator.GetCurrentAnimatorStateInfo(1);
        if (info.IsName("PlayerShield"))
        {
            shieldAnimator.speed = shieldSpeed;
        }

        else
        {
            shieldAnimator.speed = 1f;
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //+1 skill points if player collect the fruit
        if (collision.gameObject.tag == "Skill_Fruit")
        {
            PlayerInfo.Instance.skillNum += 1;
        }
    }

}
