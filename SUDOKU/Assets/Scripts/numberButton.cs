using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberButton : MonoBehaviour
{
    Tableau board;

    public Text number;

    private int x1, y1, value;
    private string identifier;

    public void SetValue(int x1, int y1,int value,string identifier, Tableau board)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.value = value;
        this.identifier = identifier;
        this.board = board;

        number.text = (value != 0) ? value.ToString() : "";
        if (value != 0 )
        {
            GetComponentInParent<Button>().interactable = false;
        }
        else {
            number.color = Color.blue;
            
        }

         
    }
    public void ButtonClick()
    {
        InputField.instance.ActivateInputField(this);
    }

    public void ReceiveInput(int newValue)
    {
        value = newValue;
        number.text = (value != 0) ? value.ToString() : "";

        board.SetInputRiddle(x1, y1, value);
    }
    public int GetX()
    {
        return x1;
    }
    public int GetY()
    {
        return y1;
    }
    public void SetIndice(int value)
    {
        this.value = value;
        number.text = this.value.ToString();
        number.color = Color.green;
        GetComponentInParent<Button>().interactable = false;
    }
    

}
