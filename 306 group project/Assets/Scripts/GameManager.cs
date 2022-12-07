using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject player;
    private GameObject boss;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){   
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Score", PlayerInfo.Instance.skillNum);
        PlayerInfo.Instance.LevelCounter++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.SetActive(true);
    }
    public void gameOver()
    {
        StartCoroutine(WaitLoad());
    }

    IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(GameObject.Find("PlayerInfo"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
