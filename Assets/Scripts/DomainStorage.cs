using System;
using System.Collections.Generic;
using UnityEngine;

public static class DomainStorage
{
    private static Dictionary<string, DomainInfo> urlIdPairs = new Dictionary<string, DomainInfo>();
    private static List<DomainInfo> urls = new List<DomainInfo>();
    private static List<string> trends;

    public struct DomainInfo
    {
        public string[] trends;
        public string url;

        public DomainInfo(string url, string[] trends)
        {
            this.url = url;
            this.trends = trends;
        }
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

    public static void BuildUrlPacks()
    {
        urlIdPairs.Clear();
        urls.Clear();

        trends = new List<string>();
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

        urls.Add(new DomainInfo("jackfrosttips.com", new string[]
        {
            "Pop Culture"
        }));
        urls.Add(new DomainInfo("yoyoallday.com", new string[]
        {
        
        }));
        urls.Add(new DomainInfo("mtvismylife.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("pokerman4gamegirl.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("mtvmusicdotcom.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("yoyoallday.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("mtvmusicdotcom.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("ilovenysnc.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("how2fixflipphone.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("lowriderjeans4sale.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("80sbabies4lyfe.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("buyJNCOSnow.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("mytomagotchidied.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("thosecupswithblueandpurplescribbles.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("skateboards4posers.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("cheapsnapbraclets.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("ilovebeaniebabies.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("coolplasticonastring.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("coolsciencegames.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("fredsflops.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("lemonwire.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("trackys4hire.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("ilooklikebillclinton.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("money4beaniebabiesNOW.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("notaurldotcom.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("blockbustersbutonline.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("downloadmoreram.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("mynameisjeff.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("crabsthattap.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("mycouchisonfire.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("themoonischeese.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("donutearththeoryconfirmed.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("transquilbeats2sleep2.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("trillionawesomegames.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("picturesofdogswithhats.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("back2thefuturefanclub.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("Swashbucklersbay.yar", new string[]
        {

        }));
        urls.Add(new DomainInfo("notavirus.exe", new string[]
        {

        }));
        urls.Add(new DomainInfo("dropshippingbeforeitwascool.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("hairspraydealer.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("iwannabeayoyoman.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("keeponyoing.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("yoyotricks4begineers.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("Worldwideweb.scam", new string[]
        {

        }));
        urls.Add(new DomainInfo("freethings.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("webaholics.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("peanutbutterandspacejam.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("leocities.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("audioforu.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("mycoolassstuffandthings.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("catsandthebigbang.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("frogdementia.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("blackbeardscrew.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("tracksuitdad.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("onlydads.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("paradisekoolio.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("buyrobotbirds.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("iwillkillyourfamilyunlessyoubuythis.biz", new string[]
        {

        }));
        urls.Add(new DomainInfo("silenceofthescams.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("downloadmoviesfree.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("gameboytutorials.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("noboysallowed.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("schmoogle.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("wonkipedia.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("bookface.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("bigshotautos.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("whycouldibeatmiketyson.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("howtomakevideogamerips.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("clickthistobeabigshot.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("kaloconservation.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("apocalypsemailteam.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("cupcakewalkaudiotutorials.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("ytplumbing.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("mildredsknittingclass.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("truthseeker69.gov", new string[]
        {

        }));
        urls.Add(new DomainInfo("thevoidisnear.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("wesendyoumoney.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("theelderrollsbakery.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("unclebewilderment.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("karmakmusic.com", new string[]
        {

        }));
        urls.Add(new DomainInfo("learningmadefun.org", new string[]
        {

        }));
        urls.Add(new DomainInfo("123rat.org", new string[]
        {

        }));


        foreach (DomainInfo var in urls)
        {
            string piece = "";
            int randomIdPiece;

            for (int i = 0; i < 11; i++)
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
