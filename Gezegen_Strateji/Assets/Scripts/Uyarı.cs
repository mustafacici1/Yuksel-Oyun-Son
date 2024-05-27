using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Uyarı : MonoBehaviour
{
    public Text displayText; // Canvas üzerindeki Text elemanı

    private void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false); // Başlangıçta yazıyı gizliyoruz
        }
    }

    private void OnMouseDown()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(true); // Tıklama olduğunda yazıyı gösteriyoruz
           
            StartCoroutine(HideTextAfterDelay(5f)); // 5 saniye sonra metni gizle
        }
    }
    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen süre kadar bekler
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false); // Metni tekrar gizler
        }
    }
}
