-- Consultas

call agregarP(24,1,1,'El niño y la garza','2023-7-14','2023-7-14','2h 4m','anime',1232,'9/10','2d');
-- delimiter &&
call agregarPer(400,24,'Rey Periquito') ;
call asignarAP(49,400);
select PrimerasPeliculas('2006-07-29');
select nombre, peliculasDiferentesDirectores(id_Director)
from director;

call personajesP(24);

select Actores_vozPeliculas (3);

