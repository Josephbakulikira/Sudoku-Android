using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public static InputField instance;

    numberButton lastField;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateInputField(numberButton last)
    {
        this.gameObject.SetActive(true);
        lastField = last;
    }
    public void ClickedInput(int number)
    {
        lastField.ReceiveInput(number);
        this.gameObject.SetActive(false);
    }

    
}
