Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Parametro
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _parId As Integer
            Public Property parId() As Integer
                Get
					Return _parId
                End Get
                Set(ByVal value As Integer)
                    _parId = value
                End Set
            End Property

			Private _parNombre As String
            Public Property parNombre() As String
                Get
					Return _parNombre
                End Get
                Set(ByVal value As String)
                    _parNombre = value
                End Set
            End Property

			Private _parValor As String
            Public Property parValor() As String
                Get
					Return _parValor
                End Get
                Set(ByVal value As String)
                    _parValor = value
                End Set
            End Property

			Private _parActivo As Boolean
            Public Property parActivo() As Boolean
                Get
					Return _parActivo
                End Get
                Set(ByVal value As Boolean)
                    _parActivo = value
                End Set
            End Property

			Private _parFechaHoraCreacion As Date
            Public Property parFechaHoraCreacion() As Date
                Get
					Return _parFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _parFechaHoraCreacion = value
                End Set
            End Property

			Private _parFechaHoraUltimaModificacion As Date
            Public Property parFechaHoraUltimaModificacion() As Date
                Get
					Return _parFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _parFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _usuIdCreacion As Integer
            Public Property usuIdCreacion() As Integer
                Get
					Return _usuIdCreacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdCreacion = value
                End Set
            End Property

			Private _usuIdUltimaModificacion As Integer
            Public Property usuIdUltimaModificacion() As Integer
                Get
					Return _usuIdUltimaModificacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdUltimaModificacion = value
                End Set
            End Property

			Public Sub New()
                Try                
                    Me.parId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal parId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", New Object(,) {{"@parId", parId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("parId").ToString().Trim().Length > 0 Then
                            Me.parId = Convert.ToInt32(Fila(0)("parId"))
                        Else
                            Me.parId = 0
                        End If
                        
						If Fila(0)("parNombre").ToString().Trim().Length > 0 Then
                            Me.parNombre = Convert.ToString(Fila(0)("parNombre"))
                        Else
                            Me.parNombre = ""
                        End If
                        
						If Fila(0)("parValor").ToString().Trim().Length > 0 Then
                            Me.parValor = Convert.ToString(Fila(0)("parValor"))
                        Else
                            Me.parValor = ""
                        End If
                        
						If Fila(0)("parFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.parFechaHoraCreacion = Convert.ToDateTime(Fila(0)("parFechaHoraCreacion"))
                        Else
                            Me.parFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("parFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.parFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("parFechaHoraUltimaModificacion"))
                        Else
                            Me.parFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("parActivo").ToString().Trim().Length > 0 Then
                            Me.parActivo = IIf(Convert.ToInt32(Fila(0)("parActivo")) = 1, True, False)
                        Else
							Me.parActivo = False
                        End If
                        
						If Fila(0)("usuIdCreacion").ToString().Trim().Length > 0 Then
                            Me.usuIdCreacion = Convert.ToInt32(Fila(0)("usuIdCreacion"))
                        Else
							Me.usuIdCreacion = 0
                        End If
                        
						If Fila(0)("usuIdUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.usuIdUltimaModificacion = Convert.ToInt32(Fila(0)("usuIdUltimaModificacion"))
                        Else
							Me.usuIdUltimaModificacion = 0
                        End If
                        
					End If
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub New(ByVal parId As Integer, ByVal parNombre As String, ByVal parValor As String, ByVal parActivo As Boolean, ByVal parFechaHoraCreacion As Date, ByVal parFechaHoraUltimaModificacion As Date, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.parId = parId
					me.parNombre = parNombre
					me.parValor = parValor
					me.parActivo = parActivo
					me.parFechaHoraCreacion = parFechaHoraCreacion
					me.parFechaHoraUltimaModificacion = parFechaHoraUltimaModificacion
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerBuscador(ByVal ValorABuscar as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerBuscador]", New Object(,) {{"@ValorABuscar", ValorABuscar}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerCompararBasesDatos() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerCompararBasesDatos]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerLista(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerLista]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoBuscarxNombre(ByVal Nombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", New Object(,) {{"@Nombre", Nombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal parId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerUno]", New Object(,) {{"@parId", parId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUsoTablas() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerUsoTablas]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarRepetido(ByVal parId as Integer, ByVal parNombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerValidarRepetido]", New Object(,) {{"@parId", parId}, {"@parNombre", parNombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal parId as Integer, ByVal parNombre as String, ByVal parValor as String, ByVal parActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal parFechaHoraCreacion as Date, ByVal parFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", New Object(,) {{"@parId", parId}, {"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub ActualizarPorparNombre(ByVal parNombre as String, ByVal parValor as String, ByVal usuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.ActualizarPorparNombre]", New Object(,) {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@usuId", usuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Copiar(ByVal parNombre as String, ByVal parValor as String, ByVal parActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal parFechaHoraCreacion as Date, ByVal parFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", New Object(,) {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal parId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", New Object(,) {{"@parId", parId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub EliminarBloqueos(ByVal BaseDatos as String)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.EliminarBloqueos]", New Object(,) {{"@BaseDatos", BaseDatos}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal parNombre as String, ByVal parValor as String, ByVal parActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal parFechaHoraCreacion as Date, ByVal parFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Parametro.Insertar]", New Object(,) {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.parId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Parametro.Actualizar]", New Object(,) {{"@parId", parId}, {"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Copiar()
                Try
                    If Me.parId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Parametro.Copiar]", New Object(,) {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.parId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Parametro.Eliminar]", New Object(,) {{"@parId", parId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Parametro.Insertar]", New Object(,) {{"@parNombre", parNombre}, {"@parValor", parValor}, {"@parActivo", parActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@parFechaHoraCreacion", parFechaHoraCreacion}, {"@parFechaHoraUltimaModificacion", parFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace