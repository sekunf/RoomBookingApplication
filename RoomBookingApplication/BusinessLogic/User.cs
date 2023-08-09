using System;
using RoomBookingApplication.Pages;

namespace RoomBookingApplication.BusinessLogic
{
	public class User
	{

        public static Dictionary<string, string> UserInfo = new Dictionary<string, string>
        {
            { "Shalini", "Password@1" },
            { "Sekun", "Password@2" },
            { "Aryana", "Password@3" },
            { "Nicole", "Password@4" },
            { "JohnDoe", "Password@5" }

        };

        public static void Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            if (UserInfo.ContainsKey(username))
            {
                if (UserInfo[username] != password)
                {
                    throw new ArgumentException("Invalid Username");
                }

            }

            else
            {
                throw new ArgumentException("Invalid Password");

            }
        }




    }
}

