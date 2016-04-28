using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShowTrackerService" in code, svc and config file together.
public class ShowTrackerService : IShowTrackerService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<string> GetArtists()
    {
        var arts = from a in ste.Artists
                      orderby a.ArtistName
                      select new { a.ArtistName };
        List<string> artists = new List<string>();
        foreach(var i in arts)
        {
            artists.Add(i.ArtistName.ToString());
        }

        return artists;
    }

    public List<Performance> GetArtistShows(string artist)
    {
        var artshows = from s in ste.Shows
                       from sd in s.ShowDetails
                       where sd.Artist.ArtistName.Equals(artist)
                       select new { s.Venue.VenueName, s.ShowName, s.ShowDate, s.ShowTime };

        List<Performance> performlist = new List<Performance>();
        foreach(var sh in artshows)
        {
            Performance newshow = new Performance();
            newshow.ShowDate = sh.ShowDate.ToString();
            newshow.ShowName = sh.ShowName;
            newshow.ShowStartTime = sh.ShowTime.ToString();
            newshow.ShowVenue = sh.VenueName;
            performlist.Add(newshow);
        }

        return performlist;
    }

    public List<string> GetShows()
    {
        var shws = from sh in ste.Shows
                   orderby sh.ShowName
                   select new { sh.ShowName };
        List<string> shows = new List<string>();
        foreach(var s in shws)
        {
            shows.Add(s.ShowName);
        }
        return shows;
    }

    public List<string> GetVenues()
    {
        var venues = from v in ste.Venues
                     orderby v.VenueName
                     select new { v.VenueName };
        List<string> venuelist = new List<string>();
        foreach(var ven in venues)
        {
            venuelist.Add(ven.VenueName);
        }
        return venuelist;
    }

    public List<Performance> GetVenueShows(string venue)
    {
        var venshows = from v in ste.Venues
                       from s in v.Shows
                       where s.Venue.VenueName.Equals(venue)
                       select new
                       {
                           s.ShowName,
                           s.ShowDate,
                           s.ShowTime,
                           v.VenueName
                       };
        List<Performance> venshowlist = new List<Performance>();
        foreach(var vs in venshows)
        {
            var newvs = new Performance();
            newvs.ShowName = vs.ShowName;
            newvs.ShowDate = vs.ShowDate.ToShortDateString();
            newvs.ShowStartTime = vs.ShowTime.ToString();
            newvs.ShowVenue = vs.VenueName;
            venshowlist.Add(newvs);
        }
        return venshowlist;

    }
}
