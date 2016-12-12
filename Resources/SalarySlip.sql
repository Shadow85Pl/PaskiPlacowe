PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [SL_TYPOW_POL_PP] (
    [ID_TYPU_POLA] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [KOD] varchar(2) NOT NULL UNIQUE,
    [NAZWA] varchar(50) NOT NULL,
    [UNIKALNY] bit NOT NULL DEFAULT False
);
CREATE TABLE [PaskiPlacowe] (
    [ID_PASKA] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [NAZWA] varchar(50) NOT NULL,
    [ID_UZYTKOWNIKA] integer NOT NULL,
    [PLIK] blob,
    CONSTRAINT [FK_PaskiPlacowe_-1_-1] FOREIGN KEY ([ID_UZYTKOWNIKA]) REFERENCES [Uzytkownicy] ([ID_UZYTKOWNIKA])
);
CREATE TABLE [PaskiPlacowe_POZ] (
    [ID_PASEK_PLACOWY_POZ] integer PRIMARY KEY NOT NULL,
    [ID_TYPU_POLA] integer NOT NULL,
    [ID_PASKA] integer NOT NULL,
    [WARTOSC] varchar(8000) NOT NULL,
    CONSTRAINT [FK_PaskiPlacowe_POZ_0_0] FOREIGN KEY ([ID_TYPU_POLA]) REFERENCES [SL_TYPOW_POL_PP] ([ID_TYPU_POLA]) MATCH NONE ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT [FK_PaskiPlacowe_POZ_-1_-1] FOREIGN KEY ([ID_PASKA]) REFERENCES [PaskiPlacowe] ([ID_PASKA])
);
CREATE TABLE [Uzytkownicy] (
    [ID_UZYTKOWNIKA] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [NAZWA] varchar(50) NOT NULL,
    [LOGIN] varchar(50) NOT NULL UNIQUE,
    [HASLO] varbinary(64)
);
DELETE FROM sqlite_sequence;
INSERT INTO "sqlite_sequence" VALUES('SL_TYPOW_POL_PP',0);
INSERT INTO "sqlite_sequence" VALUES('PaskiPlacowe',0);
INSERT INTO "sqlite_sequence" VALUES('Uzytkownicy',0);
COMMIT;
