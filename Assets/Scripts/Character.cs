using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int PvMax;
    public string Name;
    public int pv{get;set;}
    public Transform PvBarCurrent;
    public TextMesh PvText;

    // Start is called before the first frame update
    void Start()
    {
        pv = PvMax;
        // PvBarCurrent = transform.Find("PvCurrentSprit");
        // PvBarCurrent.transform.Scale = new Vector3(2, 1, 1);
        TextMesh CharacterNameText = GameObject.Find("Name").GetComponent<TextMesh>();
        CharacterNameText.text = Name;

        PvText = GameObject.Find("PvText").GetComponent<TextMesh>();
        updatePvBar();
    }

    public void Die()
    {
        PvText.text = "DEAD";
        Debug.Log($"{Name} just die.");
    }

    public void updatePvBar()
    {
        Vector3 scale = PvBarCurrent.localScale;
        float newPv = (float)pv / (float)PvMax;

        PvBarCurrent.localScale = new Vector3(newPv, scale.y, scale.z);
        PvText.text = $" {pv}/{PvMax}";
    }

    public void TakeDammage(int damage)
    {
        pv -= damage;
        updatePvBar();
        if (pv <= 0)
        {
            pv = 0;
            Die();
        }


    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonDown("Fire1"))
        {
            TakeDammage(5);
        }
    }
}
