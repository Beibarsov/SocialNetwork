using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork;

namespace SocialNetwork.PPL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Введите 1 чтобы зайти в профиль");
            Console.WriteLine("Введите 2 чтобы начать регистрацию");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.AuthOnProfileView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.RegistrationUserVIew.Show();
                        break;
                    }
            }
        }
    }
}
