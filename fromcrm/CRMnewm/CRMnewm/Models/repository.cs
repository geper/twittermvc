using LinqToTwitter;
using CRMnewm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace CRMnewm.Models
{
    public class CredentialViewModel
    {
        public List<string> Credential { get; set; }
        public List<string> List_can_unfollow { get; set; }
        // мульти выделение
        public MultiSelectList CredentialList { get; private set; }

        public CredentialViewModel(int userIdProfile)
        {
            this.CredentialList = GetCredentials(null,userIdProfile);
            List_can_unfollow = new List<string>();
        }
        public CredentialViewModel()
        {
            this.CredentialList = GetCredentials(null);
            List_can_unfollow = new List<string>();
        }

        public MultiSelectList GetCredentials(string[] selectedValues, int userIdProfile)
        {

            var db = new Database1Entities();
            var list = from one in db.Credential.ToList()
                       where one.UserIdProfile == userIdProfile

                       select one;
            return new MultiSelectList(list, "Id", "ScreenName", selectedValues);
        }
        public MultiSelectList GetCredentials(string[] selectedValues)
        {

            var db = new Database1Entities();
            var list = from one in db.Credential.ToList()
                       where one.UserIdProfile == 0

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
             using (var db = new Database1Entities())
            {
                var credential = new Credential { ScreenName = "danilefer", 
                    UserTwitterId="795437948",
                    ConsumerKey="frKhTQjzXkbJH5vYtl8abw",
                    ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY",
                    AccessToken="ek1jigYRzG8vDFJY4Eh1uebW3Ey46TrJgSaEgsWAaco",
                    OAuthToken="795437948-hO24FDZX42g26cLQxmhvMnVBFkxl7vq8woSXOsqQ",
                };
                db.Credential.Add(credential);
                db.SaveChanges();

            }
         }
        public List<CRMnewm.Credential> GetCredentialList(int userIdProfile)
        {
            List<CRMnewm.Credential> AccountList = new List<Credential>();

            if (userIdProfile != 0)
            {
                using (var db = new Database1Entities())
                {
                    var list = from one in db.Credential
                               where one.UserIdProfile == userIdProfile

                               //where one.

                               select one;
                    AccountList=list.ToList();
                    
                }
            }
            return AccountList;

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
        public IOAuthCredentials GetCredential(int id, int userIdProfile)
        {

            using (var db = new Database1Entities())
            {
                  var list = from one in db.Credential.ToList()
                             where one.Id==id  && one.UserIdProfile == userIdProfile
                           select one;

                  credentials.UserId = list.First().UserTwitterId;
                 credentials.ScreenName = list.First().ScreenName;
                 credentials.AccessToken = list.First().AccessToken; 
                 credentials.OAuthToken = list.First().OAuthToken;  
                
                 credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
                 credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";
                 return credentials;

             }

            
        }
        /// <summary>
        /// Существует ли такой аккаунт в базе 
        /// </summary>
        /// <param name="twitterUserId"></param>
        /// <param name="userIdProfile"></param>
        /// <returns></returns>
        public bool isTwiterAccount(string twitterUserId, int userIdProfile)
        {
             using (var db = new Database1Entities())
            {
                 var list = from one in db.Credential.ToList()
                        where one.UserTwitterId == twitterUserId  && one.UserIdProfile == userIdProfile
                        select one;
                 if (list.Count() > 0)
                     return true;
                 else
                     return false;


            }

            
           
        }
        /// <summary>
        /// loteron_f
        /// </summary>
        /// <returns></returns>
        public IOAuthCredentials GetCredential()
        {
            using (var db = new Database1Entities())
            {
                var list = from one in db.Credential.ToList()
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