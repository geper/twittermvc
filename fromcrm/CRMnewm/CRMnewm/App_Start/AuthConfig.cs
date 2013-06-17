using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using CRMnewm.Models;

namespace CRMnewm
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // следует обновить сайт. Дополнительные сведения: http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "frKhTQjzXkbJH5vYtl8abw",
                consumerSecret: "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY");

           // credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
            //credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
