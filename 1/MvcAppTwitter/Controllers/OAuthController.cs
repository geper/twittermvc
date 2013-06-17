using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LinqToTwitter;
using System.Web;
using System.Web.Mvc;
using MvcAppTwitter.Models;

namespace MvcAppTwitter.Controllers
{
    public class OAuthController : Controller
    {
        repository _repository = new repository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate()
        {
            MvcAuthorizer auth;

            IOAuthCredentials credentials = new SessionStateCredentials();

            //if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
            //{
            //    credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
            //    credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";
            //}
            //регистрируем первого влиента
            credentials = _repository.GetCredential(1);
            auth = new MvcAuthorizer
            {
                Credentials = credentials,
            };

            if (string.IsNullOrWhiteSpace(credentials.ConsumerKey) ||
                string.IsNullOrWhiteSpace(credentials.ConsumerSecret))
            {
                return RedirectToAction("Error");
            }

            auth.CompleteAuthorization(Request.Url);

            if (!auth.IsAuthorized)
            {
                Uri specialUri = new Uri(Request.Url.ToString());
                return auth.BeginAuthorization(specialUri);
            }

            return Redirect(Request.Url.ToString());
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
