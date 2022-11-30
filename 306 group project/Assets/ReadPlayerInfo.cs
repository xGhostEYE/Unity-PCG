using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerInfo : MonoBehaviour
{

    void Start()
    {
        //Read Data
        if (PlayerPrefs.HasKey("ShieldSpeed"))
        {
            PlayerInfo.Instance.shieldSpeed = PlayerPrefs.GetFloat("ShieldSpeed");
        }
        if (PlayerPrefs.HasKey("ShieldRange"))
        {
            PlayerInfo.Instance.shieldRange = PlayerPrefs.GetFloat("ShieldRange");
        }
        
    }


    void Update()
    {
        
    }
}
