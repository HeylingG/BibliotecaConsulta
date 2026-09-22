Imports MySqlConnector

' Módulo con la configuración de acceso a MariaDB.
' Todo el proyecto obtiene su conexión desde aquí.
Public Module ModConexion

    ' Server : nombre o IP del servidor MariaDB
    ' Port   : 3306 es el puerto por omisión
    ' Database: base a la que nos conectamos
    ' Uid/Pwd: usuario de solo lectura creado en el script SQL
    Private Const CADENA As String =
        "Server=localhost;Port=3307;Database=bibliotecadb;" &
        "Uid=root;Pwd=INGDESISTEMAS"

    ' Devuelve una conexión NUEVA y CERRADA.
    ' Quien la pide es responsable de abrirla y cerrarla,
    ' y por eso siempre la usaremos dentro de un bloque Using.
    Public Function ObtenerConexion() As MySqlConnection
        Return New MySqlConnection(CADENA)
    End Function

End Module