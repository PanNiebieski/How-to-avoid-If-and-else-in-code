bool? condition = null;

if (condition == true)
{

} 
else if (condition == false)
{

}
else
{

}



//if else 

//1. jako zmiana stanu na podstawie zmiennych
//2. jako wykonanie akcji na podstawie zmiennych
//3. jako zmiana stanu i zmiennej






//Pozbycie bloku else

void SoDoThis1(int input)
{
    if (input >= 0)
    {
        //praca praca
    }
    else
    {
        //cos innego
    }
}





void SoDoThis2(int input)
{
    if (input >= 0)
    {
        //praca praca
        return;
    }
    //cos innego
}







// Przypisywanie wartości wydzielenie 

static string TranslateStatus1(int input)
{
    string status = string.Empty;

    if (input == 0)
        status = "Unknown";
    else if (input == 1)
        status = "Yes";
    else if (input == 2)
        status = "No";
    else
        status = "Error";

    return status;
}




static string TranslateStatus3(int input)
{
    string status = "Error";

    if (input == 0)
        status = "Unknown";
    else if (input == 1)
        status = "Yes";
    else if (input == 2)
        status = "No";

    return status;
}






static string TranslateStatus4(int input)
{
    if (input == 0)
        return "Unknown";
    else if (input == 1)
        return "Yes";
    else if (input == 2)
        return "No";

    return "Error";
}





// Przypisywanie wartości jeszcze krócej

static string TranslateStatus5(int input)
{
    return input == 1 ? "Yes" : "No";
}




// BIG GUNS
// Słownik i delegaty aby uniknąć if-else zupełnie

//2. jako wykonanie akcji na podstawie zmiennych

void Operation1(string operationName)
{
    if (operationName == "OP1")
    {

    }
    else if (operationName == "OP1")
    {

    }
    else
    {

    }

}


void Operation2(string operationName)
{
    var operations = 
        new Dictionary<string, Action>();

    operations["Op1"] = () => { };
    operations["Op2"] = () => { };

    //w innym miejscu
    operations[operationName].Invoke();
}




