namespace IPWA01_01.Backend.DataAccess.Contracts
{
    public class Co2VerbrauchDto
    {
        public int Id { get; set; }
        public double Co2Verbauch { get; set; }
        public string Land { get; set; }
        public string Branche { get; set; }
        public string Unternehmen { get; set; }
    }
}
