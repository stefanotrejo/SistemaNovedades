using LiquidacionSueldos.Negocio;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

//28.11.19 -- Incluye ajuste de 5 caracteres agregados (puntaje miembro junta)

public partial class PaginasPrueba_GenerarTablaAgentesCargo : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();

    #region  Variables Globales
    public class Globales
    {
        private static String _FechaLiquidacionGlobal;
        public static String FechaLiquidacionGlobal
        {
            get
            {
                // Reads are usually simple
                return _FechaLiquidacionGlobal;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _FechaLiquidacionGlobal = value;
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        lblFechaHoraInicio.Visible = true;
        lblFechaHoraInicio.Text = DateTime.Now.ToString();
    }

    protected void btnImportar_Click(object sender, EventArgs e)
    {
        // FIN PRUEBAS
        LiquidacionSueldos.Negocio.NuevoAge1 ocpAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
        lblFechaHoraInicio.Visible = true;
        lblFechaHoraInicio.Text = DateTime.Now.ToString();
        String linea;
        System.IO.StreamReader archivo = new System.IO.StreamReader(@"c:\test.txt");

        #region         Verifica si el periodo de liqudiacion ya fue importada
        ocnMenu = new LiquidacionSueldos.Negocio.Menu();

        int ajuste = 5; // Ajuste por nuevo campo de 5 caracteres (puntaje miembro junta)
        int ajustePlantaJacky = 1; // Ajuste por nuevo campo de 1 caracter al principio del archivo

        linea = archivo.ReadLine();
        String mesLiquidacion = linea.Substring(121 + ajustePlantaJacky + ajuste, 2);
        String anioLiquidacion = linea.Substring(123 + ajustePlantaJacky + ajuste, 2);
        String fecha = "01" + "/" + mesLiquidacion + "/" + anioLiquidacion;
        DateTime FechaLiquidacion = Convert.ToDateTime(fecha);
        dt = ocnMenu.LiquidacionObtenerUno(mesLiquidacion + "/" + anioLiquidacion);
        if (dt.Rows.Count == 0)
        {
            archivo.Close();
            #endregion

            #region Lectura de Archivo

            System.IO.StreamReader archivo2 = new System.IO.StreamReader(@"c:\test.txt");
            bool codigoBonificacion199 = false;
            string importeBonificacion199 = "";
            bool codigoBonificacion601 = false;
            string importeBonificacion601 = "";
            bool codigoRiesgoDeVida = false;
            int siturev_numero;
            bool ResultadoConversion;

            while (archivo2.EndOfStream == false)
            {
                linea = archivo2.ReadLine();
                String planta = linea.Substring(0 + ajustePlantaJacky, 1);
                String nrocontrol = linea.Substring(1 + ajustePlantaJacky, 8);
                String lugarpago = linea.Substring(9 + ajustePlantaJacky, 5);
                String escuela = linea.Substring(14 + ajustePlantaJacky, 5);
                String escalafon = linea.Substring(19 + ajustePlantaJacky, 1);
                String agrupamiento = linea.Substring(20 + ajustePlantaJacky, 2);
                String tramo = linea.Substring(22 + ajustePlantaJacky, 1);
                String apertura = linea.Substring(23 + ajustePlantaJacky, 3);
                String categoria = linea.Substring(26 + ajustePlantaJacky, 2);
                String hscatedra = linea.Substring(28 + ajustePlantaJacky, 2);
                //UNIDAD PRESUPUESTARIA
                String jurisdiccion = linea.Substring(30 + ajustePlantaJacky, 2);
                String programa = linea.Substring(32 + ajustePlantaJacky, 2);
                String subprograma = linea.Substring(34 + ajustePlantaJacky, 2);
                String actividad = linea.Substring(36 + ajustePlantaJacky, 2);
                //AGENTE
                String nombre = linea.Substring(38 + ajustePlantaJacky, 25);
                String prefijo = linea.Substring(63 + ajustePlantaJacky, 2);
                String numero = linea.Substring(65 + ajustePlantaJacky, 8);
                String sufijo = linea.Substring(73 + ajustePlantaJacky, 1);
                String tipodocumento = linea.Substring(74 + ajustePlantaJacky, 1);
                String fechanacimiento = linea.Substring(75 + ajustePlantaJacky, 6);
                String sexo = linea.Substring(81 + ajustePlantaJacky, 1);
                String estadocivil = linea.Substring(82 + ajustePlantaJacky, 1);
                String fechaingreso = linea.Substring(83 + ajustePlantaJacky, 6);
                //ANTIGUEDAD RECONOCIDA
                String anios = linea.Substring(89 + ajustePlantaJacky, 2);
                String meses = linea.Substring(91 + ajustePlantaJacky, 1);
                String diasmultaantiguedad = linea.Substring(92 + ajustePlantaJacky, 3);
                String aniosantiguedad = linea.Substring(95 + ajustePlantaJacky, 2);
                String permanenciaEnElCargo = linea.Substring(97 + ajustePlantaJacky, 2);
                String nroCarnetIosep = linea.Substring(99 + ajustePlantaJacky, 7);
                String aporteIosep = linea.Substring(106 + ajustePlantaJacky, 1);
                String aporteOSocNacional = linea.Substring(107 + ajustePlantaJacky, 1);
                String jubilado = linea.Substring(108 + ajustePlantaJacky, 1);
                String aporteprevisional = linea.Substring(109 + ajustePlantaJacky, 2);
                String situacionRevista = linea.Substring(111 + ajustePlantaJacky, 1);
                String interinato = linea.Substring(112 + ajustePlantaJacky, 1);
                String situacionRevistaDocente = linea.Substring(113 + ajustePlantaJacky, 1);
                //int ajuste = 5; espacio por nuevo campo (puntaje miembro junta)
                String noPresentismoNoRiesgo = linea.Substring(114 + ajustePlantaJacky + ajuste, 1);
                String fechabaja = linea.Substring(115 + ajustePlantaJacky + ajuste, 6);

                //PERIODO DE LIQUIDACION
                mesLiquidacion = linea.Substring(121 + ajustePlantaJacky + ajuste, 2);
                anioLiquidacion = linea.Substring(123 + ajustePlantaJacky + ajuste, 2);

                String diasTrabajados = linea.Substring(125 + ajustePlantaJacky + ajuste, 3);
                String imponibleParaAnses = linea.Substring(128 + ajustePlantaJacky + ajuste, 6) + //enteros
                                            '.' + linea.Substring(134 + ajustePlantaJacky + ajuste, 2).Replace(' ', '0'); //decimales

                String imponible = linea.Substring(136 + ajustePlantaJacky + ajuste, 6) + //Enteros
                                '.' + linea.Substring(142 + ajustePlantaJacky + ajuste, 2); //Decimales

                String haberSinAporte = linea.Substring(144 + ajustePlantaJacky + ajuste, 7)
                    + '.' + linea.Substring(151 + ajustePlantaJacky + ajuste, 2);
                String haberConAporte = linea.Substring(153 + ajustePlantaJacky + ajuste, 7)
                    + '.' + linea.Substring(160 + ajustePlantaJacky + ajuste, 2);
                String totalHaberes = linea.Substring(162 + ajustePlantaJacky + ajuste, 7)
                    + '.' + linea.Substring(169 + ajustePlantaJacky + ajuste, 2);
                String totalDescuentos = linea.Substring(171 + ajustePlantaJacky + ajuste, 7)
                    + '.' + linea.Substring(178 + ajustePlantaJacky + ajuste, 2);
                String liquido = linea.Substring(180 + ajustePlantaJacky + ajuste, 7)
                    + '.' + linea.Substring(187 + ajustePlantaJacky + ajuste, 2);
                String cantidadItemsOcupados = linea.Substring(189 + ajustePlantaJacky + ajuste, 2);
                String codBonifDescto2 = "";
                String importe = "";
                #endregion

                #region Objeto Agente
                ocpAgente.CantItemsOcupados = cantidadItemsOcupados;
                ocpAgente.Actividad = actividad;
                ocpAgente.Ad_Prof_Perm_cgo = permanenciaEnElCargo;
                ocpAgente.Agru = agrupamiento;
                ocpAgente.Anios = anios;
                ocpAgente.AniosAntig = aniosantiguedad;
                ocpAgente.Apertura = apertura;
                ocpAgente.AporteIOSEP = aporteIosep;
                ocpAgente.AporteOsocNac = aporteOSocNacional;
                ocpAgente.AportePrevisional = aporteprevisional;
                ocpAgente.Categoria = categoria;
                ocpAgente.Cuil = prefijo + numero + sufijo;
                ocpAgente.DiasMultaAntig = diasmultaantiguedad;
                ocpAgente.DiasTrabajados = diasTrabajados;
                ocpAgente.Escalafon = escalafon;
                ocpAgente.Escuela = escuela;
                ocpAgente.EstadoCivil = estadocivil;
                ocpAgente.FechaBaja = fechabaja;
                ocpAgente.FechaIngreso = fechaingreso;
                ocpAgente.FechaNac = fechanacimiento;
                ocpAgente.HaberC_aporte = haberConAporte;
                ocpAgente.HaberS_aporte = haberSinAporte;
                ocpAgente.HsCat = hscatedra;
                ocpAgente.Imponible = imponible;
                ocpAgente.ImponibleANSES = imponibleParaAnses;
                ocpAgente.Interinato = interinato;
                ocpAgente.Jubilado = jubilado;
                ocpAgente.Juris = jurisdiccion;
                ocpAgente.Liquido = liquido;
                ocpAgente.LugarPago = lugarpago;
                ocpAgente.MesAnioLiq = mesLiquidacion + "/" + anioLiquidacion;
                ocpAgente.Meses = meses;
                ocpAgente.Nombre = nombre;
                if (ocpAgente.Nombre.IndexOf('�') != -1)
                {
                    ocpAgente.Nombre = ocpAgente.Nombre.Replace('�', 'Ñ');
                }
                ocpAgente.Nopres_RiesgoVida = noPresentismoNoRiesgo;
                ocpAgente.NroCOntrol = nrocontrol;
                ocpAgente.NumeroCarnet = nroCarnetIosep;
                ocpAgente.PlantaTipo = planta;
                ocpAgente.Prog = programa;
                ocpAgente.Sexo = sexo;
                ocpAgente.SituRev = situacionRevista;
                ocpAgente.SituRevDoc = situacionRevistaDocente;
                ocpAgente.SubP = subprograma;
                ocpAgente.TipoDOc = tipodocumento;
                ocpAgente.TotalDescuentos = totalDescuentos;
                ocpAgente.TotalHaberes = totalHaberes;
                ocpAgente.tramo = tramo;
                ocpAgente.FechaLiquidacion = FechaLiquidacion;
                ocpAgente.Legajo = linea.Substring(797, 7);
                ocpAgente.Activo = 1;
                #endregion

                int id = ocpAgente.Insertar();

                #region Conceptos                
                int cant = 191 + ajuste + ajustePlantaJacky; //numero donde comienzan los conceptos.
                codigoBonificacion199 = false;
                importeBonificacion199 = "";
                codigoBonificacion601 = false;
                importeBonificacion601 = "";
                codigoRiesgoDeVida = false;
                for (int i = 1; i <= Convert.ToInt32(cantidadItemsOcupados); i++)
                {
                    codBonifDescto2 = linea.Substring(cant, 3);
                    cant = cant + 3; //comienza importe que tiene 7 enteros y 2 decimales
                    importe = linea.Substring(cant, 7);
                    cant = cant + 7;
                    importe = importe + '.' + linea.Substring(cant, 2);
                    cant = cant + 2;

                    if (Convert.ToInt32(codBonifDescto2) == 199)
                    {
                        codigoBonificacion199 = true;
                        importeBonificacion199 = importe;
                    }
                    if (Convert.ToInt32(codBonifDescto2) == 601)
                    {
                        codigoBonificacion601 = true;
                        importeBonificacion601 = importe;
                    }

                    if ((Convert.ToInt32(codBonifDescto2) == 045) || (Convert.ToInt32(codBonifDescto2) == 052))
                    {
                        codigoRiesgoDeVida = true;
                    }

                    ocpAgente.InsertarCodBonificacionImporte(id, codBonifDescto2, importe);
                }
                ocpAgente.CalcularHaberes(id);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //ASISTENCIA PERFECTA
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

                if (codigoBonificacion199 == false)
                {
                    ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                }
                else
                {
                    if (codigoBonificacion601 == false)
                    {
                        //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1
                        ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                    }
                    else //EXISTEN AMBOS CODIGOS  -> VEO LOS VALORES
                    {
                        if (importeBonificacion199 == importeBonificacion601) //SE LE SUMA Y RESTA EL MISMO VALOR. NO COBRA
                        {
                            //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                            ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                        }
                        else //VALORES DISTINTOS. CONSULTO SIT. REVISTA
                        {
                            //VERIFICO SI ES VACIO O NULO -> SI COBRA
                            if (String.IsNullOrEmpty(ocpAgente.SituRev.Trim()))
                            {
                                //    //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1
                                //    //INSERTAR EN UNA TABLA AUXILIAR PARA VERIFICAR CASOS 
                                ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                ocpAgente.InsertarAgenteRevision(id);
                            }
                            else //VERIFICO SI ES UN NUMERO O LETRA
                            {
                                ResultadoConversion = Int32.TryParse(ocpAgente.SituRev, out siturev_numero);
                                if (ResultadoConversion)
                                {
                                    if ((siturev_numero == 4) || (siturev_numero == 5) ||
                                           (siturev_numero == 6) || (siturev_numero == 7))
                                    {
                                        //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                                        ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                                    }
                                    else
                                    {
                                        //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1 - REVISAR CASO
                                        ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                        ocpAgente.InsertarAgenteRevision(id);
                                    }
                                }
                                else
                                {
                                    //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                                    ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                    ocpAgente.InsertarAgenteRevision(id);
                                }
                            }
                        }
                    }
                }

                #region Riesgo de Vida
                //DETERMINA CAMPO RIESGO DE VIDA
                if (codigoRiesgoDeVida == true)
                {
                    //UPDATE AL CAMPO RIESGO DE VIDA CON 1
                    ocpAgente.ActualizarRiesgoDeVida(id, 1);
                }
                else
                {
                    //UPDATE AL CAMPO RIESGO DE VIDA CON 0
                    ocpAgente.ActualizarRiesgoDeVida(id, 0);
                }
                #endregion

                #region Jubilado o Retencion Activo
                //JUBILADO O RETENCION ACTIVO
                if (ocpAgente.Jubilado == "R")
                {
                    ocpAgente.ActualizarJubRetActivo(id, 1);
                }
                else
                {
                    ocpAgente.ActualizarJubRetActivo(id, 0);
                }
                #endregion
            }
            archivo2.Close();
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "Importacion realizada correctamente";
            lblFechaHoraFin.Visible = true;
            lblFechaHoraFin.Text = DateTime.Now.ToString();
            #endregion
        }
        // EL ARCHIVO YA FUE IMPORTADO
        else
        {
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "El periodo de liqudiacion ya fue importado !!";
        }
    }

    protected void btnImportar_Click_2(object sender, EventArgs e)
    {
        int num;
        NuevoAge1 nuevoAge1 = new NuevoAge1();
        this.ocnMenu = new LiquidacionSueldos.Negocio.Menu();

        this.lblFechaHoraInicio.Visible = true;
        this.lblFechaHoraInicio.Text = DateTime.Now.ToString();

        StreamReader streamReader = new StreamReader("c:\\test.txt", Encoding.Default, true);

        int num1 = 5;
        int num2 = 1;
        int num3 = 2;
        string str = streamReader.ReadLine();
        if (str.IndexOf('Ã') != -1)
        {
            int length = str.Length;
            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.UTF8.GetString(bytes);
            int length1 = str.Length;
            string str1 = str.Substring(0, 62);
            string str2 = str.Substring(63);
            while (length >= length1)
            {
                str1 = string.Concat(str1, " ");
                length1++;
            }
            str = string.Concat(str1, str2);
        }

        string mes = str.Substring(121 + num3 + num1, 2);
        string anio = str.Substring(123 + num3 + num1, 2);
        string str5 = string.Concat("01/01/2001");
        DateTime dateTime = Convert.ToDateTime(str5);

        this.dt = this.ocnMenu.LiquidacionObtenerUno(string.Concat(mes, "/", anio));
        if (this.dt.Rows.Count != 0 && this.validarPeriodo.Checked)
        {
            this.Label1.Visible = true;
            this.Label1.ForeColor = Color.Red;
            this.Label1.Text = "El periodo de liquidacion ya fue importado !!";
            return;
        }

        streamReader.Close();
        StreamReader streamReader1 = new StreamReader("c:\\test.txt", Encoding.Default, true);
        bool flag = false;
        string str6 = "";
        bool flag1 = false;
        string str7 = "";
        bool flag2 = false;
        while (!streamReader1.EndOfStream)
        {
            str = streamReader1.ReadLine();
            if (str.IndexOf('\uFFFD') != -1)
            {
                str = str.Replace('\uFFFD', 'Ñ');
            }
            if (str.IndexOf('Ã') != -1)
            {
                int length2 = str.Length;
                byte[] numArray = Encoding.Default.GetBytes(str);
                str = Encoding.UTF8.GetString(numArray);
                int length3 = str.Length;
                string str8 = str.Substring(0, 62);
                string str9 = str.Substring(63);
                while (length2 >= length3)
                {
                    str8 = string.Concat(str8, " ");
                    length3++;
                }
                str = string.Concat(str8, str9);
            }
            string str10 = str.Substring(num2, 1);
            string str11 = str.Substring(1 + num2, 8);
            string str12 = str.Substring(9 + num2, 5);
            string str13 = str.Substring(14 + num2, 5);
            string str14 = str.Substring(19 + num2, 1);
            string str15 = str.Substring(20 + num2, 2);
            string str16 = str.Substring(22 + num2, 1);
            string str17 = str.Substring(23 + num2, 3);
            string str18 = str.Substring(26 + num2, 2);
            string str19 = str.Substring(28 + num2, 2);
            string str20 = str.Substring(30 + num2, 2);
            string str21 = str.Substring(32 + num2, 2);
            string str22 = str.Substring(34 + num2, 2);
            string str23 = str.Substring(36 + num2, 2);
            string str24 = str.Substring(38 + num2, 25);
            string str25 = str.Substring(63 + num2, 2);
            string str26 = str.Substring(65 + num2, 8);
            string str27 = str.Substring(73 + num2, 1);
            string str28 = str.Substring(74 + num2, 1);
            string str29 = str.Substring(75 + num2, 6);
            string str30 = str.Substring(81 + num2, 1);
            string str31 = str.Substring(82 + num2, 1);
            string str32 = str.Substring(83 + num2, 6);
            string str33 = str.Substring(89 + num2, 2);
            string str34 = str.Substring(91 + num2, 1);
            string str35 = str.Substring(92 + num2, 3);
            string str36 = str.Substring(95 + num2, 2);
            string str37 = str.Substring(97 + num2, 2);
            string str38 = str.Substring(99 + num2, 7);
            string str39 = str.Substring(106 + num2, 1);
            string str40 = str.Substring(107 + num2, 1);
            string str41 = str.Substring(108 + num2, 1);
            string str42 = str.Substring(109 + num2, 2);
            string str43 = str.Substring(111 + num2, 1);
            string str44 = str.Substring(111 + num3, 1);
            string str45 = str.Substring(112 + num3, 1);
            string str46 = str.Substring(113 + num3, 1);
            string str47 = str.Substring(114 + num3 + num1, 1);
            string str48 = str.Substring(115 + num3 + num1, 6);
            mes = str.Substring(121 + num3 + num1, 2);
            anio = str.Substring(123 + num3 + num1, 2);
            string str49 = str.Substring(125 + num3 + num1, 3);
            string str50 = string.Concat(str.Substring(128 + num3 + num1, 6), '.', str.Substring(134 + num3 + num1, 2).Replace(' ', '0'));
            string str51 = string.Concat(str.Substring(136 + num3 + num1, 6), '.', str.Substring(142 + num3 + num1, 2));
            string str52 = string.Concat(str.Substring(144 + num3 + num1, 7), '.', str.Substring(151 + num3 + num1, 2));
            string str53 = string.Concat(str.Substring(153 + num3 + num1, 7), '.', str.Substring(160 + num3 + num1, 2));
            string str54 = string.Concat(str.Substring(162 + num3 + num1, 7), '.', str.Substring(169 + num3 + num1, 2));
            string str55 = string.Concat(str.Substring(171 + num3 + num1, 7), '.', str.Substring(178 + num3 + num1, 2));
            string str56 = string.Concat(str.Substring(180 + num3 + num1, 7), '.', str.Substring(187 + num3 + num1, 2));
            string str57 = str.Substring(189 + num3 + num1, 2);
            string str58 = "";
            string str59 = "";
            nuevoAge1.CantItemsOcupados = str57;
            nuevoAge1.Actividad = str23;
            nuevoAge1.Ad_Prof_Perm_cgo = str37;
            nuevoAge1.Agru = str15;
            nuevoAge1.Anios = str33;
            nuevoAge1.AniosAntig = str36;
            nuevoAge1.Apertura = str17;
            nuevoAge1.AporteIOSEP = str39;
            nuevoAge1.AporteOsocNac = str40;
            nuevoAge1.AportePrevisional = str42;
            nuevoAge1.Categoria = str18;
            nuevoAge1.Cuil = string.Concat(str25, str26, str27);
            nuevoAge1.DiasMultaAntig = str35;
            nuevoAge1.DiasTrabajados = str49;
            nuevoAge1.Escalafon = str14;
            nuevoAge1.Escuela = str13;
            nuevoAge1.EstadoCivil = str31;
            nuevoAge1.FechaBaja = str48;
            nuevoAge1.FechaIngreso = str32;
            nuevoAge1.FechaNac = str29;
            nuevoAge1.HaberC_aporte = str53;
            nuevoAge1.HaberS_aporte = str52;
            nuevoAge1.HsCat = str19;
            nuevoAge1.Imponible = str51;
            nuevoAge1.ImponibleANSES = str50;
            nuevoAge1.Interinato = str45;
            nuevoAge1.Jubilado = str41;
            nuevoAge1.Juris = str20;
            nuevoAge1.Liquido = str56;
            nuevoAge1.LugarPago = str12;
            nuevoAge1.MesAnioLiq = string.Concat(mes, "/", anio);
            nuevoAge1.Meses = str34;
            nuevoAge1.Nombre = str24;
            nuevoAge1.Nopres_RiesgoVida = str47;
            nuevoAge1.NroCOntrol = str11;
            nuevoAge1.NumeroCarnet = str38;
            nuevoAge1.PlantaTipo = str10;
            nuevoAge1.Prog = str21;
            nuevoAge1.Sexo = str30;
            nuevoAge1.SituRev = str44;
            nuevoAge1.SituRevDoc = str46;
            nuevoAge1.SubP = str22;
            nuevoAge1.TipoDOc = str28;
            nuevoAge1.TotalDescuentos = str55;
            nuevoAge1.TotalHaberes = str54;
            nuevoAge1.tramo = str16;
            nuevoAge1.FechaLiquidacion = dateTime;
            nuevoAge1.Legajo = str.Substring(797 + num3 - num2, 7);
            nuevoAge1.Activo = 1;
            nuevoAge1.Bloqueo = str43;
            int num4 = nuevoAge1.Insertar();
            int num5 = 191 + num1 + num3;
            flag = false;
            str6 = "";
            flag1 = false;
            str7 = "";
            flag2 = false;
            for (int i = 1; i <= Convert.ToInt32(str57); i++)
            {
                str58 = str.Substring(num5, 3);
                num5 += 3;
                str59 = str.Substring(num5, 7);
                num5 += 7;
                str59 = string.Concat(str59, '.', str.Substring(num5, 2));
                num5 += 2;
                if (Convert.ToInt32(str58) == 199)
                {
                    flag = true;
                    str6 = str59;
                }
                if (Convert.ToInt32(str58) == 601)
                {
                    flag1 = true;
                    str7 = str59;
                }
                if (Convert.ToInt32(str58) == 45 || Convert.ToInt32(str58) == 52)
                {
                    flag2 = true;
                }
                nuevoAge1.InsertarCodBonificacionImporte(num4, str58, str59);
            }
            nuevoAge1.CalcularHaberes(num4);
            if (!flag)
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 0);
            }
            else if (!flag1)
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 1);
            }
            else if (str6 == str7)
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 0);
            }
            else if (string.IsNullOrEmpty(nuevoAge1.SituRev.Trim()))
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 1);
                nuevoAge1.InsertarAgenteRevision(num4);
            }
            else if (!int.TryParse(nuevoAge1.SituRev, out num))
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 1);
                nuevoAge1.InsertarAgenteRevision(num4);
            }
            else if (num == 4 || num == 5 || num == 6 || num == 7)
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 0);
            }
            else
            {
                nuevoAge1.ActualizarAsistenciaPerfecta(num4, 1);
                nuevoAge1.InsertarAgenteRevision(num4);
            }
            if (!flag2)
            {
                nuevoAge1.ActualizarRiesgoDeVida(num4, 0);
            }
            else
            {
                nuevoAge1.ActualizarRiesgoDeVida(num4, 1);
            }
            if (nuevoAge1.Jubilado != "R")
            {
                nuevoAge1.ActualizarJubRetActivo(num4, 0);
            }
            else
            {
                nuevoAge1.ActualizarJubRetActivo(num4, 1);
            }
        }
        streamReader1.Close();
        nuevoAge1.ActivarCargarNovedades(string.Concat(mes, '/', anio));
        this.Label1.Visible = true;
        this.Label1.ForeColor = Color.Green;
        this.Label1.Text = "Importacion realizada correctamente";
        this.lblFechaHoraFin.Visible = true;
        this.lblFechaHoraFin.Text = DateTime.Now.ToString();
    }

    protected void btnCasoUno_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente1 = new LiquidacionSueldos.Negocio.NuevoAge1();
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
        LiquidacionSueldos.Negocio.Error iError = new LiquidacionSueldos.Negocio.Error();
        DataTable dt = new DataTable();
        //  Globales.FechaLiquidacionGlobal = txtFechaLiquidacion.Text;
        try
        {
            dt = oAgente1.ObtenerAgentesCasoUno(txtFechaLiquidacion.Text);
            int IdAgente1 = 0;
            int NroControl1 = 0;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //LEO UNA FILA
                    if (dt.Rows[i]["Id"].ToString().Trim().Length > 0)
                    {
                        // oAgente1.NuevoAgeId = Convert.ToInt32(dt.Rows[0]["Id"]);
                        IdAgente1 = Convert.ToInt32(dt.Rows[i]["Id"]);
                    }
                    if (dt.Rows[i]["Control"].ToString().Trim().Length > 0)
                    {
                        //oAgente1.NroCOntrol = Convert.ToString(dt.Rows[0]["Control"]);
                        NroControl1 = Convert.ToInt32(dt.Rows[i]["Control"]);
                    }

                    //BUSCO AL AGENTE CON ESE NRO DE CONTROL Y CON FONDOS DE NACION PARA SACAR LA INFO
                    //Y HACER EL UPDATE
                    oAgente2 = oAgente1.ObtenerAgenteCasoUno(NroControl1, txtFechaLiquidacion.Text);

                    //UPDATE FONID EN AGENTE CON NUEVOAGEID1 DEL OAgente1
                    oAgente1.ActualizarFonid(IdAgente1, Convert.ToDecimal(oAgente2.TotalSinCargosAlHaber));

                    //UPDATE ACTIVO=0 EN PRUEBASAGE CON NUEVOAGEID1 DEL oAgente2
                    oAgente1.ActivarDesactivarRegistro(oAgente2.NuevoAgeId, 0);
                }
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Caso 1 finalizado";
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "La liquidacion no existe!!";
            }
        }
        catch (Exception oError)
        {
            iError.Insertar(0, oError.Message, oError.StackTrace, oError.TargetSite.ToString());
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Error!!";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        using (OleDbConnection oleDbConnection = new OleDbConnection(string.Concat("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ", "c:\\", "; Extended Properties = dBase III")))
        {
            OleDbCommand oleDbCommand = new OleDbCommand("select * from LI1021", oleDbConnection);
            oleDbConnection.Open();
            DataSet dataSet = new DataSet();
            (new OleDbDataAdapter(oleDbCommand)).Fill(dataSet);
            Agentes agente = new Agentes();
            int num = 0;
            while (num < dataSet.Tables[0].Rows.Count)
            {
                num++;
            }
        }
    }

    protected void btnCasoDos_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente1 = new LiquidacionSueldos.Negocio.NuevoAge1();
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
        Globales.FechaLiquidacionGlobal = txtFechaLiquidacion.Text;

        int IdAgente1 = 0;
        String NroControl1 = "";
        try
        {
            dt = oAgente1.ObtenerAgentesCasoDos(Globales.FechaLiquidacionGlobal);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //LEO UNA FILA
                    if (dt.Rows[i]["Id"].ToString().Trim().Length > 0)
                    {
                        // oAgente1.NuevoAgeId = Convert.ToInt32(dt.Rows[0]["Id"]);
                        IdAgente1 = Convert.ToInt32(dt.Rows[i]["Id"]);
                    }
                    if (dt.Rows[i]["Control"].ToString().Trim().Length > 0)
                    {
                        //oAgente1.NroCOntrol = Convert.ToString(dt.Rows[0]["Control"]);
                        NroControl1 = Convert.ToString(dt.Rows[i]["Control"]);
                    }

                    //BUSCO EL OTRO REGISTRO DEL AGENTE CON NRO DE CONTROL 
                    oAgente2 = oAgente1.ObtenerAgenteCasoDos(NroControl1, Globales.FechaLiquidacionGlobal);

                    //UPDATE DIAS NO TRABAJADOS EN AGENTE CON NUEVOAGEID1 DEL OAgente1
                    oAgente1.ActualizarDiasNoTrabajados(IdAgente1, oAgente2.DiasNoTrabajados);

                    //UPDATE ACTIVO=0 EN PRUEBASAGE CON NUEVOAGEID1 DEL oAgente2
                    oAgente1.ActivarDesactivarRegistro(oAgente2.NuevoAgeId, 0);
                }
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Caso 2 finalizado";
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "La liquidacion no existe!!";
            }
        }
        catch (Exception oError)
        {
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Error!!";
        }
    }

    protected void btnCasoCuatro_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente1 = new LiquidacionSueldos.Negocio.NuevoAge1();
        LiquidacionSueldos.Negocio.NuevoAge1 oAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
        Globales.FechaLiquidacionGlobal = txtFechaLiquidacion.Text;

        int IdAgente1 = 0;
        String NroControl1 = "";
        try
        {
            dt = oAgente1.ObtenerAgentesCasoDos(Globales.FechaLiquidacionGlobal);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //LEO UNA FILA
                    if (dt.Rows[i]["Id"].ToString().Trim().Length > 0)
                    {
                        // oAgente1.NuevoAgeId = Convert.ToInt32(dt.Rows[0]["Id"]);
                        IdAgente1 = Convert.ToInt32(dt.Rows[i]["Id"]);
                    }
                    if (dt.Rows[i]["Control"].ToString().Trim().Length > 0)
                    {
                        //oAgente1.NroCOntrol = Convert.ToString(dt.Rows[0]["Control"]);
                        NroControl1 = Convert.ToString(dt.Rows[i]["Control"]);
                    }

                    //BUSCO EL OTRO REGISTRO DEL AGENTE CON NRO DE CONTROL 
                    oAgente2 = oAgente1.ObtenerAgenteCasoDos(NroControl1, Globales.FechaLiquidacionGlobal);

                    //UPDATE DIAS NO TRABAJADOS EN AGENTE CON NUEVOAGEID1 DEL OAgente1
                    oAgente1.ActualizarDiasNoTrabajados(IdAgente1, oAgente2.DiasNoTrabajados);

                    //UPDATE ACTIVO=0 EN PRUEBASAGE CON NUEVOAGEID1 DEL oAgente2
                    oAgente1.ActivarDesactivarRegistro(oAgente2.NuevoAgeId, 0);
                }
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Caso 2 finalizado";
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "La liquidacion no existe!!";
            }
        }
        catch (Exception oError)
        {
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Error!!";
        }
    }

    protected void btnImportarPersonal_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.NuevoAge1 ocpAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
        lblFechaHoraInicio.Visible = true;
        lblFechaHoraInicio.Text = DateTime.Now.ToString();

        System.IO.StreamReader archivo2 = new System.IO.StreamReader(@"c:\personal.txt");
        String linea;

        while (archivo2.EndOfStream == false)
        {
            linea = archivo2.ReadLine();
            String numeroControl = linea.Substring(0, 8);
            String dni = linea.Substring(22, 8);
            String mesanioliq = txtFechaLiquidacion.Text;
            //ocpAgente.ImportarArchivoPersonal(numeroControl, dni, txtFechaLiquidacion.Text);            
        }
        archivo2.Close();

        Label1.Visible = true;
        Label1.ForeColor = System.Drawing.Color.Green;
        Label1.Text = "Importacion realizada correctamente";
        lblFechaHoraFin.Visible = true;
        lblFechaHoraFin.Text = DateTime.Now.ToString();
    }

    protected void btnExportarDbf_Click(object sender, EventArgs e)
    {
        /*
          //string path = txtdir.Text;
          string path = "c:\test.txt";
          if (Directory.Exists(path))
          {
              Directory.CreateDirectory(path);
              //My.Computer.FileSystem.CreateDirectory(path);
          }

          string NombreArchivo = "prueba.dbf";
          string directorioArchivo = path;
          //string directorioArchivo = txtdir.Text;

          System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection((("Provider=Microsoft.ACE.OLEDB.12.0; data source= "
                          + (directorioArchivo + "\\"))
                          + (NombreArchivo + ";Extended properties=\"Excel 8.0;hdr=yes;imex=1\"")));
          myConnection.Open();
          // 'Si existe el archivo, lo borro
          if (System.IO.File.Exists((directorioArchivo + NombreArchivo)))
          {
              // Dim myCommand As New System.Data.OleDb.OleDbCommand("Delete * FROM " & NombreArchivo, myConnection)
              System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand(("drop table " + NombreArchivo), myConnection);
              OleDb.OleDbCommand comando1 = new OleDb.OleDbCommand();
              comando1.Connection = myConnection;
              myCommand.ExecuteNonQuery();
          }

          string sql;
          if ((ddtipoarchivo.SelectedValue != 1))
          {
              // codosp, codpla, nroafi, cubre, fecnac, codsex, NomAfi
              sql = ("CREATE TABLE "
                          + (NombreArchivo + ("(" + ("CODOSP char(5), " + ("CODPLA char(9)," + ("NROAFI char(15)," + ("CODTIPTIT char(9)," + ("NOMAFI char(30)," + ("CUBRE char(14)," + ("FECNAC char(12)," + "CODSEX char(5))"))))))))));
          }
          else
          {
              sql = ("CREATE TABLE "
                          + (NombreArchivo + ("(" + ("CODSOCIO char(10), " + ("PARID char(2)," + ("APELYNOM char(50)," + ("NROTARJ char(11)," + "NRODOC char(11))")))))));
          }

          System.Data.OleDb.OleDbCommand myCommand1 = new System.Data.OleDb.OleDbCommand(sql, myConnection);
          OleDb.OleDbCommand comando2 = new OleDb.OleDbCommand();
          comando2.Connection = myConnection;
          myCommand1.ExecuteNonQuery();
          Data.DataTable dt;
          Data.DataRow dr;
          OleDb.OleDbCommand comando = new OleDb.OleDbCommand();
          if ((ddtipoarchivo.SelectedValue != 1))
          {
              dt = movimiento.CrearArchivoFarmacia();
              comando.CommandType = CommandType.Text;
              comando.Connection = myConnection;
              string codosp = "f0008";
              int i;
              int cubre;
              string fecnac;
              foreach (dr in dt.Rows)
              {
                  if ((dr.Item["cubre"] == 1))
                  {
                      cubre = 1;
                  }
                  else
                  {
                      cubre = 0;
                  }

                  fecnac = "";
                  if ((IsDate(dr.Item["fecnac"]) == true))
                  {
                      fecnac = dr.Item["fecnac"];
                  }

                  if ((fecnac != ""))
                  {
                      comando.CommandText = ("INSERT INTO "
                                  + (NombreArchivo + (" (codosp, codpla, nroafi, cubre, fecnac, codsex, NomAfi) VALUES (\'"
                                  + (codosp + ("\', \'"
                                  + (dr.Item["codpla"] + ("\', \'"
                                  + (dr.Item["nroafi"] + ("\', \'"
                                  + (cubre + ("\', \'"
                                  + (fecnac + ("\', \'"
                                  + (dr.Item["codsex"] + ("\', \'"
                                  + (dr.Item["NomAfi"] + "\')"))))))))))))))));
                  }
                  else
                  {
                      comando.CommandText = ("INSERT INTO "
                                  + (NombreArchivo + (" (codosp, codpla, nroafi, cubre, codsex, NomAfi) VALUES (\'"
                                  + (codosp + ("\', \'"
                                  + (dr.Item["codpla"] + ("\', \'"
                                  + (dr.Item["nroafi"] + ("\', \'"
                                  + (cubre + ("\', \'"
                                  + (dr.Item["codsex"] + ("\', \'"
                                  + (dr.Item["NomAfi"] + "\')"))))))))))))));
                  }

                  comando.ExecuteNonQuery();
                  i = (i + 1);
              }

              myConnection.Close();
          }*/

    }

    protected void btnPrueba_Click(object sender, EventArgs e)
    {
        string savePath = @"c:\temp\uploads";

        if (FileUpload1.HasFile)
        {
            // Get the name of the file to upload.
            string fileName = Server.HtmlEncode(FileUpload1.FileName);

            // Get the extension of the uploaded file.
            string extension = System.IO.Path.GetExtension(fileName);

            // Allow only files with .doc or .xls extensions
            // to be uploaded.
            if ((extension == ".txt"))
            {
                // proceder con la importacion
                string Ruta = '"' + Server.MapPath(FileUpload1.FileName) + '"';
                LiquidacionSueldos.Negocio.NuevoAge1 ocpAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
                lblFechaHoraInicio.Visible = true;
                lblFechaHoraInicio.Text = DateTime.Now.ToString();
                String linea;
                //System.IO.StreamReader archivo = new System.IO.StreamReader(@"c:\test.txt");
                System.IO.StreamReader archivo = new System.IO.StreamReader(@Ruta);

                #region         Verifica si el periodo de liqudiacion ya fue importada
                ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                int ajuste = 5; // Ajuste por nuevo campo de 5 caracteres (puntaje miembro junta)
                int ajustePlantaJacky = 1; // Ajuste por nuevo campo de 1 caracter al principio del archivo

                linea = archivo.ReadLine();
                String mesLiquidacion = linea.Substring(121 + ajustePlantaJacky + ajuste, 2);
                String anioLiquidacion = linea.Substring(123 + ajustePlantaJacky + ajuste, 2);
                String fecha = "01" + "/" + mesLiquidacion + "/" + anioLiquidacion;
                DateTime FechaLiquidacion = Convert.ToDateTime(fecha);
                dt = ocnMenu.LiquidacionObtenerUno(mesLiquidacion + "/" + anioLiquidacion);
                if (dt.Rows.Count == 0)
                {
                    archivo.Close();
                    #endregion

                    #region Lectura de Archivo

                    System.IO.StreamReader archivo2 = new System.IO.StreamReader(@"c:\test.txt");
                    bool codigoBonificacion199 = false;
                    string importeBonificacion199 = "";
                    bool codigoBonificacion601 = false;
                    string importeBonificacion601 = "";
                    bool codigoRiesgoDeVida = false;
                    int siturev_numero;
                    bool ResultadoConversion;

                    while (archivo2.EndOfStream == false)
                    {
                        linea = archivo2.ReadLine();
                        String planta = linea.Substring(0 + ajustePlantaJacky, 1);
                        String nrocontrol = linea.Substring(1 + ajustePlantaJacky, 8);
                        String lugarpago = linea.Substring(9 + ajustePlantaJacky, 5);
                        String escuela = linea.Substring(14 + ajustePlantaJacky, 5);
                        String escalafon = linea.Substring(19 + ajustePlantaJacky, 1);
                        String agrupamiento = linea.Substring(20 + ajustePlantaJacky, 2);
                        String tramo = linea.Substring(22 + ajustePlantaJacky, 1);
                        String apertura = linea.Substring(23 + ajustePlantaJacky, 3);
                        String categoria = linea.Substring(26 + ajustePlantaJacky, 2);
                        String hscatedra = linea.Substring(28 + ajustePlantaJacky, 2);
                        //UNIDAD PRESUPUESTARIA
                        String jurisdiccion = linea.Substring(30 + ajustePlantaJacky, 2);
                        String programa = linea.Substring(32 + ajustePlantaJacky, 2);
                        String subprograma = linea.Substring(34 + ajustePlantaJacky, 2);
                        String actividad = linea.Substring(36 + ajustePlantaJacky, 2);
                        //AGENTE
                        String nombre = linea.Substring(38 + ajustePlantaJacky, 25);
                        String prefijo = linea.Substring(63 + ajustePlantaJacky, 2);
                        String numero = linea.Substring(65 + ajustePlantaJacky, 8);
                        String sufijo = linea.Substring(73 + ajustePlantaJacky, 1);
                        String tipodocumento = linea.Substring(74 + ajustePlantaJacky, 1);
                        String fechanacimiento = linea.Substring(75 + ajustePlantaJacky, 6);
                        String sexo = linea.Substring(81 + ajustePlantaJacky, 1);
                        String estadocivil = linea.Substring(82 + ajustePlantaJacky, 1);
                        String fechaingreso = linea.Substring(83 + ajustePlantaJacky, 6);
                        //ANTIGUEDAD RECONOCIDA
                        String anios = linea.Substring(89 + ajustePlantaJacky, 2);
                        String meses = linea.Substring(91 + ajustePlantaJacky, 1);
                        String diasmultaantiguedad = linea.Substring(92 + ajustePlantaJacky, 3);
                        String aniosantiguedad = linea.Substring(95 + ajustePlantaJacky, 2);
                        String permanenciaEnElCargo = linea.Substring(97 + ajustePlantaJacky, 2);
                        String nroCarnetIosep = linea.Substring(99 + ajustePlantaJacky, 7);
                        String aporteIosep = linea.Substring(106 + ajustePlantaJacky, 1);
                        String aporteOSocNacional = linea.Substring(107 + ajustePlantaJacky, 1);
                        String jubilado = linea.Substring(108 + ajustePlantaJacky, 1);
                        String aporteprevisional = linea.Substring(109 + ajustePlantaJacky, 2);
                        String situacionRevista = linea.Substring(111 + ajustePlantaJacky, 1);
                        String interinato = linea.Substring(112 + ajustePlantaJacky, 1);
                        String situacionRevistaDocente = linea.Substring(113 + ajustePlantaJacky, 1);
                        //int ajuste = 5; espacio por nuevo campo (puntaje miembro junta)
                        String noPresentismoNoRiesgo = linea.Substring(114 + ajustePlantaJacky + ajuste, 1);
                        String fechabaja = linea.Substring(115 + ajustePlantaJacky + ajuste, 6);

                        //PERIODO DE LIQUIDACION
                        mesLiquidacion = linea.Substring(121 + ajustePlantaJacky + ajuste, 2);
                        anioLiquidacion = linea.Substring(123 + ajustePlantaJacky + ajuste, 2);

                        String diasTrabajados = linea.Substring(125 + ajustePlantaJacky + ajuste, 3);
                        String imponibleParaAnses = linea.Substring(128 + ajustePlantaJacky + ajuste, 6) + //enteros
                                                    '.' + linea.Substring(134 + ajustePlantaJacky + ajuste, 2).Replace(' ', '0'); //decimales

                        String imponible = linea.Substring(136 + ajustePlantaJacky + ajuste, 6) + //Enteros
                                        '.' + linea.Substring(142 + ajustePlantaJacky + ajuste, 2); //Decimales

                        String haberSinAporte = linea.Substring(144 + ajustePlantaJacky + ajuste, 7)
                            + '.' + linea.Substring(151 + ajustePlantaJacky + ajuste, 2);
                        String haberConAporte = linea.Substring(153 + ajustePlantaJacky + ajuste, 7)
                            + '.' + linea.Substring(160 + ajustePlantaJacky + ajuste, 2);
                        String totalHaberes = linea.Substring(162 + ajustePlantaJacky + ajuste, 7)
                            + '.' + linea.Substring(169 + ajustePlantaJacky + ajuste, 2);
                        String totalDescuentos = linea.Substring(171 + ajustePlantaJacky + ajuste, 7)
                            + '.' + linea.Substring(178 + ajustePlantaJacky + ajuste, 2);
                        String liquido = linea.Substring(180 + ajustePlantaJacky + ajuste, 7)
                            + '.' + linea.Substring(187 + ajustePlantaJacky + ajuste, 2);
                        String cantidadItemsOcupados = linea.Substring(189 + ajustePlantaJacky + ajuste, 2);
                        String codBonifDescto2 = "";
                        String importe = "";
                        #endregion

                        #region Objeto Agente
                        ocpAgente.CantItemsOcupados = cantidadItemsOcupados;
                        ocpAgente.Actividad = actividad;
                        ocpAgente.Ad_Prof_Perm_cgo = permanenciaEnElCargo;
                        ocpAgente.Agru = agrupamiento;
                        ocpAgente.Anios = anios;
                        ocpAgente.AniosAntig = aniosantiguedad;
                        ocpAgente.Apertura = apertura;
                        ocpAgente.AporteIOSEP = aporteIosep;
                        ocpAgente.AporteOsocNac = aporteOSocNacional;
                        ocpAgente.AportePrevisional = aporteprevisional;
                        ocpAgente.Categoria = categoria;
                        ocpAgente.Cuil = prefijo + numero + sufijo;
                        ocpAgente.DiasMultaAntig = diasmultaantiguedad;
                        ocpAgente.DiasTrabajados = diasTrabajados;
                        ocpAgente.Escalafon = escalafon;
                        ocpAgente.Escuela = escuela;
                        ocpAgente.EstadoCivil = estadocivil;
                        ocpAgente.FechaBaja = fechabaja;
                        ocpAgente.FechaIngreso = fechaingreso;
                        ocpAgente.FechaNac = fechanacimiento;
                        ocpAgente.HaberC_aporte = haberConAporte;
                        ocpAgente.HaberS_aporte = haberSinAporte;
                        ocpAgente.HsCat = hscatedra;
                        ocpAgente.Imponible = imponible;
                        ocpAgente.ImponibleANSES = imponibleParaAnses;
                        ocpAgente.Interinato = interinato;
                        ocpAgente.Jubilado = jubilado;
                        ocpAgente.Juris = jurisdiccion;
                        ocpAgente.Liquido = liquido;
                        ocpAgente.LugarPago = lugarpago;
                        ocpAgente.MesAnioLiq = mesLiquidacion + "/" + anioLiquidacion;
                        ocpAgente.Meses = meses;
                        ocpAgente.Nombre = nombre;
                        if (ocpAgente.Nombre.IndexOf('�') != -1)
                        {
                            ocpAgente.Nombre = ocpAgente.Nombre.Replace('�', 'Ñ');
                        }
                        ocpAgente.Nopres_RiesgoVida = noPresentismoNoRiesgo;
                        ocpAgente.NroCOntrol = nrocontrol;
                        ocpAgente.NumeroCarnet = nroCarnetIosep;
                        ocpAgente.PlantaTipo = planta;
                        ocpAgente.Prog = programa;
                        ocpAgente.Sexo = sexo;
                        ocpAgente.SituRev = situacionRevista;
                        ocpAgente.SituRevDoc = situacionRevistaDocente;
                        ocpAgente.SubP = subprograma;
                        ocpAgente.TipoDOc = tipodocumento;
                        ocpAgente.TotalDescuentos = totalDescuentos;
                        ocpAgente.TotalHaberes = totalHaberes;
                        ocpAgente.tramo = tramo;
                        ocpAgente.FechaLiquidacion = FechaLiquidacion;
                        ocpAgente.Legajo = linea.Substring(797, 7);
                        ocpAgente.Activo = 1;
                        #endregion

                        int id = ocpAgente.Insertar();

                        #region Conceptos                
                        int cant = 191 + ajuste + ajustePlantaJacky; //numero donde comienzan los conceptos.
                        codigoBonificacion199 = false;
                        importeBonificacion199 = "";
                        codigoBonificacion601 = false;
                        importeBonificacion601 = "";
                        codigoRiesgoDeVida = false;
                        for (int i = 1; i <= Convert.ToInt32(cantidadItemsOcupados); i++)
                        {
                            codBonifDescto2 = linea.Substring(cant, 3);
                            cant = cant + 3; //comienza importe que tiene 7 enteros y 2 decimales
                            importe = linea.Substring(cant, 7);
                            cant = cant + 7;
                            importe = importe + '.' + linea.Substring(cant, 2);
                            cant = cant + 2;

                            if (Convert.ToInt32(codBonifDescto2) == 199)
                            {
                                codigoBonificacion199 = true;
                                importeBonificacion199 = importe;
                            }
                            if (Convert.ToInt32(codBonifDescto2) == 601)
                            {
                                codigoBonificacion601 = true;
                                importeBonificacion601 = importe;
                            }

                            if ((Convert.ToInt32(codBonifDescto2) == 045) || (Convert.ToInt32(codBonifDescto2) == 052))
                            {
                                codigoRiesgoDeVida = true;
                            }

                            ocpAgente.InsertarCodBonificacionImporte(id, codBonifDescto2, importe);
                        }
                        ocpAgente.CalcularHaberes(id);

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //ASISTENCIA PERFECTA
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

                        if (codigoBonificacion199 == false)
                        {
                            ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                        }
                        else
                        {
                            if (codigoBonificacion601 == false)
                            {
                                //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1
                                ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                            }
                            else //EXISTEN AMBOS CODIGOS  -> VEO LOS VALORES
                            {
                                if (importeBonificacion199 == importeBonificacion601) //SE LE SUMA Y RESTA EL MISMO VALOR. NO COBRA
                                {
                                    //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                                    ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                                }
                                else //VALORES DISTINTOS. CONSULTO SIT. REVISTA
                                {
                                    //VERIFICO SI ES VACIO O NULO -> SI COBRA
                                    if (String.IsNullOrEmpty(ocpAgente.SituRev.Trim()))
                                    {
                                        //    //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1
                                        //    //INSERTAR EN UNA TABLA AUXILIAR PARA VERIFICAR CASOS 
                                        ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                        ocpAgente.InsertarAgenteRevision(id);
                                    }
                                    else //VERIFICO SI ES UN NUMERO O LETRA
                                    {
                                        ResultadoConversion = Int32.TryParse(ocpAgente.SituRev, out siturev_numero);
                                        if (ResultadoConversion)
                                        {
                                            if ((siturev_numero == 4) || (siturev_numero == 5) ||
                                                   (siturev_numero == 6) || (siturev_numero == 7))
                                            {
                                                //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                                                ocpAgente.ActualizarAsistenciaPerfecta(id, 0);
                                            }
                                            else
                                            {
                                                //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 1 - REVISAR CASO
                                                ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                                ocpAgente.InsertarAgenteRevision(id);
                                            }
                                        }
                                        else
                                        {
                                            //UPDATE AL CAMPO ASISTENCIA PERFECTA CON VALOR 0
                                            ocpAgente.ActualizarAsistenciaPerfecta(id, 1);
                                            ocpAgente.InsertarAgenteRevision(id);
                                        }
                                    }
                                }
                            }
                        }

                        #region Riesgo de Vida
                        //DETERMINA CAMPO RIESGO DE VIDA
                        if (codigoRiesgoDeVida == true)
                        {
                            //UPDATE AL CAMPO RIESGO DE VIDA CON 1
                            ocpAgente.ActualizarRiesgoDeVida(id, 1);
                        }
                        else
                        {
                            //UPDATE AL CAMPO RIESGO DE VIDA CON 0
                            ocpAgente.ActualizarRiesgoDeVida(id, 0);
                        }
                        #endregion

                        #region Jubilado o Retencion Activo
                        //JUBILADO O RETENCION ACTIVO
                        if (ocpAgente.Jubilado == "R")
                        {
                            ocpAgente.ActualizarJubRetActivo(id, 1);
                        }
                        else
                        {
                            ocpAgente.ActualizarJubRetActivo(id, 0);
                        }
                        #endregion
                    }
                    archivo2.Close();
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "Importacion realizada correctamente";
                    lblFechaHoraFin.Visible = true;
                    lblFechaHoraFin.Text = DateTime.Now.ToString();
                    #endregion
                }
                // EL ARCHIVO YA FUE IMPORTADO
                else
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "El periodo de liqudiacion ya fue importado !!";
                }
                // ELSE DE VALIDACIONES
            }
            else
            {
                lblArchivoLiquidacion.ForeColor = System.Drawing.Color.Red;
                lblArchivoLiquidacion.Text = "El archivo debe tener extension .txt";
            }
        }
        else
        {
            lblArchivoLiquidacion.ForeColor = System.Drawing.Color.Red;
            lblArchivoLiquidacion.Text = "Debe seleccionar un archivo de Liquidacion";
        }
    }

    protected void btn_generar_arch_ext_doc_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.ArchivoExtDocEducacion archivosEducacion = new LiquidacionSueldos.Negocio.ArchivoExtDocEducacion();
        int liqID = Convert.ToInt32(txt_liqID.Text);
        archivosEducacion.Generar(liqID);
    }

    protected void btn_importar_pagos_eventuales_Click(object sender, EventArgs e)
    {
        string directoryPath = @"c:\temp\pagos_eventuales";
        //string directoryPath = @"C: \Users\Stefano\Desktop\SistemaNovedades\SistemaNovedades\Pagos Eventuales realizados\Enviado por Mail Maria";

        //string[] files = Directory.GetFiles(directoryPath);
        string[] files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            String linea;
            System.IO.StreamReader archivo = new System.IO.StreamReader(file);

            while (archivo.EndOfStream == false)
            {
                linea = archivo.ReadLine();
                if (linea.Length <= 0)
                    break;

                String nombre = linea.Substring(0, 24);
                String dni = linea.Substring(25, 8);
                String lugar_pago = linea.Substring(33, 5);
                //int ceros = 65;
                String importe = linea.Substring(103, 7)
                        + '.' + linea.Substring(110, 2);
                //int ceros2 = 6;
                float importe_float = float.Parse(importe, CultureInfo.InvariantCulture.NumberFormat);
                string cuit = linea.Substring(118, 11);
                string sexo = linea.Substring(129, 1);
                string concepto = txt_concepto.Text;
                string nombre_archivo = Path.GetFileName(file);

                LiquidacionSueldos.Negocio.PagosEventualesBanco pagosEventuales = new LiquidacionSueldos.Negocio.PagosEventualesBanco();
                pagosEventuales.InsertarBanco(nombre, dni, lugar_pago, importe_float, cuit, sexo, concepto, file, nombre_archivo);
            }
        }
    }

}


