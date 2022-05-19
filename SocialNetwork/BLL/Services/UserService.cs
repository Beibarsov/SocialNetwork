using SocialNetwork.BLL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.BLL.Services;

public class UserService
{
    IUserRepository userRepository;
    public UserService()
    {
        userRepository = new UserRepository();
    }

    public void Register(UserRegistrationDate userRegistrationDate)
    {
        if (String.IsNullOrEmpty(userRegistrationDate.FirstName))
            throw new ArgumentNullException(nameof(userRegistrationDate));
        if (String.IsNullOrEmpty(userRegistrationDate.LastName))
            throw new ArgumentNullException(nameof(userRegistrationDate));
        if (String.IsNullOrEmpty(userRegistrationDate.Password))
            throw new ArgumentNullException(nameof(userRegistrationDate));
        if (String.IsNullOrEmpty(userRegistrationDate.Email))
            throw new ArgumentNullException(nameof(userRegistrationDate));
        if (userRegistrationDate.Password.Length < 8)
            throw new ArgumentNullException();
        if (!new EmailAddressAttribute().IsValid(userRegistrationDate.Email))
            throw new ArgumentNullException();


        if (userRepository.FindByEmail(userRegistrationDate.Email) != null)
        {
            throw new ArgumentNullException();
        }

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationDate.FirstName,
            lastname = userRegistrationDate.LastName,
            password = userRegistrationDate.Password,
            email = userRegistrationDate.Email
        };

        if(this.userRepository.Create(userEntity) == 0)
            throw new Exception();
    }





}
