using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject player;
    [SerializeField] GameObject background1,background2,
    background3,background4,background5,background6;
    List<GameObject> images;
    public static int level_counter = 0;
    private GameObject boss;

    // Start is called before the first frame update
    void Start(){
        images = new List<GameObject>(){background1,background2,
        background3,background4,background5,background6};
        foreach (GameObject pic in images) {
            pic.SetActive(false);
        }
        images[level_counter].SetActive(true);
        
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


        //PlayerInfo.Instance.display();
        PlayerPrefs.SetInt("Score", PlayerInfo.Instance.skillNum);
        level_counter +=1;
        
        // Debug.Log("sorting order"+images[level_counter]);
        PlayerInfo.Instance.LevelCounter++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        images[level_counter].SetActive(true);
        images[level_counter-1].SetActive(false);
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
