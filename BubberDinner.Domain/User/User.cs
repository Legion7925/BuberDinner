﻿using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public User(UserId id,
                string firstName,
                string lastName,
                string email,
                string password,
                DateTime createdDateTime,
                DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static User Create(string firstName,
                string lastName,
                string email,
                string password,
                DateTime createdDateTime,
                DateTime updatedDateTime)
    {
        return new User (UserId.CreateUnique(),
                         firstName,
                         lastName,
                         email,
                         password,
                         DateTime.UtcNow,
                         DateTime.UtcNow);
    }
}
