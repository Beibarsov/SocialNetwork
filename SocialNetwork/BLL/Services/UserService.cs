using SocialNetwork.BLL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Entities;
using SocialNetwork.BLL.Exceptions;

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
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
        if (findUserEntity is null) throw new UserNotFoundException();

        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
    }
    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favorite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };

        if (this.userRepository.Update(updatableUserEntity) == 0)
            throw new Exception();
    }
    private User ConstructUserModel(UserEntity userEntity)
    {
        return new User(userEntity.id,
                      userEntity.firstname,
                      userEntity.lastname,
                      userEntity.password,
                      userEntity.email,
                      userEntity.photo,
                      userEntity.favorite_movie,
                      userEntity.favorite_book);
    }





}
