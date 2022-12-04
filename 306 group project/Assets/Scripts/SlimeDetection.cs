using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlimeDetection : MonoBehaviour
{
    private GameObject nearestEnemy;
    public GameObject[] enemiesFound;
    private float oldDistance = 9999;
    private bool check = true;
    [SerializeField] private AudioSource rewardSound;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private Animator slimeSpeechAnimator;
    [SerializeField] private TextMeshProUGUI slimeText;

    [SerializeField] private string[] slimeSentences;
    private int slimeIndex;
    private float speechBubbleAnimationDelay = 0.6f;


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

        // the following is for testing only, take it out later
        StartCoroutine(slimeDialouge());
        rewardSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        // implement a bool to check if enemyDeathHanlder has already been called, if it has, don't call it again
        //if (nearestEnemy == null & check) {
        //    check = false;
        //    enemyDeathHandler();
        //}

        

        // if user presses "enter", progress through dialogue, you can only press enter after enemyHandler has been called
        //if (Input.GetKeyDown(KeyCode.Return) & check == false) {
        //    if (slimeIndex < slimeSentences.Length - 1) {
        //        slimeIndex++;
        //        slimeText.text = string.Empty;
        //        StartCoroutine(slimeDialouge);
        //    }
        //   else {
        //        // melt away and say bye
        //        // destroy object
        //        slimeSpeechAnimator.SetTrigger("Close");
        //        Destroy(this.gameObject, 3.0f);
        //    }
        //}


        // the following block is for testing only, don't use it in the final product
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (slimeIndex < slimeSentences.Length - 1) {
                slimeIndex++;
                slimeText.text = string.Empty;
                StartCoroutine(slimeDialouge());
            }
            else {
                // melt away and say bye
                slimeSpeechAnimator.SetTrigger("Close");
                Destroy(this.gameObject, 2.0f);
            }
        }
    }

    void enemyDeathHandler() {
        StartCoroutine(slimeDialouge());
        float randomNumber = Random.Range(0, 100);
        PlayerInfo.Instance.hp += randomNumber;
        // give player randomized health points
        rewardSound.Play();

    }

    private IEnumerator slimeDialouge()
    {
        // activate speech bubble ccanvas
        slimeSpeechAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        foreach (char letter in slimeSentences[slimeIndex].ToCharArray())
        {
            slimeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

}
