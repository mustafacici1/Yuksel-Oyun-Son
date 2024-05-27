using UnityEngine;
using System.Collections;
using TMPro;

public class GoldGenerator : MonoBehaviour
{
    public TextMeshProUGUI goldText; // Canvas içindeki altın metninin referansı
    public int goldToAdd = 20; // Her artışta eklenecek altın miktarı
    public float interval = 10f; // Altın artışının tekrarlanma aralığı (saniye)
    private int currentGold;
    public bool canInteract = true;
    private void Start()
    {


        if (PlayerPrefs.HasKey("Altın Miktarı"))
        {
            currentGold = PlayerPrefs.GetInt("Altın Miktarı");
            Debug.Log("xsa");
        }
        else
        {
            currentGold = 0;
            Debug.Log("xs");
        }
        goldText.text = "Altın Miktarı: " + currentGold.ToString();
    }

    private void OnMouseDown()
    {
        if (canInteract && Input.GetMouseButtonDown(0)) // Sadece sol tıklama ile etkileşime girsin
        {
            StartCoroutine(GenerateGold());
        }
    }

    IEnumerator GenerateGold()
    {
        while (true)
        {
            canInteract = false;

            yield return new WaitForSeconds(5f);

            // Canvas içindeki metni güncelle
            int currentAmount = int.Parse(goldText.text.Split(':')[1].Trim()); // Mevcut miktarı al
            currentGold += 10; // Her tıklamada 5 birim artır
            goldText.text = "Altın Sayısı: " + currentAmount.ToString(); // Metni güncelle

            canInteract = true;


            PlayerPrefs.SetInt("Altın Miktarı", currentGold);
        }
    }
}