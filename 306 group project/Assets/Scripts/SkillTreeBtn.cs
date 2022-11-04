using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ¼¼ÄÜÊ÷Ãæ°å
/// </summary>
public class SkillTreeBtn : MonoBehaviour
{
    [Header("Needed Skill Point")]
    public int skillUpNeed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        CheckSkillNum();
    }

    public void CheckSkillNum()
    {
        // if player has enough points
        if (PlayerInfo.Instance.skillNum >= skillUpNeed)
        {
            GetComponent<Button>().interactable = true;
        }
        //otherwide they can't level
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    //Clicking button
    public void OnSkillBtnClick()
    {
        switch (gameObject.name)
        {
            case "skill01_MoreSpeed10":
                PlayerInfo.Instance.moveSpeed += PlayerInfo.Instance.moveSpeed * 0.1f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill02_MoreSpeed20":
                PlayerInfo.Instance.moveSpeed += PlayerInfo.Instance.moveSpeed * 0.2f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill03_MoreSpeed30":
                PlayerInfo.Instance.moveSpeed += PlayerInfo.Instance.moveSpeed * 0.3f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;

            case "skill04_MorePower10":
                PlayerInfo.Instance.damage += PlayerInfo.Instance.damage + 10;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill05_MorePower20":
                PlayerInfo.Instance.damage += PlayerInfo.Instance.damage + 20;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill06_MorePower30":
                PlayerInfo.Instance.damage += PlayerInfo.Instance.damage + 30;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;

            case "skill07_JumpHp10":
                PlayerInfo.Instance.jumpSpeed += PlayerInfo.Instance.jumpSpeed *0.1f;
                PlayerInfo.Instance.hp += PlayerInfo.Instance.hp + 12;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill08_JumpHp20":
                PlayerInfo.Instance.jumpSpeed += PlayerInfo.Instance.jumpSpeed*0.2f ;
                PlayerInfo.Instance.hp += PlayerInfo.Instance.hp + 24;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill09_JumpHp30":
                PlayerInfo.Instance.jumpSpeed += PlayerInfo.Instance.jumpSpeed *0.3f;
                PlayerInfo.Instance.hp += PlayerInfo.Instance.hp + 36;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;

            default:
                break;
        }
    }


    //hide skill tree
    public void HideSkillTreePanel()
    {
        gameObject.SetActive(false);
    }
}
