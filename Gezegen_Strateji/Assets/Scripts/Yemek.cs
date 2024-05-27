using UnityEngine;
using System.Collections;
using TMPro;

public class BuildingInteraction : MonoBehaviour
{
    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate; // Canvas içindeki metni güncellemek için referans
    private int currentAmount;

    void Start()
    {

        if (PlayerPrefs.HasKey("Yemek Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Yemek Miktarı");
        }
        else
        {
            currentAmount = 0;
        }
        textToUpdate.text = "Yemek Miktarı: " + currentAmount.ToString();
    }


    private void OnMouseDown()
    {
        if (canInteract && Input.GetMouseButtonDown(0)) // Sadece sol tıklama ile etkileşime girsin
        {
            StartCoroutine(InteractWithDelay());
        }
    }

    IEnumerator InteractWithDelay()
    {
        canInteract = false;

        yield return new WaitForSeconds(5f);

        // Canvas içindeki metni güncelle
        currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 5; // Her tıklamada 5 birim artır
        textToUpdate.text = "Yemek Sayısı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Yemek Miktarı", currentAmount);

        canInteract = true;
    }
}