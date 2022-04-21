using System;

namespace StoreApp.Logic
{ 
public class Location
    {
        public  int locationId;
        public string locationName;
      
        public  string detail;


        public Location()
        { }

        public Location(int LocationId, string LocationName, string Detail)
        {
            this.locationId = LocationId;
            this.locationName = LocationName;
            this.detail = Detail;
        }

        public int getLocationId()
        {
            return this.locationId;
        }
        public string getLocationName()
        {
            return this.locationName;
        }
        public string getDetail()
        {
            return this.detail;
        }
        public void setLocationId(int LocationId)
        {
            this.locationId = LocationId;
        }
        public void setLocationName(string LocationName)
        {
            this.locationName = LocationName;
        }
        public void setDetail(string Detail)
        {
            this.detail = Detail;
        }

    }
}