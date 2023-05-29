using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coiny : MonoBehaviour
{
    public int startingCoins = 0;
    public Text licz_monety;
    private int coins; 
    // Start is called before the first frame update
    void Start()
    {
        licz_monety = GameObject.Find("CoinText").GetComponent<Text>();
        coins = startingCoins; // Ustawienie pocz¹tkowej iloœci monet
        UpdateCoinText(); // Wyœwietlenie aktualnej iloœci monet

    }

    // Update is called once per frame
    void Update()
    {
        

    }
   /* public void SubtractCoins(int amount)
    {
        coins -= 1; // Odebranie monet z aktualnej iloœci
        UpdateCoinText(); // Wyœwietlenie aktualnej iloœci monet
    }
   */
   
    private void UpdateCoinText()
    {
        licz_monety.text = coins.ToString(); // Aktualizacja tekstu wyœwietlaj¹cego iloœæ monet
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
    {
            coins += 1; // Dodanie monet do aktualnej iloœci
            UpdateCoinText(); // Wyœwietlenie aktualnej iloœci monet
            Destroy(gameObject);

        }
    }
}