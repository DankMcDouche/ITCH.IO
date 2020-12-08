using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject EnemyShip;

    public TextMeshProUGUI ScoreText;

    public Vector3 ShipSpawn;

    int DisplayScore;

    private void Start()
    {
        ShipSpawn = new Vector3(0, 6.8f, 0);
        EnemyShip.transform.Rotate(0,0,90);
        SpawnShip();
        ScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        CalculateScore(0);
    }

    public void SpawnShip()
    {
        Instantiate(EnemyShip, ShipSpawn, Quaternion.identity);
    }

    public void CalculateScore(int calculatedScore)
    {
        DisplayScore += calculatedScore;
        print(DisplayScore);
        ScoreText.text = "Score: " + DisplayScore;
    }
}
