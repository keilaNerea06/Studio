DROP USER if EXISTS 'director'@'localhost';
create user 'director'@'localhost' identified by 'passdirector';
GRANT ALL ON studio.peliculas TO 'director'@'localhost';
GRANT ALL ON studio.Actor_voz TO 'director'@'localhost';
GRANT ALL ON studio.Estudio TO 'director'@'localhost';
GRANT ALL ON studio.Personajes TO 'director'@'localhost';


DROP USER IF EXISTS 'espectador'@'%';
CREATE USER 'espectador'@'%' identified by ' ';
GRANT SELECT on studio.* to 'espectador'@'%';
GRANT UPDATE(calificacion) on studio.peliculas to 'espectador'@'%';