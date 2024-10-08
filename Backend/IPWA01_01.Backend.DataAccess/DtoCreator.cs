using IPWA01_01.Backend.DataAccess.Contracts.Contracts;
using IPWA01_01.Backend.DataAccess.Model;

namespace IPWA01_01.Backend.DataAccess
{
    class DtoCreator
    {
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
