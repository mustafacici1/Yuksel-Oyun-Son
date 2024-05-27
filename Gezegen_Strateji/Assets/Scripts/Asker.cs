using UnityEngine;
using System.Collections;
using TMPro;

public class Asker : MonoBehaviour
{
    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate; // Canvas içindeki metni güncellemek için referans
    private int currentAmount;

    void Start()
    {

        if (PlayerPrefs.HasKey("Asker Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Asker Miktarı");
        }
        else
        {
            currentAmount = 0;
        }
        textToUpdate.text = "Asker Miktarı: " + currentAmount.ToString();
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
        int currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 10; // Her tıklamada 5 birim artır
        textToUpdate.text = "Asker Sayısı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Asker Miktarı", currentAmount);
        canInteract = true;
    }
}