namespace IPWA01_01.Backend.DataAccess.Contracts
{
    public interface IDataAccessController
    {
        IEnumerable<Co2VerbrauchDto> GetCo2Verbrauch();
        IEnumerable<Co2VerbrauchDto> GetCo2VerbauchGefiltert(string filterLand, string filterUnternehmen);
        LandDto GetLandByName(string name);
        UnternehmenDto GetUnternehmenByName(string name);

        bool InsertLand(string name);
        bool InsertUnternehmen(string name, string branche);
        bool InsertCo2Verbrauch(int landId, int unternehmenId, double co2Verbrauch);

        void TruncateDatabase();
    }
}
