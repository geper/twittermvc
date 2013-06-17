using LinqToTwitter;
using MvcAppTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppTwitter.Models
{
    public class CredentialViewModel
    {
        public List<string> Credential { get; set; }
        public List<string> List_can_unfollow { get; set; }
        // мульти выделение
        public MultiSelectList CredentialList { get; private set; }

        public CredentialViewModel()
        {
            this.CredentialList = GetCredentials(null);
            List_can_unfollow = new List<string>();
        }

        public MultiSelectList GetCredentials(string[] selectedValues)
        {
            var db = new CredentialsContext();
            var list = from one in db.Credentials.ToList()
                       select one;
            return new MultiSelectList(list, "Id", "ScreenName", selectedValues);
        }
    }

    public class repository
    {
        /// <summary>
        /// создание пользователя твиттера
        /// </summary>
        public void   create ()
         {
            using (var db = new CredentialsContext())
            {
                var credential = new Credential { ScreenName = "danilefer", 
                    UserID="795437948",
                    ConsumerKey="frKhTQjzXkbJH5vYtl8abw",
                    ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY",
                    AccessToken="ek1jigYRzG8vDFJY4Eh1uebW3Ey46TrJgSaEgsWAaco",
                    OAuthToken="795437948-hO24FDZX42g26cLQxmhvMnVBFkxl7vq8woSXOsqQ",
                };
                db.Credentials.Add(credential);
                db.SaveChanges();

            }
         }
        public List<Credential> GetCredentialList()
        {
             using (var db = new CredentialsContext())
            {
                  var list = from one in db.Credentials.ToList()
                           select one;

                  return list.ToList();
             }

        }
        private IOAuthCredentials credentials = new SessionStateCredentials();
        private MvcAuthorizer auth;

        public int GetTwitterContext()
        {
            
        
            
            // if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
            //{
            //    credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
            //    credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";

            //}

            //auth = new MvcAuthorizer {  Credentials = credentials };

            //auth.CompleteAuthorization(Request.Url);

            //if (!auth.IsAuthorized)
            //{
            //    Uri specialUri = new Uri(Request.Url.ToString());
            //   // return auth.BeginAuthorization(specialUri);
            //}

            return 0;
        }
        /// <summary>
        /// Занолняет Credential 
        /// </summary>
        /// <param name="id"> индефикатор вользователя </param>
        /// <returns></returns>
        public IOAuthCredentials GetCredential(int id)
        {
            
            using (var db = new CredentialsContext())
            {
                  var list = from one in db.Credentials.ToList()
                             where one.Id==id
                           select one;

                  credentials.UserId = list.First().UserID;
                 credentials.ScreenName = list.First().ScreenName;
                 credentials.AccessToken = list.First().AccessToken; 
                 credentials.OAuthToken = list.First().OAuthToken;        
                 credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
                 credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";
                 return credentials;

             }

            
        }
        /// <summary>
        /// loteron_f
        /// </summary>
        /// <returns></returns>
        public IOAuthCredentials GetCredential()
        {
            using (var db = new CredentialsContext())
            {
                var list = from one in db.Credentials.ToList()
                           where one.ScreenName == "loteron_f"
                           select one;

                credentials.AccessToken = list.First().AccessToken;
                credentials.OAuthToken = list.First().OAuthToken;
                credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
                credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";
                return credentials;

            }

        }
       
    }
    public class ResultsViewModel
    {
        public string ScreenName { get; set; }

        public string DirectMessage { get; set; }

        public bool IsAuthorized { get; set; }

    }
}