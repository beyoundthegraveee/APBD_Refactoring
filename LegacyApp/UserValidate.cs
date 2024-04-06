using System;

namespace LegacyApp;

public class UserValidate
{

    public bool checkName(string firstName , string lastname)
    {
        return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastname);
    }

    public bool checkEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public bool checkDate(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;
    }

    public bool checkClientStatus(Client client,User user)
    {
        switch (client.Type)
        {
            case "VeryImportantClient":
                user.HasCreditLimit = false;
                break;
            case "ImportantClient":
                using (var userCreditService = new UserCreditService())
                {
                    user.CreditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth) * 2;
                }
                break;
            default:
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    user.CreditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                }
                break;
        }
        
        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }

        return true;

    }
    
    
    
}