using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SkillTree
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
            case "skill02_JumpHight10":
                PlayerInfo.Instance.jumpSpeed += PlayerInfo.Instance.jumpSpeed * 0.1f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill03_IncreasedHp10":
                PlayerInfo.Instance.hp += (int)PlayerInfo.Instance.hp * 0.1f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;

            case "skill04_ShieldDamage10":
                PlayerInfo.Instance.damage += PlayerInfo.Instance.damage + 10;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;
                break;
            case "skill05_ShieldFeaquency10":
                PlayerInfo.Instance.shieldSpeed -= 0.01f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;

                
                PlayerPrefs.SetFloat("ShieldSpeed", PlayerInfo.Instance.shieldSpeed);
                PlayerPrefs.Save();
                break;
            case "skill06_ShieldRange10":
                PlayerInfo.Instance.shieldRange += PlayerInfo.Instance.shieldRange + 0.1f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().interactable = false;

                GameObject.Find("2DShield").transform.localScale = new Vector3(PlayerInfo.Instance.shieldRange,
                    PlayerInfo.Instance.shieldRange, PlayerInfo.Instance.shieldRange);


                PlayerPrefs.SetFloat("ShieldRange", PlayerInfo.Instance.shieldRange);
                PlayerPrefs.Save();
                break;

            case "skill07_ShieldDoubleDamage":
                PlayerInfo.Instance.doubleDamage = 0.2f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().enabled = false;
                GetComponent<Image>().color = Color.gray;
                break;
            case "skill08_Revive10%":
                PlayerInfo.Instance.revivePlayer = 0.1f;
                PlayerInfo.Instance.skillNum -= this.skillUpNeed;
                GetComponent<Button>().enabled = false;
                GetComponent<Image>().color = Color.gray;
                break;

            //case "skill09_JumpHp30":
            //    PlayerInfo.Instance.jumpSpeed += PlayerInfo.Instance.jumpSpeed *0.3f;
            //    PlayerInfo.Instance.hp += PlayerInfo.Instance.hp + 36;
            //    PlayerInfo.Instance.skillNum -= this.skillUpNeed;
            //    GetComponent<Button>().interactable = false;
            //    break;

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
