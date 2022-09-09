using System.Globalization;

namespace Internhub.Models.Static
{

    /// <summary>
    /// Culture info Interface
    /// </summary>
    public interface ICountry
    {

        List<string> CountryNames();
       
    }
    
    public class Country : ICountry
    {
        public List<string> CountryNames()
        {
            //Creating List
            List<string> CultureList = new List<string>();
            //getting the specific culture information from CultureInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo cultureInfo in getCultureInfo)
            {
                //creating the object of regionInfo class
                RegionInfo getRegionInfo = new RegionInfo(cultureInfo.LCID);
                //adding each country name into array list
                if (!CultureList.Contains(getRegionInfo.EnglishName))
                {
                    CultureList.Add(getRegionInfo.EnglishName);
                }
            }
            //sorting array
            CultureList.Sort();
            //returning country list
            return CultureList;
        }
    }
}
