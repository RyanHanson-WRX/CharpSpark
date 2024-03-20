## Final for CS 461 ~ Ryan Hanson ##
- UML Source Code:
```
    @startuml
    participant "**Client Browser**" as CB
    box "ASP.NET Core Server\nhttp://localhost:5xxx" #LightBlue
    participant "**Web Scraper API Controller**\n/api/joblistings/" as WSAC
    participant "**Web Scraper Service**" as WSS
    end box
    box "Web Scraper Micro Service" #LightGreen
    participant "**Flask API Endpoints**" as F
    participant "**Mongo DB**" as MDB
    participant "**Scraper (BS4/Selenium)**" as S
    end box
    participant "**Internet**" as I


    Note Left of CB: Workflow for cached Web Scraper processes
    S <-> I: Continuous Scraping of Job Postings 
    S -> MDB: Cache Scraped Info
    CB -> WSAC: GET Job Listings
    WSAC -> WSS: Invoke Service
    WSS -> F: GET Cached Job Listings
    F -> MDB: Query Cached Data
    MDB -> F: Send Cached Data
    F -> WSS: 200 (OK) / Job Listings
    WSS -> WSAC: JSON Job Listings
    WSAC -> CB: 200 (OK) / Job Listings

    Note Left of CB: Workflow for Advanced Search
    CB -> WSAC: GET Job Listings + Parameters
    WSAC -> WSS: Invoke Service
    WSS -> F: GET Job Listings + Parameters
    F -> S: Parameters
    S -> I: GET Job Listing Site w/ Given Parameters
    I -> S: 200 (OK) / HTML Content
    S -> S: Scrape HTML
    S -> F: Send Scraped Data as JSON
    F -> WSS: 200 (OK) / Job Listings
    WSS -> WSAC: JSON Job Listings
    WSAC -> CB: 200 (OK) / Job Listings

    @enduml
```

- UML [PNG](/TeamDocuments/RyanHanson_Final/CHARP186_PlantUML.png)

- Web Scraper [Test Stub](/TeamDocuments/RyanHanson_Final/test_scraper.py)