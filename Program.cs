using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;

using System.Security;




namespace SharepointTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sitePath = "http://samscnsoft.sharepoint.com/";

           // SPSite site = new SPSite(sitePath);



            string siteUrl = "https://samscnsoft.sharepoint.com/sites/testSite2";


            
            

            ClientContext clientContext = new ClientContext(siteUrl);
            clientContext.AuthenticationMode = ClientAuthenticationMode.Default;

            clientContext.Credentials = new SharePointOnlineCredentials("mproharava@samscnsoft.onmicrosoft.com", Utility.ConvertToSecureString("Prhd7700llsd"));

            Web oWebsite = clientContext.Web;
            ListCollection collList = oWebsite.Lists;

            clientContext.Load(collList);

            clientContext.ExecuteQuery();

            foreach (SP.List oList in collList)
            {
                Console.WriteLine("Title: {0} Created: {1}", oList.Title, oList.Created.ToString());
            }

            //SPSite siteCollection = new SPSite(sitePath);
            //SPWeb site = siteCollection.RootWeb;

            //foreach (SPList list in site.Lists)
            //{
            //    Console.WriteLine(list.Title);
            //}

            //site.Dispose();
            //siteCollection.Dispose();

            Console.ReadLine();
        }

        
    }
    
}
