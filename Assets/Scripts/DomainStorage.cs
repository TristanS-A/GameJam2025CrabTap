using System;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public static class DomainStorage
{
    private static Dictionary<string, DomainInfo> urlIdPairs = new Dictionary<string, DomainInfo>();
    private static Dictionary<string, DomainInfo> baughtURLs = new Dictionary<string, DomainInfo>();
    private static Dictionary<string, GameObject> windows = new();
    private static List<DomainInfo> urls = new List<DomainInfo>();
    private static List<string> trends;
    private static string[] hotTrends = new string[3];
    private static GameObject mCurrWindow;

    public struct DomainInfo
    {
        public string[] trends;
        public string url;
        public float price;

        public DomainInfo(string url, string[] trends)
        {
            this.url = url;
            this.trends = trends;
            this.price = 0.50f;
        }
    }

    public static string[] HotTrends
    {
        get { return hotTrends; }
        set { hotTrends = value; }
    }

    public static GameObject CurrWindow
    {
        get { return mCurrWindow; }
        set { mCurrWindow = value; }
    }

    public static Nullable<DomainInfo> getDomainInfoFromID(string id)
    {
        DomainInfo newInfo;
        if (urlIdPairs.TryGetValue(id, out newInfo))
        {
            return newInfo;
        }

        return null;
    }

    public static Dictionary<string, DomainInfo> getDomainInfoList()
    {
        return urlIdPairs;
    }

    public static Dictionary<string, GameObject> getWindowDictionary()
    {
        return windows;
    }

    public static void addToWindows(string key, GameObject window)
    {
        if (!windows.ContainsKey(key))
        {
            windows.Add(key, window);
        }
    }

    public static void addToBoughtURLs(string key, DomainInfo info)
    {
        if (!baughtURLs.ContainsKey(key))
        {
            baughtURLs.Add(key, info);
        }
    }

    public static Nullable<DomainInfo> getBoughtDomainInfoFromID(string id)
    {
        DomainInfo newInfo;
        if (baughtURLs.TryGetValue(id, out newInfo))
        {
            return newInfo;
        }

        return null;
    }

    public static Dictionary<string, DomainInfo> getBoughtDomainDictionary()
    {
        return baughtURLs;
    }

    public static GameObject getWindowFromKey(string key)
    {
        GameObject window = null;
        windows.TryGetValue(key, out window);
        return window;
    }

    public static void removeID(string id)
    {
        urlIdPairs.Remove(id);
    }

    public static List<string> createFullTrendList()
    {
        trends = new List<string>();
        trends.Add("None");
        trends.Add("Toys");
        trends.Add("MTV");
        trends.Add("Pop Culture");
        trends.Add("Fashion");
        trends.Add("Video Games");
        trends.Add("Business");
        trends.Add("Scams");
        trends.Add("Jokes");
        trends.Add("Education");
        trends.Add("Conspiracy");

        return trends;
    }

    public static void BuildUrlPacks()
    {
        urlIdPairs.Clear();
        urls.Clear();

        urls.Add(new DomainInfo("jackfrosttips.com", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("yoyoallday.com", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("mtvismylife.org", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("pokerman4gamegirl.com", new string[]
        {
            "Video Games"
        }));
        urls.Add(new DomainInfo("mtvmusicdotcom.com", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("yoyoallday.com", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("mtvmusicdotcom.com", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("ilovenysnc.gov", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("how2fixflipphone.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("lowriderjeans4sale.com", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("80sbabies4lyfe.org", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("buyJNCOSnow.com", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("mytomagotchidied.com", new string[]
        {
            "Video Games", "Pop Culture"
        }));
        urls.Add(new DomainInfo("cupwithblueandpurplescribbles.com", new string[]
        {
            "Pop Culture", "Business", "Fashion"
        }));
        urls.Add(new DomainInfo("skateboards4posers.gov", new string[]
        {
            "Toys", "Pop Culture"
        }));
        urls.Add(new DomainInfo("cheapsnapbraclets.com", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("ilovebeaniebabies.com", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("coolplasticonastring.com", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("coolsciencegames.com", new string[]
        {
            "Video Games"
        }));
        urls.Add(new DomainInfo("fredsflops.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("lemonwire.com", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("trackys4hire.org", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("ilooklikebillclinton.com", new string[]
        {
            "Memes"
        }));
        urls.Add(new DomainInfo("money4beaniebabiesNOW.gov", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("notaurldotcom.com", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("blockbustersbutonline.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("downloadmoreram.com", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("mynameisjeff.com", new string[]
        {
            "Memes"
        }));
        urls.Add(new DomainInfo("crabsthattap.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("mycouchisonfire.gov", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("themoonischeese.org", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("donutearththeoryconfirmed.gov", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("transquilbeats2sleep2.com", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("trillionawesomegames.com", new string[]
        {
            "Video Games"
        }));
        urls.Add(new DomainInfo("picturesofdogswithhats.gov", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("back2thefuturefanclub.org", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("Swashbucklersbay.yar", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("notavirus.exe", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("dropshippingbeforeitwascool.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("hairspraydealer.org", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("iwannabeayoyoman.org", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("keeponyoing.gov", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("yoyotricks4begineers.com", new string[]
        {
            "Toys"
        }));
        urls.Add(new DomainInfo("Worldwideweb.scam", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("freethings.org", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("webaholics.com", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("peanutbutterandspacejam.gov", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("leocities.com", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("audioforu.org", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("mycoolassstuffandthings.gov", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("catsandthebigbang.com", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("frogdementia.gov", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("blackbeardscrew.org", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("tracksuitdad.gov", new string[]
        {
            "Fashion"
        }));
        urls.Add(new DomainInfo("onlydads.com", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("paradisekoolio.com", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("buyrobotbirds.gov", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("iwillkillyourfamilyunlessyoubuythis.biz", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("silenceofthescams.com", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("downloadmoviesfree.com", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("gameboytutorials.com", new string[]
        {
            "Video Games"
        }));
        urls.Add(new DomainInfo("noboysallowed.com", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("schmoogle.org", new string[]
        {
            "Business", "Education"
        }));
        urls.Add(new DomainInfo("wonkipedia.org", new string[]
        {
            "Business", "Education"
        }));
        urls.Add(new DomainInfo("bookface.gov", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("bigshotautos.org", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("whycouldibeatmiketyson.org", new string[]
        {
            "Memes"
        }));
        urls.Add(new DomainInfo("howtomakevideogamerips.org", new string[]
        {
            "Video Games"
        }));
        urls.Add(new DomainInfo("clickthistobeabigshot.com", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("kaloconservation.org", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("apocalypsemailteam.org", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("cupcakewalkaudiotutorials.com", new string[]
        {
            "None"
        }));
        urls.Add(new DomainInfo("ytplumbing.org", new string[]
        {
            "Memes"
        }));
        urls.Add(new DomainInfo("mildredsknittingclass.com", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("truthseeker69.gov", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("thevoidisnear.com", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("wesendyoumoney.org", new string[]
        {
            "Scams"
        }));
        urls.Add(new DomainInfo("theelderrollsbakery.org", new string[]
        {
            "Business"
        }));
        urls.Add(new DomainInfo("unclebewilderment.com", new string[]
        {
            "Conspiracy"
        }));
        urls.Add(new DomainInfo("karmakmusic.com", new string[]
        {
            "MTV"
        }));
        urls.Add(new DomainInfo("learningmadefun.org", new string[]
        {
            "Education"
        }));
        urls.Add(new DomainInfo("123rat.org", new string[]
        {
            "Education"
        }));
        urls.Add(new DomainInfo("brainpoop.com", new string[]
        {
            "Education"
        }));
        urls.Add(new DomainInfo("nothingisreal.org", new string[]
        {
            "Conspiracy"
        }));

        foreach (DomainInfo var in urls)
        {
            string piece = "";
            int randomIdPiece;

            for (int i = 0; i < 9; i++)
            {
                randomIdPiece = UnityEngine.Random.Range(0, 9);
                piece += randomIdPiece.ToString();
            }

            urlIdPairs.Add(piece, var);
        }

        foreach (string t in urlIdPairs.Keys)
        {
            Debug.Log(t);
        }

    }
}
