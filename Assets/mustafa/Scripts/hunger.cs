using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hunger : MonoBehaviour
{
    CharacterController controller;
    public Image Healthbar;
    public Image AclikBar;
    [Range(0,100f)]
    float health = 100f;

    float aclikbardeger = 1;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(AclikEnumartor());
        StartCoroutine(AclikSaglikArttirEnumarator());
    }


    void Update()
    {
        oldur();

    }

    private void FixedUpdate()
    {

        if(aclikbardeger <= 0)
        {
            health -= 5f;
            Healthbar.fillAmount = health / 100;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dusman"))
        {
            health -= 5f;
            Healthbar.fillAmount = health / 100;

            Debug.Log("Algiladi");
        }
        if (other.CompareTag("yemek"))
        {
            aclikbardeger += 0.02f;
            AclikBar.fillAmount = aclikbardeger;
        }
    }

    void AclikBariAzalt()
    {
        aclikbardeger -= 0.02f;
        AclikBar.fillAmount = aclikbardeger;
    }
    void AclikSaglikArttir()
    {
        if(aclikbardeger > 0.5f)
        {
            health += 3;
            Healthbar.fillAmount = health / 100;
        }

    }
    void oldur()
    {
         if(health <= 0)
        {
            Debug.Log("Karakter yenildi");
            controller.enabled = false;

            return;
        }

    }

    IEnumerator AclikEnumartor()
    {
        while (true)
        {

            Invoke(nameof(AclikBariAzalt), 5);
            yield return new WaitForSeconds(1);
        }

    }
    IEnumerator AclikSaglikArttirEnumarator()
    {
        while (true)
        {
            Invoke(nameof(AclikSaglikArttir), 1);
            yield return new WaitForSeconds(1);
        }


    }
}
