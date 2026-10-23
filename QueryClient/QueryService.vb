' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "QueryService" en el código y en el archivo de configuración a la vez.
Imports System.Data.SqlClient

Public Class QueryService
    Implements IQueryService

    Private cadenaConexion As String = "Data Source=192.168.1.48;Initial Catalog=ln107gev;User ID=sa;Password=Pa$$w0rd"

    Public Function EjecutarQuery(sql As String) As List(Of List(Of Object)) _
        Implements IQueryService.EjecutarQuery

        Dim resultado As New List(Of List(Of Object))()

        Using cn As New SqlConnection(cadenaConexion)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()

            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim fila As New List(Of Object)
                    For i As Integer = 0 To dr.FieldCount - 1
                        fila.Add(If(dr.IsDBNull(i), Nothing, dr.GetValue(i)))
                    Next
                    resultado.Add(fila)
                End While
            End Using
        End Using

        Return resultado
    End Function

    Public Function ObtenerColumnas(sql As String) As List(Of String) Implements IQueryService.ObtenerColumnas
        Dim columnas As New List(Of String)()

        Using cn As New SqlConnection(cadenaConexion)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()

            Using dr As SqlDataReader = cmd.ExecuteReader()
                For i As Integer = 0 To dr.FieldCount - 1
                    columnas.Add(dr.GetName(i))
                Next
            End Using
        End Using

        Return columnas
    End Function

End Class
