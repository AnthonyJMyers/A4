using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueLoginRegistrationService" in code, svc and config file together.
public class VenueLoginRegistrationService : IVenueLoginRegistrationService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public bool RegisterVenue(Venue v, VenueLogin vl)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetKeyCode();
            byte[] hashed = ph.HashIt(vl.VenueLoginPasswordPlain, code.ToString());

            Venue ven = new Venue();
            ven.VenueName = v.VenueName;
            ven.VenueEmail = v.VenueEmail;
            ven.VenueAddress = v.VenueAddress;
            ven.VenueAgeRestriction = v.VenueAgeRestriction;
            ven.VenueCity = v.VenueCity;
            ven.VenueDateAdded = DateTime.Now;
            ven.VenuePhone = v.VenuePhone;
            ven.VenueState = v.VenueState;
            ven.VenueWebPage = v.VenueWebPage;
            ven.VenueZipCode = v.VenueZipCode;
            ven.VenueLogins = v.VenueLogins;
            ven.VenueKey = v.VenueKey;

          

            VenueLogin venl = new VenueLogin();
            venl.Venue = ven;
            venl.VenueLoginDateAdded = DateTime.Now;
            venl.VenueLoginHashed = hashed;
            venl.VenueLoginKey = code;
            venl.VenueLoginPasswordPlain = vl.VenueLoginPasswordPlain;
            venl.VenueLoginUserName = vl.VenueLoginUserName;
            venl.VenueLoginRandom = vl.VenueLoginRandom;
            venl.VenueKey = vl.VenueKey;

            db.Venues.Add(ven);
            db.VenueLogins.Add(venl);
            db.SaveChanges();

            }
        catch
        {
            result = false;
        }
        return result;
    }

    public int VenueLogin(string userName, string Password)
    {
        int id = 0;

        LoginClass lc = new LoginClass(Password, userName);
        id = lc.ValidateLogin();

        return id;
    }
}
