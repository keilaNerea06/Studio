use studio;
delimiter &&
-- PROCEDURE
-- 1.- 
drop PROCEDURE if exists personajesP&&
create PROCEDURE personajesP (peli int)
BEGIN
    select Nombre
    from personajes
    where id_pelicula = peli;
end &&

-- 2.- agregar pelicula
drop procedure if exists agregarP&&
CREATE PROCEDURE agregarP	(unidpelicula int, unidestudio int, unidirector int, unnombre varchar(100), unfechaestreno date, unfechacreacion date, unDuracion varchar(20), ungenero varchar(20), unpresupuesto double, uncalificacion varchar(20), unprogramastilo varchar(20))
BEGIN
	INSERT INTO Peliculas	(id_pelicula, id_estudio, id_director, nombre, fecha_estreno, fecha_creacion, Duracion, genero, presupuesto, calificacion, programa_stilo)
					VALUES (unidpelicula, unidestudio, unidirector, unnombre, unfechaestreno, unfechacreacion, unDuracion, ungenero, unpresupuesto, uncalificacion, unprogramastilo);
END&&

drop procedure if exists agregarPer&&
CREATE procedure agregarPer(unidpersonaje int, unidpelicula int, unnombre varchar(40))
begin
	insert INTO personajes (id_personaje, id_pelicula, nombre)
					values (unidpersonaje, unidpelicula, unnombre);
end&&

-- 3.-Asignar personajes con actores
drop procedure if exists asignarAP&&
create procedure asignarAP (actor int, personaje int)
begin
	insert into personaje_voz(id_actor, id_personaje)
    values	(actor, personaje);
end &&

drop procedure if exists nuevoActor&&
create procedure nuevoActor (unnombre varchar(20), unapellido varchar(20), unidactor int)
begin
	insert into actor_voz(nombre, apellido, id_actor)
    values	(unnombre, unapellido, unidactor);
end &&
-- FUNCTIONS
-- 1.- 

	DROP FUNCTION if EXISTS peliculasDiferentesDirectores &&
	CREATE function peliculasDiferentesDirectores (xid_director int)
RETURNS INT READS Sql DATA 
Begin 
declare cantidad int;

select COUNT(Distinct id_pelicula ) INTO cantidad 
from peliculas
where id_director = xid_director;

Return cantidad;	
end &&  



-- 2.-



DROP FUNCTION IF EXISTS PrimerasPeliculas &&
CREATE FUNCTION PrimerasPeliculas(fecha DATE)
  RETURNS INT READS Sql DATA
  
BEGIN
  DECLARE total INT;
  
  SELECT COUNT(*)
  INTO total
  FROM peliculas
  WHERE fecha_estreno < fecha;

  RETURN total;
END &&




-- 3.-  SF, para saber cuantos actores de voz participaron en diferentes películas 

	
	DROP FUNCTION if EXISTS Actores_vozPeliculas &&
	CREATE function Actores_vozPeliculas (peli int)
RETURNS INT READS Sql DATA 
BEGIN 
declare Voces_actores int;

select COUNT(Distinct id_actor) INTO Voces_actores 
from personaje_voz Pv
inner join personajes Pe on Pe.id_personaje= Pv.id_personaje
where Pe.id_pelicula = peli;

RETURN Voces_actores;
	
END&&   



-- TRIGGRES
-- 1.-Comprobar la asignacion
drop trigger if exists CasignacionAP&& 
create trigger CasignacionAP before insert on personaje_voz
for each row
begin
	if (not exists(select *
					from personajes
                    where id_personaje= NEW.id_personaje)) then
                    SIGNAL SQLSTATE '45000'
					SET MESSAGE_TEXT = 'No existe el personaje';
    END IF;
    if (not exists(select *
					from actor_voz
                    where id_actor= NEW.id_actor)) then
                    SIGNAL SQLSTATE '45000'
					SET MESSAGE_TEXT = 'No existe el actor';
    END IF;
end &&
-- 2.-si ya existe ese actor


drop trigger if exists CasignacionA && 
create trigger CasignacionA before insert on actor_voz
for each row
begin
	IF(exists(select *
			from actor_voz
			where nombre= new.nombre
			and Apellido= new.Apellido))then 
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Ya existe el actor';
	END IF;
    IF(exists(select *
			from actor_voz
			where id_actor=new.id_actor))then 
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Ya existe ese id';
	END IF;
END &&


-- 3.-
drop trigger if exists pverificar&&
CREATE trigger pverificar before INSERT ON peliculas
for EACH row
begin
	IF (not EXISTS(SELECT *
	FROM Director d
	WHERE id_Director = new.id_Director)) THEN
       SIGNAL SQLSTATE '45000'
       SET MESSAGE_TEXT = 'no existe el director';
	end if;
     
   IF (not EXISTS(SELECT *
   FROM Estudio e
   WHERE id_estudio = new.id_estudio)) THEN
       SIGNAL SQLSTATE '45000'
       SET MESSAGE_TEXT = 'no existe el estudio';
	end if;
end &&







