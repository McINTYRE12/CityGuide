using CG.Domain;
using Facebook;
using System;
using System.Web.Mvc;
using System.Web.Security;
using CG.DataAccess;

namespace FacebookAuth.Controllers
{
    public class AccountController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "1018612288230748",
                client_secret = "85a5bdf69dda687274a5be028818f3a3",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email" // Add other permissions as needed
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var CurrentUser = new User();
            var fb = new FacebookClient();
            var ctx = new CityGuideContext();
            var db = new CityGuideDatabase(ctx);

            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "1018612288230748",
                client_secret = "85a5bdf69dda687274a5be028818f3a3",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            // Store the access token in the session for farther use
            Session["AccessToken"] = accessToken;

            // update the facebook client with the access token so 
            // we can make requests on behalf of the user
            fb.AccessToken = accessToken;

            // Get the user's information
            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
            CurrentUser.Email = me.email;
            CurrentUser.FirstName = me.first_name;
            CurrentUser.MiddleName = me.middle_name;
            CurrentUser.LastName = me.last_name;
            CurrentUser.FacebookID = me.id;

            db.AddUserToDB(CurrentUser);
            // Set the auth cookie
            FormsAuthentication.SetAuthCookie(CurrentUser.Email, false);
            return RedirectToAction("Index", "Home");
        }
    }
}