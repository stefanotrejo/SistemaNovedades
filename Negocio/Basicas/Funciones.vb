Namespace LiquidacionSueldos
    Namespace Negocio
        Public Class Funciones
            Shared ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Shared Tabla As New DataTable
            Shared Cadena As String = ""

            Public Shared Function CantidadConLetra(ByVal NumeroDecimal As String) As String
                Cadena = ""
                Try
                    Tabla = ocdGestor.EjecutarReaderSql("select dbo.CantidadConLetra(" & NumeroDecimal.Replace(",", ".") & ") as CantidadEnLetra")
                    Cadena = Tabla.Rows(0)("CantidadEnLetra").ToString()
                Catch oError As Exception
                    Throw oError
                End Try

                Return Cadena
            End Function
        End Class
    End Namespace
End Namespace
