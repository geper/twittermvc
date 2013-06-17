using LinqToTwitter;
using MvcAppTwitter.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcAppTwitter.Controllers
{
    public class HomeController : Controller
    {

        repository _repository = new repository();
        //Install-Package linqtotwitter 
        /// <summary>
        /// отображаем все аккаунты в твиттере
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {

            ViewBag.Message = "Список все аккаунтов";

            var db = new CredentialsContext();
            
                var list = from one in db.Credentials.ToList()
                           select one;

                List<SelectListItem> items = new List<SelectListItem>();

            foreach (var df in list)
            {
                items.Add(new SelectListItem { Text = df.ScreenName, Value = df .UserID});
            }



            ViewBag.UserID = items;
        

            return View(list);
        }

        private IOAuthCredentials credentials = new SessionStateCredentials();
        
        private MvcAuthorizer auth;
        private TwitterContext twitterCtx;
        /// <summary>
        /// Добавление токенов в базц
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateAccaount()
        {
   

            if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
            {
                credentials.ConsumerKey = "frKhTQjzXkbJH5vYtl8abw";
                credentials.ConsumerSecret = "TMSZhd9nH2DsfkNi0OJLrw8eRy8URl5IaH8OxJpkY";

            }

            auth = new MvcAuthorizer {  Credentials = credentials };

            auth.CompleteAuthorization(Request.Url);

            if (!auth.IsAuthorized)
            {
                Uri specialUri = new Uri(Request.Url.ToString());
                return auth.BeginAuthorization(specialUri);
            }

            using (var db = new CredentialsContext())
            {
                var credential = new Credential
                {
                    ScreenName = auth.Credentials.ScreenName,
                    UserID = auth.Credentials.UserId,
                    ConsumerKey = "",
                    ConsumerSecret = "",
                    AccessToken = auth.Credentials.AccessToken,
                    OAuthToken = auth.Credentials.OAuthToken,
                };
                db.Credentials.Add(credential);
                db.SaveChanges();

            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult DropDLIst()
        {

            return View(new CredentialViewModel());


        }
        /// <summary>
        /// Отправка ттвитов в скоко хочешь аккаунтов с картинкой
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DropDLIst(CredentialViewModel vm,string img_url,string comment)
        {

            ViewBag.YouSelected = "";
            if (vm.Credential != null)
                foreach (string s in vm.Credential)
                    ViewBag.YouSelected += s + " ";
            ViewBag.YouSelected += comment;
           
             if (vm.Credential != null)
                foreach (string s in vm.Credential)
                {
                    credentials = _repository.GetCredential(Convert.ToInt32(s));

                    auth = new MvcAuthorizer { Credentials = credentials };

                    auth.CompleteAuthorization(Request.Url);

                    if (!auth.IsAuthorized)
                    {
                        Uri specialUri = new Uri(Request.Url.ToString());
                        return auth.BeginAuthorization(specialUri);
                    }

                    twitterCtx = new TwitterContext(auth);

                    //пост твиттер
                    string status = comment;
                    //"Котэ " + DateTime.Now.ToString(CultureInfo.InvariantCulture);

                    const bool PossiblySensitive = false;
                    const decimal Latitude = StatusExtensions.NoCoordinate; //37.78215m;
                    const decimal Longitude = StatusExtensions.NoCoordinate; // -122.40060m;
                    const bool DisplayCoordinates = false;

                    var webClient = new WebClient();
                    var mediaItems =
                        new List<Media>
                            {
                                new Media
                                {
                                    Data=webClient.DownloadData(img_url),
                                   // Data=webClient.DownloadData("http://img0.liveinternet.ru/images/attach/c/0/36/687/36687792_1229264096_rjn5.jpg"),
                                    //Data = Utilities.GetFileBytes("http://img0.liveinternet.ru/images/attach/c/0/36/687/36687792_1229264096_rjn5.jpg"),
                                    FileName = "cars_0024.jpg",
                                    ContentType = MediaContentType.Jpeg
                                }
                            };
                    

                    //отправка твита
                    Status tweetst = twitterCtx.TweetWithMedia(
                        status, PossiblySensitive, Latitude, Longitude,
                        null, DisplayCoordinates, mediaItems, null);
                }
                    

            return View(vm);

        }

        public ActionResult About(string UserID)
        {
            ViewBag.Message = "Страница описания приложения.";


            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }

        public ActionResult UnfollowFriends()
        {
            return View();
        }
        public ActionResult PeformQuery()
        {
            const int dmCount = 3;

            // authorization should have been complete before
            // arriving here, and SessionStateCredentials will
            // get credentials from SessionState, if available.

            var auth = new MvcAuthorizer       {Credentials = _repository.GetCredential()};

            //RedirectToAction("Authenticate", "OAuth");

           // if (!auth.IsAuthorized) RedirectToAction("Authenticate", "OAuth");
            auth.CompleteAuthorization(Request.Url);

            var twitterCtx = new TwitterContext(auth);
            //twitterCtx.DirectMessage.ToList();

            //var directMessagesResults =
            //    from tweet in twitterCtx.DirectMessage
            //    where tweet.Type == DirectMessageType.Show 
            //    select tweet ;


            var directMessages =
                    (from tweet in twitterCtx.DirectMessage
                     where tweet.Type == DirectMessageType.SentTo &&
                           tweet.Count == 10
                     select new 
                     {
                         tweet.SenderScreenName,
                         tweet.ID,
                         tweet.Text
                         
                     });
            //var directMessages = twitterCtx.DirectMessage;

            int df=twitterCtx.RateLimitCurrent;
               //(from tweet in twitterCtx.DirectMessage
               // where tweet.Type == DirectMessageType.SentTo &&
               //       tweet.Count == 2
               // select tweet)
               // .ToList();

            List<ResultsViewModel> dfg=new List<ResultsViewModel>();
            foreach (var tw in directMessages)
            {
                dfg.Add(
                new ResultsViewModel{
                    ScreenName=tw.SenderScreenName,
                    DirectMessage=tw.Text

                    
                });
            

            }

            return View(dfg);
        }

        /// <summary>
        /// Отправка ттвитов в скоко хочешь аккаунтов с картинкой
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Unfollow(CredentialViewModel vm)
        {
            List<string> listanfollowers = new List<string>();
           
            if (vm.Credential != null)
                foreach (string s in vm.Credential)
                {
                    credentials = _repository.GetCredential(Convert.ToInt32(s));
                    
                    auth = new MvcAuthorizer { Credentials = credentials };

                    auth.CompleteAuthorization(Request.Url);

                    if (!auth.IsAuthorized)
                    {
                        Uri specialUri = new Uri(Request.Url.ToString());
                        return auth.BeginAuthorization(specialUri);
                    }

                    twitterCtx = new TwitterContext(auth);
                    var friendList =
                            (from friend in twitterCtx.SocialGraph
                             where friend.Type == SocialGraphType.Friends &&
                                   friend.ScreenName == credentials.ScreenName
                             select friend)
                             .SingleOrDefault();

                    var followersList =
                        (from follower in twitterCtx.SocialGraph
                         where follower.Type == SocialGraphType.Followers &&
                               follower.ScreenName == credentials.ScreenName
                         select follower)
                         .SingleOrDefault();

                    bool flag  =false;
                   
                    string fg="";
                    foreach (var friend in friendList.IDs)
                    {
                        fg = friend;
                        foreach (var follower in followersList.IDs)
                        {
                            if (follower == friend)
                            {
                                flag = false;
                                break;
                            }
                            flag = true;



                        }
                        if (flag == true)
                        {
                           
                            vm.List_can_unfollow.Add(fg);
                        }

                    }
                    
                }

            return View(vm);
        }
        public ActionResult RateLimite()
        {

            return View();
        }

        public ActionResult Unfollow()
        {

            return View(new CredentialViewModel());


        }

    }
}
