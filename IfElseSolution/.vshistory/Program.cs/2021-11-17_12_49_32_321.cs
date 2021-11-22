
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



static string TranslateStatus2(int input)
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






static string TranslateStatus3(int input)
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

static string TranslateStatus4(int input)
{
    return input == 1 ? "Yes" : "No";
}




