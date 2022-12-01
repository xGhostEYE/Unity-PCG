using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlimeDetection : MonoBehaviour
{
    private GameObject nearestEnemy;
    public GameObject[] enemiesFound;
    [SerializeField] private AudioSource thankyouSound;
    private float oldDistance = 9999;
    private bool check = true;

    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI slimeText;

    [SerializeField] private string[] slimeSentences;
    private int slimeIndex;


    // Start is called before the first frame update
    void Start()
    {
        //enemiesFound = GameObject.FindGameObjectsWithTag("Enemy");
        //foreach (GameObject enemy in enemiesFound)
        //{
        //    float dist = Vector2.Distance(this.gameObject.transform.position, enemy.transform.position);
        //    if (dist < oldDistance)
        //    {
        //        nearestEnemy = enemy;
        //        oldDistance = dist;
        //    }
        //}
        StartCoroutine(slimeDialouge());
    }

    // Update is called once per frame
    void Update()
    {
        // implement a bool to check if enemyDeathHanlder has already been called, if it has, don't call it again
        //if (nearestEnemy == null & check) {
        //    check = false;
        //    enemyDeathHandler();
        //}
    }

    void enemyDeathHandler() {
        // activate speech bubble ccanvas
        StartCoroutine(slimeDialouge());
        // give player randomized health points
        // melt away and say bye
        // destroy object
        Destroy(this.gameObject, 2.0f);
    }

    private IEnumerator slimeDialouge()
    {
        foreach (char letter in slimeSentences[slimeIndex].ToCharArray())
        {
            slimeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

}
