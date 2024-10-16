DROP USER if EXISTS 'director'@'localhost';
create user 'director'@'localhost' identified by 'passDirector12-';
GRANT SELECT, INSERT, UPDATE, DELETE ON studio.peliculas TO 'director'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON studio.Actor_voz TO 'director'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON studio.Estudio TO 'director'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON studio.Personajes TO 'director'@'localhost';


DROP USER IF EXISTS 'espectador'@'%';
CREATE USER 'espectador'@'%' identified by 'passEspectador12-';
GRANT SELECT on studio.* to 'espectador'@'%';
GRANT UPDATE(calificacion) on studio.peliculas to 'espectador'@'%';