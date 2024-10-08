using IPWA01_01.Backend.DataAccess.Model;

namespace IPWA01_01.Backend.DataAccess.Interface
{
    internal interface IDatabaseConnection
    {
        IEnumerable<Co2VerbrauchModel> GetCo2Verbrauch();
        IEnumerable<Co2VerbrauchModel> GetCo2VerbauchGefiltert(string filterLand, string filterUnternehmen);
        IEnumerable<LandModel> GetLand(LandModel land);
        IEnumerable<UnternehmenModel> GetUnternehmen(UnternehmenModel unternehmen);

        bool InsertLand(LandModel land);
        bool InsertUnternehmen(UnternehmenModel unternehmen);
        bool InsertCo2Verbrauch(Co2VerbrauchModel co2Verbrauch);

        void TruncateDatabase();
    }
}
