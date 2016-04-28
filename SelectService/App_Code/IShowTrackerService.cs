using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShowTrackerService" in both code and config file together.
[ServiceContract]
public interface IShowTrackerService
{
    [OperationContract]
    List<string> GetVenues();

    [OperationContract]
    List<string> GetArtists();

    [OperationContract]
    List<string> GetShows();

    [OperationContract]
    List<Performance> GetVenueShows(string venue);

    [OperationContract]
    List<Performance> GetArtistShows(string artist);
}

[DataContract]
public class Performance
{
    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ShowStartTime { set; get; }

    [DataMember]
    public string ShowVenue { set; get; }
}
