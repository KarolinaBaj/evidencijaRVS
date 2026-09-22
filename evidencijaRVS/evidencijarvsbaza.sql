Create database evidencijarvs

create table korisnik(
korisnik_id int identity(1,1) primary key,
ime nvarchar(100) not null,
prezime nvarchar(100) not null,
lozinka nvarchar(255) not null,
email nvarchar(255) not null,
adresa nvarchar(100) not null,

)

create table zivotinja(
zivotinja_id int identity(1,1) primary key,
korisnik_id int,
ime nvarchar(50) not null, 
vrsta nvarchar(100) not null,
starost int not null,
Pol nvarchar(15) not null,
status nvarchar(50) null,
namena nvarchar(50) not null


)

alter table zivotinja
add constraint fk_korisnikid foreign key(korisnik_id)
references korisnik (korisnik_id)

create table anamneza(
anamneza_id int identity(1,1) primary key,
zivotinja_id int,
Razlogdolaska nvarchar(MAX) not null,
ishrana nvarchar(MAX) not null,
Urinistolica nvarchar(MAX) not null,
Smestaj Nvarchar(Max) not null,
Primaolekove bit not null,
kojelekove nvarchar(max) null,
ranijebolovala nvarchar(max) not null,
datumunosa datetime not null
)

alter table anamneza
add constraint fk_zivotinjinanamneza foreign key(zivotinja_id)
references zivotinja(zivotinja_id)

create table pregled(
pregled_id int identity(1,1) primary key,
anamneza_id int,
telesna_temperatura decimal(4,1) not null,
dijagnoza nvarchar(MAX) not null,
terapija NVarchar(max) not null,
hitanslucaj bit not null,
prioritetpregleda nvarchar(50) not null,
datumpregleda datetime not null
)

alter table pregled
add constraint fk_anamnezapregleda foreign key(anamneza_id)
references anamneza(anamneza_id)

create table lek(
lek_id int identity(1,1) primary key,
nazivleka nvarchar(100) not null,
opis nvarchar(max) not null,
doza nvarchar(50) not null

)

create table terapija(
terapija_id int identity(1,1) primary key,
pregled_id int,
lek_id int,
kolicina nvarchar(50) not null,
napomena nvarchar(max) not null

)

alter table terapija
add constraint fk_pregledterapija foreign key(pregled_id)
references pregled (pregled_id)

alter table terapija
add constraint fk_terapijalek foreign key(lek_id)
references lek (lek_id)