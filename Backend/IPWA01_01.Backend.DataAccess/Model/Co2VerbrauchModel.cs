namespace IPWA01_01.Backend.DataAccess.Model
{
    public class Co2VerbrauchModel
    {
        public int Id { get; set; }
        public int UnternehmenId { get; set; }
        public int LandId { get; set; }
        public double Co2Verbrauch { get; set; }
    }
}
