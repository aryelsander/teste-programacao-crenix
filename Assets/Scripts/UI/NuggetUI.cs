using System.Collections;
using TMPro;
using UnityEngine;
public class NuggetUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nuggetText;

    private Coroutine showMessageCoroutine;

    public void SetText(string text,float delay)
    {
        if(showMessageCoroutine != null)
        {
            StopCoroutine(showMessageCoroutine);
        }
       showMessageCoroutine =  StartCoroutine(ShowMessage(text,delay));
    }
    private IEnumerator ShowMessage(string text,float delay)
    {
        int textSize = text.Length;
        nuggetText.text = string.Empty;
        for (int i = 0; i <= textSize; i++)
        {
            nuggetText.text = text.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }
}
