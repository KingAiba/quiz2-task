using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public List<GameObject> ActiveEnemies = new List<GameObject>();

    public GameObject playerObject;

    public TMP_Text endGameText;

    
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    
    void Update()
    {
        
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
        score += amount;
    }
        
}
