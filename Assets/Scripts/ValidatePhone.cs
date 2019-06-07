using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidatePhone : MonoBehaviour {

    private string oldNums;
    private string number;

    private string ExtractNums(string str)
    {
        string allNums = "";
        for (int i = 0; i < str.Length; i++)
        {
            string currentNum = str[i].ToString();
            if (currentNum == "0" | currentNum == "1" | currentNum == "2" | currentNum == "3" | currentNum == "4" | currentNum == "5" | currentNum == "6" | currentNum == "7" | currentNum == "8" | currentNum == "9")
            {
                allNums += currentNum;
            }
        }
        return allNums;
    }

    public void ToNumerals()
    {
        var phone = gameObject.GetComponent<InputField>();
        string numerals = ExtractNums(phone.text);
        phone.text = numerals;
        phone.characterLimit = 10;
    }

    private void Done()
    {
        var phone = gameObject.GetComponent<InputField>();
        if (phone.text != "")
        {
            phone.characterLimit = 14;
            Validate(phone);
        }
    }


    public void Validate(InputField phone)
    {
        number = phone.text;

        if (number.Length < 3)
        {
            number = "(" + number;
            phone.text = number;
        }
        else if(number.Length == 3)
        {
            number = "(" + number + ") ";
            phone.text = number;
        }
        else if (number.Length < 6)
        {
            number = "(" + number.Substring(0, 3) + ") " + number.Substring(3, number.Length - 3);
            phone.text = number;
        }
        else if(number.Length == 6)
        {
            number = "(" + number.Substring(0,3) + ") " + number.Substring(3,3)+"-";
            phone.text = number;
        }
        else if(number.Length < 10)
        {
            number = "(" + number.Substring(0, 3) + ") " + number.Substring(3, 3) + "-" + number.Substring(6, number.Length - 6);
            phone.text = number;
        }
        else
        {
            number = "(" + number.Substring(0, 3) + ") " + number.Substring(3, 3) + "-" + number.Substring(6, 4);
            phone.text = number;
        }
    }
}
