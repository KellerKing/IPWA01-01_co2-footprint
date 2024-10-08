using IPWA01_01.Backend.DataAccess.Model;

namespace IPWA01_01.Backend.DataAccess
{
    class ModelCreator
    {
        public static LandModel CreateLandModel(int id, string name)
        {
            return new LandModel
            {
                Id = id,
                Name = name,
            };
        }

        internal static Co2VerbrauchModel CreateCo2Model(int id, int landId, int unternehmenId, double co2Verbrauch)
        {
            return new Co2VerbrauchModel
            {
                Co2Verbrauch = co2Verbrauch,
                Id = id,
                LandId = landId,
                UnternehmenId = unternehmenId,
            };
        }

        internal static UnternehmenModel CreateUnternehmenModel(int id, string name, string branche)
        {
            return new UnternehmenModel 
            {
                Id = id,
                Name = name,
                Branche = branche
            };
        }
    }
}
