# Projektbeschreibung

Das ist das Backend des Projektes IPWA01-01. Es enthält eine Sqlite Datenbank bestehend aus drei Tabellen. Der Kern der Solution ist IPWA01_01.Backend. In der Programm.cs sind alle Endpunkte definiert. Es wurde mit minimal API erstellt. Standardmäßig läuft das Projekt auf Port 5001. 
Für den Port 5173, auf dem die Webanwendung läuft wurde eine CORS ausnahme eingetragen, damit vom localhost auch der Webservice aufgerufen werden kann. 


# Aufbau

In der Projektmappe befinden sich insgesamt vier Projekte.

- IPWA01_01.Backend: Das ist der eigentliche Webservice. Über ihn wird auf die Sqlite Datenbank aus der Webseite heraus zugegriffen.

- IPWA01_01.Backend.DataAccess.Contracts: Hier sind die Contracts für den DataAccess definiert. Die Backendlogik kennt nur die Dtos und Interfaces aus dem Projekt. Dadurch ist eine lose kopplung gewährleistet.

- IPWA01_01.Backend.DataAccess: Das ist der eigentliche Datenbankzugriff auf die Sqlite Datenbank. Sie wird von IPWA01_01.Backend bereitgestellt. Aktuell können nur Sqlite Datenbanken verarbeitet werden, da nicht auch nicht mehr benötigt wird.

- IPWA01-01.Datenbankbewirtschaftung: Das ist ein Tool welches benutzt wird um die Datenbank zu befüllen. Sie wird zuerst geleert und dann befüllt. Zu beginn des Projekts war die Datenhaltung mit einer Json realisiert. Diese wird weiterhin als Datenquelle benutzt. Im Projekt IPWA01_01.Backend gibt es den Ordner "Datenbank". Dort ist die quelle.json vorhanden. Daraus werden die drei Tabellen befüllt. Das Tool wird nur bedarfsweise ausgeführt. 

# Verwendung für Entwickler

## Voraussetzungen

1. Es muss .Net 8 auf dem Pc installiert sein oder Visual Studio 2022 mit dem ASP.Net und Webentwicklung Workload.
2. Der Port 5001 sollte nicht bereits belegt sein.
3. Wenn das Frontend genutzt werden soll, dann muss Port 5173 frei sein.


## Starten des Service

1. Git repository runterladen
2. CLI öffnen
3. In das Verzeichnis des Backends navigieren: ...\Backend\IPWA01_01.Backend
4. Prüfen, dass der Port 5001 frei ist (wenn das Frontend genutzt werden soll)
5. Den Befehl dotnet run eingeben. Alternativ wenn ein anderer Port genutzt werden soll dann: dotnet run --urls=http://localhost:5001/ 
Quelle: https://stackoverflow.com/questions/37365277/how-to-specify-the-port-an-asp-net-core-application-is-hosted-on 

## Debuggen der Enpunkte

Zum debuggen kann die Solution in Visual Studio 2022 geöffnet werden. Es müssen die voraussetzungen von oben erfüllt sein. Das Backendprojekt muss als Startprojekt ausgewählt werden. Das Projekt wird dann einfach gestartet. Es öffnet sich ein Browser, der nichts anzeigt. Wenn an die Url ein "/swagger" ergänzt wird, erscheint eine Oberfläche mit der die Endpunkte getestet werden können.