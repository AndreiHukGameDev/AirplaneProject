using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextEditor : MonoBehaviour
{
    public Text Score, Health, Bombs, Rockets, Coin;

    public EnemyGenerator EnemyGenerator;
    public CoinsGenerator CoinsGenerator;
    public PlayerControl PlayerControl;

    private string _score = "Your score: ";
    private string _health = "Your HP: ";
    private string _bombs = "Bombs: ";
    private string _rockets = "Rockets: ";



    private void FixedUpdate()
    {
        Score.text = _score + PlayerControl.ReturnScore().ToString();
        Health.text = _health + PlayerControl.ReturnHealth().ToString();
        Bombs.text = _bombs + EnemyGenerator.ReturnBombCount().ToString();
        Rockets.text = _rockets + EnemyGenerator.ReturnRocketCount().ToString();
        Coin.text = CoinsGenerator.ReturnCoinCount().ToString();
    }
}
