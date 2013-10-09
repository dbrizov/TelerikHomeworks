using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EbayApplication.Models;

namespace EbayApplication.Web.Models.UserModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Product> SellingProducts { get; set; }

        public ICollection<Product> BoughtProducts { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public CreditCard CreditCard { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> FromUser
        {
            get
            {
                return user => new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ShoppingCart = user.ShoppingCart
                };
            }
        }

        public static UserViewModel CreateFromUser(ApplicationUser user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ShoppingCart = user.ShoppingCart
            };
        }

        public static ApplicationUser CreateFromViewModel(UserViewModel user)
        {
            return new ApplicationUser()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ShoppingCart = user.ShoppingCart
            };
        }
    }
}