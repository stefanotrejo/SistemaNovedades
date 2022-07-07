Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class PerfilMenu
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _pmeId As Integer
            Public Property pmeId() As Integer
                Get
					Return _pmeId
                End Get
                Set(ByVal value As Integer)
                    _pmeId = value
                End Set
            End Property

			Private _pmeActivo As Boolean
            Public Property pmeActivo() As Boolean
                Get
					Return _pmeActivo
                End Get
                Set(ByVal value As Boolean)
                    _pmeActivo = value
                End Set
            End Property

			Private _pmeFechaHoraCreacion As Date
            Public Property pmeFechaHoraCreacion() As Date
                Get
					Return _pmeFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _pmeFechaHoraCreacion = value
                End Set
            End Property

			Private _pmeFechaHoraUltimaModificacion As Date
            Public Property pmeFechaHoraUltimaModificacion() As Date
                Get
					Return _pmeFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _pmeFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _perId As Integer
            Public Property perId() As Integer
                Get
					Return _perId
                End Get
                Set(ByVal value As Integer)
                    _perId = value
                End Set
            End Property

			Private _menId As Integer
            Public Property menId() As Integer
                Get
					Return _menId
                End Get
                Set(ByVal value As Integer)
                    _menId = value
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
                    Me.pmeId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal pmeId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", New Object(,) {{"@pmeId", pmeId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("pmeId").ToString().Trim().Length > 0 Then
                            Me.pmeId = Convert.ToInt32(Fila(0)("pmeId"))
                        Else
                            Me.pmeId = 0
                        End If
                        
						If Fila(0)("pmeFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.pmeFechaHoraCreacion = Convert.ToDateTime(Fila(0)("pmeFechaHoraCreacion"))
                        Else
                            Me.pmeFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("pmeFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.pmeFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("pmeFechaHoraUltimaModificacion"))
                        Else
                            Me.pmeFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("pmeActivo").ToString().Trim().Length > 0 Then
                            Me.pmeActivo = IIf(Convert.ToInt32(Fila(0)("pmeActivo")) = 1, True, False)
                        Else
							Me.pmeActivo = False
                        End If
                        
						If Fila(0)("perId").ToString().Trim().Length > 0 Then
                            Me.perId = Convert.ToInt32(Fila(0)("perId"))
                        Else
							Me.perId = 0
                        End If
                        
						If Fila(0)("menId").ToString().Trim().Length > 0 Then
                            Me.menId = Convert.ToInt32(Fila(0)("menId"))
                        Else
							Me.menId = 0
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

			Public Sub New(ByVal pmeId As Integer, ByVal pmeActivo As Boolean, ByVal pmeFechaHoraCreacion As Date, ByVal pmeFechaHoraUltimaModificacion As Date, ByVal IperId As Integer, ByVal ImenId As Integer, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.pmeId = pmeId
					me.pmeActivo = pmeActivo
					me.pmeFechaHoraCreacion = pmeFechaHoraCreacion
					me.pmeFechaHoraUltimaModificacion = pmeFechaHoraUltimaModificacion
					me.perId = perId
					me.menId = menId
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal pmeId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerUno]", New Object(,) {{"@pmeId", pmeId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerxperIdCustom(ByVal perId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[PerfilMenu.ObtenerxperIdCustom]", New Object(,) {{"@perId", perId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal pmeId as Integer, ByVal perId as Integer, ByVal menId as Integer, ByVal pmeActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal pmeFechaHoraCreacion as Date, ByVal pmeFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", New Object(,) {{"@pmeId", pmeId}, {"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal pmeId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", New Object(,) {{"@pmeId", pmeId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub EliminarPadresSinHijos(ByVal perId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.EliminarPadresSinHijos]", New Object(,) {{"@perId", perId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal perId as Integer, ByVal menId as Integer, ByVal pmeActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal pmeFechaHoraCreacion as Date, ByVal pmeFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[PerfilMenu.Insertar]", New Object(,) {{"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.pmeId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Actualizar]", New Object(,) {{"@pmeId", pmeId}, {"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.pmeId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[PerfilMenu.Eliminar]", New Object(,) {{"@pmeId", pmeId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[PerfilMenu.Insertar]", New Object(,) {{"@perId", perId}, {"@menId", menId}, {"@pmeActivo", pmeActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@pmeFechaHoraCreacion", pmeFechaHoraCreacion}, {"@pmeFechaHoraUltimaModificacion", pmeFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace