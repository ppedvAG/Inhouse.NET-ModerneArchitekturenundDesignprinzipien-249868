# Moderne Architekturen und Designprinzipien
Kurs Repository zu Kurs .NET - Moderne Architekturen und Designprinzipien der ppedv AG

## M001 | Was Architektur ist

- [x] Ebenenmodell & Struktur
- [x] Aspekte, Richtlinien, Analyse
- [x] 3P-Regel: Product, Process, People
- [x] Funktional vs. Nicht-Funktional
- [x] Kosten und Technische Schulden

## M002 | Architekturüberblick

- [x] Cargo Cult Programming
- [x] Überblick verschiedener Architekturen
- [ ] Beispiel Clean-Architecture "Todo List"

```bash
dotnet new install Clean.Architecture.Solution.Template
```

## M003 | Design Patterns

- [x] Relevanz und Entwicklung der Muster
- [x] Creational Patterns: Wie werden Objekte erzeugt?
  *  FactoryMethod als PizzaShop
  *  BuilderPattern als PizzaConfigurator
- [x] Structural Patterns: Wie werden Objekte verbunden und integriert?
  *  Decorator: Pizza schneiden und verpacken
  *  Adapter: Pfannen-Pizza als "normale" Pizza bestellen
- [x] Behavioral Patterns: Wie verhalten sich Objekte und Objektstrukturen?
  *  Strategy: Pizza mit einem Fahrzeug ausliefern
- [x] Lab Payment-Service

## M004 | Design Principles

- [x] Prinzipien und Code-Smells
- [x] SOLID Bewertung
- [x] Säulen der OOP, Kohäsion und Kopplung
- [x] Beispiele zu ISP und DIP
- [x] Lab Artikel: Ist Architektur überbewertet?

## M005 | Event Sourcing

- [x] Domain Driven Design
- [x] Datenpersistenz
- [x] Beispiel Student Course
- [x] Lab Bankkonto

## M006 | WebAPI mit CQRS

- [ ] Repository Pattern
- [ ] Mediator Pattern
- [ ] Service API
- [ ] Beispiel Auftragsverwaltung
- [ ] Lab Bankkonto API

## M007 | Business Anwendung

- [x] Eigene Geschäftsanwendung entwerfen
- [x] Klassendiagramm erstellen mit draw.io
- [x] Domänen-modell generieren lassen
- [x] Testdatenbank mit Entity Framework
- [x] [Überblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
- [x] Testdaten generieren lassen
- [x] Geschäftslogik implementieren
- [x] WebAPI erstellen
- [ ] Weitere Front-Ends erstellen