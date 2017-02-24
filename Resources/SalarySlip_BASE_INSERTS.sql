begin;
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Dane podstawowe');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Godziny');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Dni');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Wynag. OFP');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Potr¹cenia');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Podstawy podatkowe');
insert into SL_GRUPY_TYPOW_POL_PP(NAZWA) VALUES ('Sk³adki');

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'NR','Numer prac.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PR','Pracownik',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'WY','Wydzia³',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PZ','P³aca zasadnicza',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'MK','Miesi¹c kosztu',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'RK','Rok kosztu',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'ZM','ZUS Miesi¹c kosztu',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'ZR','ZUS Rok kosztu',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dane podstawowe';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'GP','Godziny pracy',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Godziny';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'DP','Dni pracy',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Dni';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'RP','Premia regulaminowa',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Wynag. OFP';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UE','Ubezp. emer.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UR','Ubezp. rent.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UC','Ubezp. chor.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'ZD','Zal. Doch.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'SO','Skl. zd. odl.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'SN','Skl. zdr. nie.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UG','Ubezpieczenie grupowe',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Potr¹cenia';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PP','Podst. podatku',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PE','Podst. ubez. em. i rent',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'KU','Koszty uzyskania',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PC','Podst. ubez. chorob',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UP','Ulga w podatku',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'UW','Podst. ubez. wypad',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PO','Procent. podatku',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'PU','Podst. ubez. zdrow.',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Podstawy podatkowe';

insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'EM','Emerytalna',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Sk³adki';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'RE','Rentowa',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Sk³adki';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'WD','Wypadkowa',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Sk³adki';
insert into SL_TYPOW_POL_PP(KOD,NAZWA,UNIKALNY,ID_GRUPY) select 'SZ','Sk³¹dka zdrowotna',1,ID_GRUPY from SL_GRUPY_TYPOW_POL_PP where nazwa='Sk³adki';
end;