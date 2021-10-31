using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Singletone UIManager.
    public static UIManager instance;

    //Reference to cat rescue text.
    [SerializeField] private TextMeshProUGUI catRescueText;
    //Store Designer-set values for cat counter text.
    private string catRescueTextPreAppend;
    //Reference to cat sacrifice text.
    [SerializeField] private TextMeshProUGUI catSacrificeText;
    //Store Designer-set values for cat counter text.
    private string catSacrificeTextPreAppend;


    private void Awake()
    {
        //Set Singleton and destroy duplicates.
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple UIManagers detected. Duplicates were destroyed.");
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //Store Designer-set values for cat counter text and set start values in the next frame.
        catRescueTextPreAppend = catRescueText.text;
        catSacrificeTextPreAppend = catSacrificeText.text;
        StartCoroutine(DoUpdateCatCounter(Time.deltaTime)); 
    }

    private IEnumerator DoUpdateCatCounter(float delayUpdate)
    {
        //Wait for delay if set.
        if (delayUpdate > 0)
        {
            yield return new WaitForSeconds(delayUpdate);
        }        

        //Update cat counter.
        catRescueText.text = catRescueTextPreAppend + $"{GameManager.instance.CatsRescued}";
        catSacrificeText.text = catSacrificeTextPreAppend + $"{GameManager.instance.CatsSacrificed}";
        yield return null;
    }

    public void UpdateCatCounter(float delayUpdateSeconds)
    {
        StartCoroutine(DoUpdateCatCounter(delayUpdateSeconds));
    }

}
