using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public void Deposit(int amouunt)
    {
        currentBalance += Mathf.Abs(amouunt);
        UpdateDisplay();
    }

    public void Withdraw(int amouunt)
    {
        currentBalance -= Mathf.Abs(amouunt);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            //todo lose
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
        if (currentBalance == 500) SceneManager.LoadScene("Congrats");
    }
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
