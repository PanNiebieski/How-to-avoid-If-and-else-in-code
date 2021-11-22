
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







// Przypisywanie wartości wydzielenie metody

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




