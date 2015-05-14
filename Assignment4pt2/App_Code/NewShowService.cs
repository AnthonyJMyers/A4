using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewShowService" in code, svc and config file together.
public class NewShowService : INewShowService
{

    ShowTrackerEntities db = new ShowTrackerEntities();

    public bool AddArtist(Artist a)
    {
        bool result = true;
        try
        {
            Artist ar = new Artist();
            ar.ArtistName = a.ArtistName;
            db.Artists.Add(ar);
            db.SaveChanges();
        }
        catch{
            result = false;
        }
        return result;
    }

    public bool AddShow(Show s, ShowDetail sd)
    {
        bool result = true;
        try
        {
            Show shw = new Show();
            shw.ShowName = s.ShowName;
            shw.ShowDate = s.ShowDate;
            shw.ShowDateEntered = DateTime.Now;
            shw.ShowDetails = s.ShowDetails;
            shw.ShowKey = s.ShowKey;
            shw.ShowTicketInfo = s.ShowTicketInfo;
            shw.ShowTime = s.ShowTime;
            shw.VenueKey = s.VenueKey;

            ShowDetail shwd = new ShowDetail();
            shwd.Artist = sd.Artist;
            shwd.ArtistKey = sd.ArtistKey;
            shwd.Show = shw;
            shwd.ShowDetailAdditional = sd.ShowDetailAdditional;
            shwd.ShowDetailArtistStartTime = sd.ShowDetailArtistStartTime;
            shwd.ShowDetailKey = sd.ShowDetailKey;
            shwd.ShowKey = sd.ShowKey;

            db.Shows.Add(shw);
            db.ShowDetails.Add(shwd);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public List<Artist> GetArtists()
    {
        var tls = from b in db.Artists
                  orderby b.ArtistName
                  select b;

        List<Artist> titles = new List<Artist>();
        foreach (var t in tls)
        {
            Artist b = new Artist();
            b.ArtistName = t.ArtistName;
            b.ArtistEmail = t.ArtistEmail;
            b.ArtistKey = t.ArtistKey;
            b.ArtistWebPage = t.ArtistWebPage;
            b.ShowDetails = t.ShowDetails;
            b.ArtistDateEntered = b.ArtistDateEntered;
            titles.Add(b);
        }
        return titles;
    }
}
