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

    [Header("PlayerHpBar")]
    public Image hpBar;

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
    public float shieldSpeed = 0.5f;

    [Header("ShieldRange")]
    public float shieldRange = 0.13f;

    [Header("DoubleDamage")]
    public float doubleDamage = 0.15f;

    [Header("RevivePlayer")]
    public float revivePlayer = 0;

    public Animator shieldAnimator;
    private AnimatorStateInfo info;
    public Gradient gradient;
    public Text skillNumText;

    void Awake()
    {
        Instance = this;
        skillNum = PlayerPrefs.GetInt("Score", 0);

        hpBar.fillAmount = hp / 100;

    }

    void Update()
    {
        skillNumText.text = "Points: " + skillNum.ToString();
        // hpBar.fillAmount = hp / 100;
        hpBar.fillAmount = hp / 100;
        hpBar.color = gradient.Evaluate(hpBar.fillAmount);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameObject.Find("SkillTreePanel").transform.localScale==Vector3.zero)
            {
                Time.timeScale = 0;
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.one;
            }
            else if (GameObject.Find("SkillTreePanel").transform.localScale == Vector3.one)
            {
                Time.timeScale = 1;
                GameObject.Find("SkillTreePanel").transform.localScale = Vector3.zero;
            }
        }


    }

    public void display()
    {
        GameObject.Find("SkillTreePanel").transform.localScale = Vector3.one;
    }

    public void hide()
    {
        GameObject.Find("SkillTreePanel").transform.localScale = Vector3.zero;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //+1 skill points if player collect the fruit
        if (collision.gameObject.tag=="Skill_Fruit")
        {
            PlayerInfo.Instance.skillNum += 1;
        }
    }
    public void KillPlayer(){
        if (hp <= 0 ){
            transform.GetComponent<PlayerControl>().Kill();
        }
    }

}
