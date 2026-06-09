using UnityEngine;

public class HP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHP = 100;
    public int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
