# Cinema Example für Kino (stark vereinfacht)

## Features

Barebone Template für Projekt Kino mit nur 4 Model-Klassen, 4 DB-Tabellen, keiner Userverwaltung und keinem UserLogin.

- Einfache Auflistung von KalenderElementen mit Kinofilmen aus der Datenbank
- Hinzufügen eines Elements auf den Einkaufskorb
- Anzeigen des Einkaufskorbes

## Prerequirements

- Anlegen der Datenbank auf Localhost MySQL
- SQL-Files zum Anlegen unter /Database
- In den Tables movies, calelements und user Beispieldaten anlegen (zB 3 Filme, 6 Termine für die Filme, 1 User). Es müssen manuell ein paar Initialdatensätze angelegt werden.
- Im Visual Studio die Projektmappe neu erstellen (bereinigen, erstellen)

## Versionen

- Verwendet wurde das Visual Studio 2017 Community (2019 sollte also auch funktionieren)
- Microsoft SQL Server Express 2017

## Data

Keine EF-Migrations verwendet. Für Infos, siehe Ordner /Database