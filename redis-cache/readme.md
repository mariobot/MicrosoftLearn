# Comandos

Comando 	Descripción
ping 	Hacer ping al servidor. Devuelve "PONG".
set [key] [value] 	Establece una clave o un valor en la memoria caché. Devuelve "OK" cuando la operación se realiza correctamente.
get [key] 	Obtiene un valor de la caché.
exists [key] 	Devuelve "1" si la clave existe en la memoria caché o "0" si no existe.
type [key] 	Devuelve el tipo asociado con el valor de la clave dada.
incr [key] 	Incremente el valor dado asociado con la clave en "1". El valor debe ser un número entero o un valor doble. Devuelve el nuevo valor.
incrby [key] [amount] 	Incremente el valor dado asociado con la clave en la cantidad especificada. El valor debe ser un número entero o un valor doble. Devuelve el nuevo valor.
del [key] 	Elimina el valor asociado con la clave.
flushdb 	Elimine todas las claves y valores de la base de datos.

