using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeRemaining = 300;
    private bool isRunning = false;
    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField]
    private GameObject[] objs;
    private int collectibles;
    private int nextToGet;
    void Start()
    {
        isRunning = true;
        collectibles = 5;
        nextToGet = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                UpdateTimer(timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("TIME OUT");
                isRunning = false;
            }
        }
    }
    public void UpdateTimer(float timeRemaining)
    {
        float min = Mathf.FloorToInt(timeRemaining / 60);
        float sec = Mathf.FloorToInt(timeRemaining % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void ResetGame()
    {
        for(int i = 1; i <= collectibles; i++)
        {
            Vector3 randomSpot = new Vector3(Random.Range(-11, 12), Random.Range(0.5f, 1.5f), Random.Range(-11, 12));
            objs[i].SetActive(true);
            objs[i].transform.SetPositionAndRotation(randomSpot, Quaternion.identity);
        }
    }

    public int NextToCollect()
    {
        return nextToGet;
    }

    public void UpdateNext(int num)
    {
        nextToGet = num;
    }
}
