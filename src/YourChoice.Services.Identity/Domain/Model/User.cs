using System;
using YourChoice.Common.Exceptions;
using YourChoice.Services.Identity.Domain.Services;

namespace YourChoice.Services.Identity.Domain.Model
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Name { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
            
        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new YourChoiceException("empty_user_email",
                    $"User email can not be empty");
            if (string.IsNullOrWhiteSpace(name))
                throw new YourChoiceException("empty_user_name",
                    $"User name can not be empty");
            
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new YourChoiceException("emtpy_password", 
                    $"Password can not be empty");

            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}