using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Singletone UIManager.
    public static UIManager instance;

    //Reference to cat counter text.
    [SerializeField] private TextMeshProUGUI catCountText;
    //Store Designer-set values for cat counter text.
    private string catCountTextPreAppend;

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
        //Store Designer-set values for cat counter text and set start values.
        catCountTextPreAppend = catCountText.text;
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
        catCountText.text = catCountTextPreAppend + $"{GameManager.instance.CatsRescued}";
        yield return null;
    }

    public void UpdateCatCounter(float delayUpdateSeconds)
    {
        StartCoroutine(DoUpdateCatCounter(delayUpdateSeconds));
    }

}
