using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerators : MonoBehaviour
{
    [SerializeField] private GameObject bottomBound;
    [SerializeField] private GameObject rightBound;
    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject walkingDragon;

    private RectTransform rt;
    private float width;
    private float height;
    private float x, y, baseX, baseY;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        width = bottomBound.GetComponent<BoxCollider2D>().size.x * bottomBound.transform.localScale.x;
        height = rightBound.GetComponent<BoxCollider2D>().size.y * rightBound.transform.localScale.y;
        Debug.Log("Height: " + height);

        Instantiate(dummy, new Vector3(transform.position.x + width, transform.position.y + height), Quaternion.identity);
        
        baseX = transform.position.x + 10;
        baseY = transform.position.y;
        x = baseX;
        y = baseY;

        float unitInc = height / 1000.0f;
        int count = 0;
        float inc = 0;
        float ratio = 0.5f;
        int rightCount = 0;
        int leftCount = 0;
        while (y < baseY + height - 1 && count < 50)
        {
            inc = Random.Range(10.0f, 30.0f);
            if (Random.Range(0.0f, 1.0f) < ratio)
            {
                x = Mathf.Max(baseX, x - inc);
                if (x == baseX) ratio = 0.0f;
                else ratio = 0.5f;
            } else
            {
                x = Mathf.Min(baseX + width, x + inc);
                if (x == baseX + width) ratio = 0.9f;
                else ratio = 1.0f;
            }

            if (x < baseX + width / 2) leftCount++;         
            else rightCount++;

            if (x == baseX) ratio = 0.0f;
            else if (x == baseX + width) ratio = 0.9f;
            else if (leftCount > rightCount) ratio -= 0.1f;
            else if (rightCount > leftCount) ratio += 0.1f;
            else ratio = 0.5f;

            y = Random.Range(y + 70.0f*unitInc, y + 100.0f*unitInc);
            y = Mathf.Min(y, baseY + height);
            index = Random.Range(0, platforms.Length);
            Instantiate(platforms[index], new Vector3(x, y, 0), Quaternion.identity);
            if (platforms[index].name == "StaticPlatform" && Random.Range(0.0f, 1.0f) < 0.3)
            {
                Instantiate(egg, new Vector3(x, y+1, 0), Quaternion.identity);
            }

            count++;
        }

        Debug.Log("Right: " + rightCount);
        Debug.Log("Left: " + leftCount);
        Debug.Log("Ratio: " + ratio);   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
