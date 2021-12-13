using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = .03f;

    void Start() 
    {
        // Teacher - script is on player
        impactCanvas.enabled = false;

        // Mine - script was on the image
        // gameObject.SetActive(false);
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    // Enable Damage image, wait for x seconds then disable damage image
    IEnumerator ShowSplatter()
    {    
        // Teacher 
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime); 
        impactCanvas.enabled = false;


        // My code
        // gameObject.SetActive(true);
        // yield return new WaitForSeconds(2f);      
        // gameObject.SetActive(false);
    }

}
