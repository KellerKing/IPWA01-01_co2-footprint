//Pfad zur Sqlite Datenbank. Tabellen sind bereits erstellet.
using IPWA01_01.Backend.DataAccess;
using IPWA01_01.Backend.DataAccess.Contracts.Contracts;

var databaseController = Bootstrapper.CreateDatabaseAccessControllerSqlite(new DatabaseConfiguration
{
    Location = @"D:\Studium\IPWA01-01_Programmierung_von_Webanwendungsoberflaechen\Backend\IPWA01_01.Backend\Datenbank\Co2Daten.db"
});

var daten = GetDaten().ToList();

ClearDatabase();
FillLand(daten);
FillUnternehmen(daten);
FillCo2Verbrauch(daten);


IEnumerable<Datenklasse> GetDaten()
{
    var jsonFile = File.ReadAllText("D:\\Studium\\IPWA01-01_Programmierung_von_Webanwendungsoberflaechen\\Backend\\IPWA01_01.Backend\\Datenbank\\quelle.json");
    var daten = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Datenklasse>>(jsonFile);
    return daten;

}

void ClearDatabase()
{
    databaseController.TruncateDatabase();
}

void FillLand(List<Datenklasse> daten)
{
    var distinctLaender = daten.Select(x => x.Land).Distinct().ToList();
    
    foreach (var d in distinctLaender)
    {
        databaseController.InsertLand(d);
    }
}

void FillUnternehmen(List<Datenklasse> daten)
{
    var distinctUnternehmen = daten.GroupBy(x => x.Unternehmen);
    var dtos = distinctUnternehmen.Select(x => new { Name = x.First().Unternehmen, x.First().Branche });
    foreach (var d in dtos)
    {
        databaseController.InsertUnternehmen(d.Name, d.Branche);
    }
}


void FillCo2Verbrauch(List<Datenklasse> daten)
{
    foreach (var d in daten)
    {
        var unternehmen = databaseController.GetUnternehmenByName(d.Unternehmen);
        var land = databaseController.GetLandByName(d.Land);

        databaseController.InsertCo2Verbrauch(land.Id, unternehmen.Id, d.Co2InTonnen);
    }
}


class Datenklasse
{
    public string Unternehmen { get; set; }
    public string Land { get; set; }
    public string Branche { get; set; }
    public double Co2InTonnen { get; set; }

}