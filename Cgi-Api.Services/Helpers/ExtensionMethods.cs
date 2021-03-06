﻿using Cgi_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cgi_Api.Services.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
