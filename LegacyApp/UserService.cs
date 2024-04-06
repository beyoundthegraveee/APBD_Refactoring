using System;

namespace LegacyApp
{
    public class UserService
    {
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            UserValidate userValidate = new UserValidate();
            if (userValidate.checkName(firstName, lastName) || !userValidate.checkEmail(email) || !userValidate.checkDate(dateOfBirth))
            {
                return false;
            }
            
            
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };



            if (!userValidate.checkClientStatus(client, user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
