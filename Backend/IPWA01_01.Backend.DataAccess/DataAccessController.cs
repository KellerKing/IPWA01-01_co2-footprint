﻿using IPWA01_01.Backend.DataAccess.Contracts;
using IPWA01_01.Backend.DataAccess.Interface;

namespace IPWA01_01.Backend.DataAccess
{
    internal class DataAccessController : IDataAccessController
    {
        private readonly IDatabaseConnection m_DatabaseConnection;

        public DataAccessController(IDatabaseConnection datbaseConnection) { m_DatabaseConnection = datbaseConnection; }

        public IEnumerable<Co2VerbrauchDto> GetCo2VerbauchGefiltert(string filterLand, string filterUnternehmen)
        {
            throw new NotImplementedException();
        }

        //https://stackoverflow.com/questions/68980778/config-connection-string-in-net-core-6
        //https://pmichaels.net/2021/11/28/dependency-injection-in-minimal-apis-in-net-6/
        public IEnumerable<Co2VerbrauchDto> GetCo2Verbrauch()
        {
            var models = m_DatabaseConnection.GetCo2Verbrauch();
            var result = models.Select(x => DtoCreator.CreateCo2VerbrauchDto(x)).ToList();
            return result;
        }

        public LandDto GetLandByName(string name)
        {
            var modelInput = ModelCreator.CreateLandModel(-1, name);
            var modelOutput = m_DatabaseConnection.GetLand(modelInput).DefaultIfEmpty(new Model.LandModel()).First();
            var result = DtoCreator.CreateLandDto(modelOutput);

            return result;

        }

        public UnternehmenDto GetUnternehmenByName(string name)
        {
            var modelInput = ModelCreator.CreateUnternehmenModel(-1, name, string.Empty);
            var modelOutput = m_DatabaseConnection.GetUnternehmen(modelInput).DefaultIfEmpty(new Model.UnternehmenModel()).First();
            var result = DtoCreator.CreateUnternehmenDto(modelOutput);

            return result;
        }

        public bool InsertCo2Verbrauch(int landId, int unternehmenId, double co2Verbrauch)
        {
            var model = ModelCreator.CreateCo2Model(-1,  landId, unternehmenId, co2Verbrauch);
            return m_DatabaseConnection.InsertCo2Verbrauch(model);
        }

        public bool InsertLand(string name)
        {
            var model = ModelCreator.CreateLandModel(-1, name);
            return m_DatabaseConnection.InsertLand(model);
        }

        public bool InsertUnternehmen(string name, string branche)
        {
            var model = ModelCreator.CreateUnternehmenModel(-1, name, branche);
            return m_DatabaseConnection.InsertUnternehmen(model);
        }

        public void TruncateDatabase()
        {
            m_DatabaseConnection.TruncateDatabase();
        }
    }
}
