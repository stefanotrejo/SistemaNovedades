Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Perfil
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _perId As Integer
            Public Property perId() As Integer
                Get
					Return _perId
                End Get
                Set(ByVal value As Integer)
                    _perId = value
                End Set
            End Property

			Private _perNombre As String
            Public Property perNombre() As String
                Get
					Return _perNombre
                End Get
                Set(ByVal value As String)
                    _perNombre = value
                End Set
            End Property

			Private _perDescripcion As String
            Public Property perDescripcion() As String
                Get
					Return _perDescripcion
                End Get
                Set(ByVal value As String)
                    _perDescripcion = value
                End Set
            End Property

			Private _perEsAdministrador As Boolean
            Public Property perEsAdministrador() As Boolean
                Get
					Return _perEsAdministrador
                End Get
                Set(ByVal value As Boolean)
                    _perEsAdministrador = value
                End Set
            End Property

			Private _perFechaHoraCreacion As Date
            Public Property perFechaHoraCreacion() As Date
                Get
					Return _perFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _perFechaHoraCreacion = value
                End Set
            End Property

			Private _perFechaHoraUltimaModificacion As Date
            Public Property perFechaHoraUltimaModificacion() As Date
                Get
					Return _perFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _perFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _perActivo As Boolean
            Public Property perActivo() As Boolean
                Get
					Return _perActivo
                End Get
                Set(ByVal value As Boolean)
                    _perActivo = value
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
                    Me.perId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal perId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", New Object(,) {{"@perId", perId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("perId").ToString().Trim().Length > 0 Then
                            Me.perId = Convert.ToInt32(Fila(0)("perId"))
                        Else
                            Me.perId = 0
                        End If
                        
						If Fila(0)("perNombre").ToString().Trim().Length > 0 Then
                            Me.perNombre = Convert.ToString(Fila(0)("perNombre"))
                        Else
                            Me.perNombre = ""
                        End If
                        
						If Fila(0)("perDescripcion").ToString().Trim().Length > 0 Then
                            Me.perDescripcion = Convert.ToString(Fila(0)("perDescripcion"))
                        Else
                            Me.perDescripcion = ""
                        End If
                        
						If Fila(0)("perFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.perFechaHoraCreacion = Convert.ToDateTime(Fila(0)("perFechaHoraCreacion"))
                        Else
                            Me.perFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("perFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.perFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("perFechaHoraUltimaModificacion"))
                        Else
                            Me.perFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("perEsAdministrador").ToString().Trim().Length > 0 Then
                            Me.perEsAdministrador = IIf(Convert.ToInt32(Fila(0)("perEsAdministrador")) = 1, True, False)
                        Else
							Me.perEsAdministrador = False
                        End If
                        
						If Fila(0)("perActivo").ToString().Trim().Length > 0 Then
                            Me.perActivo = IIf(Convert.ToInt32(Fila(0)("perActivo")) = 1, True, False)
                        Else
							Me.perActivo = False
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

			Public Sub New(ByVal perId As Integer, ByVal perNombre As String, ByVal perDescripcion As String, ByVal perEsAdministrador As Boolean, ByVal perFechaHoraCreacion As Date, ByVal perFechaHoraUltimaModificacion As Date, ByVal perActivo As Boolean, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.perId = perId
					me.perNombre = perNombre
					me.perDescripcion = perDescripcion
					me.perEsAdministrador = perEsAdministrador
					me.perFechaHoraCreacion = perFechaHoraCreacion
					me.perFechaHoraUltimaModificacion = perFechaHoraUltimaModificacion
					me.perActivo = perActivo
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
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerBuscador]", New Object(,) {{"@ValorABuscar", ValorABuscar}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerLista(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerLista]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerNovedad(ByVal novId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerNovedad]", New Object(,) {{"@novId", novId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoBuscarxNombre(ByVal Nombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerTodoBuscarxNombre]", New Object(,) {{"@Nombre", Nombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal perId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerUno]", New Object(,) {{"@perId", perId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarRepetido(ByVal perId as Integer, ByVal perNombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Perfil.ObtenerValidarRepetido]", New Object(,) {{"@perId", perId}, {"@perNombre", perNombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal perId as Integer, ByVal perNombre as String, ByVal perDescripcion as String, ByVal perEsAdministrador as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal perFechaHoraCreacion as Date, ByVal perFechaHoraUltimaModificacion as Date, ByVal perActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", New Object(,) {{"@perId", perId}, {"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Copiar(ByVal perNombre as String, ByVal perDescripcion as String, ByVal perEsAdministrador as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal perFechaHoraCreacion as Date, ByVal perFechaHoraUltimaModificacion as Date, ByVal perActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", New Object(,) {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal perId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", New Object(,) {{"@perId", perId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal perNombre as String, ByVal perDescripcion as String, ByVal perEsAdministrador as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal perFechaHoraCreacion as Date, ByVal perFechaHoraUltimaModificacion as Date, ByVal perActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Perfil.Insertar]", New Object(,) {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.perId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Perfil.Actualizar]", New Object(,) {{"@perId", perId}, {"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Copiar()
                Try
                    If Me.perId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Perfil.Copiar]", New Object(,) {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.perId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Perfil.Eliminar]", New Object(,) {{"@perId", perId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Perfil.Insertar]", New Object(,) {{"@perNombre", perNombre}, {"@perDescripcion", perDescripcion}, {"@perEsAdministrador", perEsAdministrador}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@perFechaHoraCreacion", perFechaHoraCreacion}, {"@perFechaHoraUltimaModificacion", perFechaHoraUltimaModificacion}, {"@perActivo", perActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace