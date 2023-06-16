create database bp_21015221045;

use bp_21015221045;

create table UCUS(
id int not null primary KEY ,
tarih date null,
kalkıs_yeri varchar(100) not null ,
varıs_yeri varchar(100) null,
personel_adı varchar(100) null

);
create table MÜSTERİLER(
id int not null primary KEY ,
ad varchar(50) null,
soyad varchar(50) null,
telefon varchar(16) null,
mail varchar(50),
cinsiyet char(5)        null,

constraint fk_id_MÜSTERİLER foreign key (id) references UCUS_BİLETİ(id)
			on delete cascade on update cascade
);
create table UCUS_BİLETİ(
id int not null primary KEY ,
fiyat int  null,
bilet_no int null,
koltuk_no int null,
tarih date null 

);
create table REZERVASYONLAR(
id int not null primary KEY ,
müsteri_ıd int  null,
koltuk_no int null,
ad_soyad varchar(100) null,
tarih date null,
constraint fk_id_REZERVASYONLAR foreign key (müsteri_ıd) references MÜSTERİLER(id)
			on delete cascade on update cascade
);

create table personeller(
id int not null primary KEY ,
adı varchar(50) null,
soyad varchar(50) null,
telefon varchar(16) null,
mail   varchar(50) null,

constraint fk_id_personeller foreign key (id) references UCUS(id)
			on delete cascade on update cascade


);
insert into  MÜSTERİLER(id,ad,soyad,telefon,mail,cinsiyet) values
 ('21','alper','yılmaz','05457855445','alper_y@gmail.com','erkek'),
 ('22','ali','şahin','05457982345','ali_sahin@gmai.com','erkek'),
 ('23','ismail','poyraz','05494378955','ismail_pyrz@gmail.com','erkek'),
 ('24','kadir','zeki','05327855432','kadir_z@gmail.com','erkek'),
 ('25','gamze','kayın','05457553241','gamze_kayın@gmail.com','kadın');
 
 
 insert into REZERVASYONLAR(id,müsteri_id,koltuk_no,ad_soyad,tarih)  values
        (012,null,'11','cevher kutlu','01.08.2022'),
        (030,null,'12','poyraz karayel','9.08.2022'),
        (021,null,'3','polat alemdar','8.08.2022'),
        (065,null,'18','kadir çakır','7.08.2022'),
        (081,null,'7','süleyman kayın','6.08.2022');
        
insert into  personeller(id,adı,soyad,telefon,mail)
values (501,'veli','çetin','05457855685','veli_çetin@gmail.com'),
       (502,'zeki','kılıç','05457942455','kılıç_zeki@gmail.com'),
	   (503,'ferhat','derin','05457753685','ferhat_derin@gmail.com'),
       (504,'cansel','dursun','05446018445','cansel_drsn@gmail.com'),
       (505,'aynur','gül','05457598445','gül_aynur@gmail.com');

insert into  UCUS(id,tarih,kalkıs_yeri,varıs_yeri,personel_adı)
values (2,'10.08.2022','istanbul','ankara','veli çetin'),
       (3,'08.08.2022','adana','kocaeli','zeki kılıç'),
       (8,'11.12.2022','antalya','ankara','ferhat derin '),
       (9,'08.07.2022','izmir','ankara','cansel dursun'),
       (7,'05.05.2022','şanlıurfa','istanbul','aynur gül');
       
       insert into  UCUS_BİLETİ(id,fiyat,bilet_no,koltuk_no,tarih)
values ('85','600','520','60','10.08.2022'),
       ('80','750','620','21','08.08.2022'),
       ('52','850','933','32','11.12.2022'),
       ('58','920','751','63','07.07.2022'),
       ('63','1200','330','34','05.05.2022');
       
UPDATE MÜSTERİLER
 SET 
 ad='ali'
 WHERE
 id ='7' ;
 
 call müsteriEkle(ad, soyad, tel, mail, cinsiyet);
 
DELIMITER //
CREATE PROCEDURE müsteriEkle(
 id int  ,
ad varchar(50) ,
soyad varchar(50) ,
telefon varchar(16) ,
mail varchar(100),
cinsiyet char(5)        
 )
BEGIN
 INSERT INTO MÜSTERİLER 
 VALUES(ad, soyad, tel, mail, cinsiyet);
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE müsteriGuncelle(
  id int  ,
ad varchar(50) ,
soyad varchar(50) ,
telefon varchar(16) ,
mail varchar(100),
cinsiyet char(5)   
)
BEGIN
 UPDATE MÜSTERİLER
 SET ad = ad, soyad=soyad, telefon=telfon,mail=mail, cinsiyet=cinsiyet
 WHERE id=id;
END //
DELIMITER ;

call müsteriGuncelle (7,'mehmet','zeki','05457855445','kadir_z@gmail.com','erkek')

DELIMITER //
CREATE PROCEDURE müsteriSilById(
 num int
)
BEGIN
 DELETE FROM MÜSTERİLER
 WHERE id=id;
END //
DELIMITER 

CALL müsteriSilById(7);

DELIMITER //
CREATE PROCEDURE listeMüsteriler()
BEGIN
 SELECT * 
 FROM MÜSTERİLER;
END //
DELIMITER ;

call listeMüsteriler();







insert into  MÜSTERİLER(id,ad,soyad,telefon,mail,cinsiyet) values  ('21','alper','yılmaz','05457855445','alper_y@gmail.com','erkek'),  ('22','ali','şahin','05457982345','ali_sahin@gmai.com','erkek'),  ('23','ismail','poyraz','05494378955','ismail_pyrz@gmail.com','erkek'),  ('24','kadir','zeki','05327855432','kadir_z@gmail.com','erkek'),  ('25','gamze','kayın','05457553241','gamze_kayın@gmail.com','kadın')
