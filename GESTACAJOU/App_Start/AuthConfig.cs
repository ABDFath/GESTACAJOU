using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using GESTACAJOU.Models;

namespace GESTACAJOU
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // Pour permettre aux utilisateurs de ce site de se connecter à l’aide de leur compte à partir d’autres sites tels que Microsoft, Facebook et Twitter,
            // vous devez mettre à jour ce site. Pour plus d’informations, consultez la page http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
            // Configure the db context and user manager to use a single instance per request
            //OAuthWebSecurity.RegisterClient(new mcv4_front.App_Start.GoogleAuthMe("149691483108-354vamvq0bdvlbk0hv2ao9mmsljfegns.apps.googleusercontent.com",
            //    "21fdcfWQYFBFBUesKAFyIvqP"), "Gmail", null); //live
            //#if DEBUG

            OAuthWebSecurity.RegisterClient(new GESTACAJOU.App_Start.GoogleAuthMe("149691483108-l0grspofkr6qho7026engb38a9fpjp8a.apps.googleusercontent.com",
                "8IxRynddz-UtS9shgK6GdXPZ"), "Gmail", null); //test
            //#endif

        }
    }
}
