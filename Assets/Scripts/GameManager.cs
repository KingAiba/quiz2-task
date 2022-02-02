using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public List<GameObject> ActiveEnemies = new List<GameObject>();

    public PlayerScript playerScript;

    public TMP_Text endGameText;

    
    void Start()
    {
        //playerObject = GameObject.Find("Player");
    }

    
    void Update()
    {
        OnPlayerDeath();
    }

    public void AddToList(GameObject obj)
    {
        ActiveEnemies.Add(obj);
    }

    public void RemoveFromList(GameObject obj)
    {
        ActiveEnemies.Remove(obj);
    }

    public void AddScore(int amount)
    {
        if (!playerScript.isDead)
        {
            score += amount;
        }
        
    }

    public int GetActiveEnemyCount()
    {
        return ActiveEnemies.Count;
    }

    public void OnPlayerDeath()
    {
        if(playerScript.isDead)
        {
            endGameText.gameObject.SetActive(true);
            endGameText.SetText("YOU DIED\nSCORE:" + score);
        }
    }

}
