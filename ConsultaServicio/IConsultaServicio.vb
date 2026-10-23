Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IConsultaServicio" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IConsultaServicio

    <OperationContract()>
    Function EjecutarQuery(sql As String) As List(Of List(Of Object))

    <OperationContract()>
    Function ObtenerColumnas(sql As String) As List(Of String)

End Interface
