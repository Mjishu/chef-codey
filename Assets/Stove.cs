using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("inventory")]
    public GameObject[] cookedFoods;
    public string cookedFood = "";

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    [Header("Cook settings")]
    public float timeToCook = 5f;
    public bool hasCooked = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cookedFoods.Length; i++)
        {
            cookedFoods[i].SetActive(false);
        }
    }

    public void MakeBurger()
    {
        smoke.Play();
        cookedFoods[0].SetActive(true);
        cookedFood = "burger";
        Invoke("CompleteCooking", timeToCook);
    }

    public void MakeSoda()
    {
        smoke.Play();
        cookedFoods[1].SetActive(true);
        cookedFood = "tomatoSoda";
        Invoke("CompleteCooking", timeToCook);
    }

    public void CleanStove()
    {
        for (int i = 0; i < cookedFoods.Length; i++)
        {
            cookedFoods[i].SetActive(false);
        }
        cookedFood = "";
        complete.Stop();
        hasCooked = false;
    }

    private void CompleteCooking()
    {
        smoke.Stop();
        complete.Play();
        hasCooked = true;
    }
}
