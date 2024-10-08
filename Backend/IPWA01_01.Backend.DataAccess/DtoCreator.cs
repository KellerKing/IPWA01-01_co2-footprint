using IPWA01_01.Backend.DataAccess.Contracts;
using IPWA01_01.Backend.DataAccess.Model;

namespace IPWA01_01.Backend.DataAccess
{
    class DtoCreator
    {
        internal static Co2VerbrauchDto CreateCo2VerbrauchDto(Co2VerbrauchModel model)
        {
            return new Co2VerbrauchDto
            {
                Id = model.Id,
                Branche = model.Branche,
                Co2Verbauch = model.Co2Verbrauch,
                Land = model.Land,
                Unternehmen = model.Unternehmen
            };
        }

        internal static LandDto CreateLandDto(LandModel model)
        {
            return new LandDto
            {
                Name = model.Name,
                Id = model.Id,
            };
        }

        internal static UnternehmenDto CreateUnternehmenDto(UnternehmenModel model)
        {
            return new UnternehmenDto
            {
                Id = model.Id,
                Name = model.Name,
                Branche = model.Branche
            };
        }
    }
}
