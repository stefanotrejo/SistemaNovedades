namespace LiquidacionSueldos.Negocio.LiquidacionSueldos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Agente> Agente { get; set; }
        public virtual DbSet<AgenteAdscripcionAfectacion> AgenteAdscripcionAfectacion { get; set; }
        public virtual DbSet<AgenteCargo> AgenteCargo { get; set; }
        public virtual DbSet<AgenteFamiliar> AgenteFamiliar { get; set; }
        public virtual DbSet<AgenteFechaAntiguedad> AgenteFechaAntiguedad { get; set; }
        public virtual DbSet<AgenteLiquidacionCabecera> AgenteLiquidacionCabecera { get; set; }
        public virtual DbSet<AgenteLiquidacionDetalle> AgenteLiquidacionDetalle { get; set; }
        public virtual DbSet<AgenteTitulo> AgenteTitulo { get; set; }
        public virtual DbSet<Agrupamiento> Agrupamiento { get; set; }
        public virtual DbSet<Ayuda> Ayuda { get; set; }
        public virtual DbSet<CargoCategoriaBasico> CargoCategoriaBasico { get; set; }
        public virtual DbSet<CargoCategoriaEscalafon> CargoCategoriaEscalafon { get; set; }
        public virtual DbSet<CargoCategoriaPresupuestado> CargoCategoriaPresupuestado { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<ConceptoAcumulador> ConceptoAcumulador { get; set; }
        public virtual DbSet<ConceptoFrecuencia> ConceptoFrecuencia { get; set; }
        public virtual DbSet<EmailSalida> EmailSalida { get; set; }
        public virtual DbSet<Escalafon> Escalafon { get; set; }
        public virtual DbSet<EscalafonImponible> EscalafonImponible { get; set; }
        public virtual DbSet<EscalafonSituacionRevista> EscalafonSituacionRevista { get; set; }
        public virtual DbSet<Escuela> Escuela { get; set; }
        public virtual DbSet<FinanciamientoTipo> FinanciamientoTipo { get; set; }
        public virtual DbSet<InasistenciaTipo> InasistenciaTipo { get; set; }
        public virtual DbSet<Indice> Indice { get; set; }
        public virtual DbSet<Jurisdiccion> Jurisdiccion { get; set; }
        public virtual DbSet<Liquidacion> Liquidacion { get; set; }
        public virtual DbSet<LugarPago> LugarPago { get; set; }
        public virtual DbSet<LugarPagoEscalafon> LugarPagoEscalafon { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MetaEscalafon> MetaEscalafon { get; set; }
        public virtual DbSet<MotivoBaja> MotivoBaja { get; set; }
        public virtual DbSet<NivelAcademico> NivelAcademico { get; set; }
        public virtual DbSet<NovedadAgenteFamiliar> NovedadAgenteFamiliar { get; set; }
        public virtual DbSet<NovedadConcepto> NovedadConcepto { get; set; }
        public virtual DbSet<NovedadInasistencia> NovedadInasistencia { get; set; }
        public virtual DbSet<PagosEventuales> PagosEventuales { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Parentesco> Parentesco { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilMenu> PerfilMenu { get; set; }
        public virtual DbSet<PlantaTipo> PlantaTipo { get; set; }
        public virtual DbSet<Programa> Programa { get; set; }
        public virtual DbSet<RecuperarClave> RecuperarClave { get; set; }
        public virtual DbSet<SituacionRevista> SituacionRevista { get; set; }
        public virtual DbSet<SubPrograma> SubPrograma { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<UnidadPresupuestaria> UnidadPresupuestaria { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioConectado> UsuarioConectado { get; set; }
        public virtual DbSet<TempDatosLiquidacion> TempDatosLiquidacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agente>()
                .Property(e => e.ageCuil)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.ageTipoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.ageApellidoyNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.ageSexo)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .Property(e => e.ageEstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<Agente>()
                .HasMany(e => e.AgenteFamiliar)
                .WithRequired(e => e.Agente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AgenteFamiliar>()
                .Property(e => e.afaNombreyApellido)
                .IsUnicode(false);

            modelBuilder.Entity<AgenteFamiliar>()
                .Property(e => e.afaSexo)
                .IsUnicode(false);

            modelBuilder.Entity<AgenteFechaAntiguedad>()
                .Property(e => e.afaAntiguedadReconocida)
                .IsUnicode(false);

            modelBuilder.Entity<Agrupamiento>()
                .Property(e => e.agrCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<Agrupamiento>()
                .Property(e => e.agrNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ayuda>()
                .Property(e => e.ayuPaginaNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ayuda>()
                .Property(e => e.ayuDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaEscalafon>()
                .Property(e => e.apertura)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaEscalafon>()
                .Property(e => e.tramo)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaEscalafon>()
                .Property(e => e.lugarpago)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaEscalafon>()
                .Property(e => e.agrupamiento)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaEscalafon>()
                .Property(e => e.esc)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaPresupuestado>()
                .Property(e => e.ccpNombre)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaPresupuestado>()
                .Property(e => e.ccpTramo)
                .IsUnicode(false);

            modelBuilder.Entity<CargoCategoriaPresupuestado>()
                .Property(e => e.ccpApertura)
                .IsUnicode(false);

            modelBuilder.Entity<Concepto>()
                .Property(e => e.conNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Concepto>()
                .Property(e => e.conTipoCalculo)
                .IsUnicode(false);

            modelBuilder.Entity<Concepto>()
                .Property(e => e.conFormula)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSalida>()
                .Property(e => e.esaPara)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSalida>()
                .Property(e => e.esaTipo)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSalida>()
                .Property(e => e.esaTitulo)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSalida>()
                .Property(e => e.esaCuerpo)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSalida>()
                .Property(e => e.esaDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Escalafon>()
                .Property(e => e.escNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Escalafon>()
                .Property(e => e.escCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<Escuela>()
                .Property(e => e.esuNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Escuela>()
                .Property(e => e.esuZona)
                .IsUnicode(false);

            modelBuilder.Entity<FinanciamientoTipo>()
                .Property(e => e.ftiNombre)
                .IsUnicode(false);

            modelBuilder.Entity<FinanciamientoTipo>()
                .Property(e => e.ftiCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<InasistenciaTipo>()
                .Property(e => e.itiNombre)
                .IsUnicode(false);

            modelBuilder.Entity<InasistenciaTipo>()
                .Property(e => e.itiActivo)
                .IsFixedLength();

            modelBuilder.Entity<Jurisdiccion>()
                .Property(e => e.jurCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiccion>()
                .Property(e => e.jurNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Liquidacion>()
                .Property(e => e.liqMes)
                .IsFixedLength();

            modelBuilder.Entity<Liquidacion>()
                .Property(e => e.liqAnio)
                .IsFixedLength();

            modelBuilder.Entity<Liquidacion>()
                .Property(e => e.liqNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Liquidacion>()
                .Property(e => e.liqTipo)
                .IsFixedLength();

            modelBuilder.Entity<LugarPago>()
                .Property(e => e.lpaCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<LugarPago>()
                .Property(e => e.lpaNombre)
                .IsUnicode(false);

            modelBuilder.Entity<LugarPago>()
                .HasMany(e => e.AgenteCargo)
                .WithOptional(e => e.LugarPago)
                .HasForeignKey(e => e.lpeId);

            modelBuilder.Entity<Menu>()
                .Property(e => e.menNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.menUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.menIcono)
                .IsUnicode(false);

            modelBuilder.Entity<MetaEscalafon>()
                .Property(e => e.mesNombre)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoBaja>()
                .Property(e => e.mbaNombre)
                .IsUnicode(false);

            modelBuilder.Entity<NivelAcademico>()
                .Property(e => e.nacNombre)
                .IsUnicode(false);

            modelBuilder.Entity<NivelAcademico>()
                .HasMany(e => e.AgenteFamiliar)
                .WithRequired(e => e.NivelAcademico)
                .HasForeignKey(e => e.nivId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NivelAcademico>()
                .HasMany(e => e.NovedadAgenteFamiliar)
                .WithOptional(e => e.NivelAcademico)
                .HasForeignKey(e => e.nivId);

            modelBuilder.Entity<NovedadAgenteFamiliar>()
                .Property(e => e.nafCuil)
                .IsUnicode(false);

            modelBuilder.Entity<NovedadAgenteFamiliar>()
                .Property(e => e.nafNombreyApellido)
                .IsUnicode(false);

            modelBuilder.Entity<NovedadAgenteFamiliar>()
                .Property(e => e.nafSexo)
                .IsUnicode(false);

            modelBuilder.Entity<NovedadAgenteFamiliar>()
                .Property(e => e.nafEstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<Parametro>()
                .Property(e => e.parNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Parametro>()
                .Property(e => e.parValor)
                .IsUnicode(false);

            modelBuilder.Entity<Parentesco>()
                .Property(e => e.parNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Parentesco>()
                .HasMany(e => e.AgenteFamiliar)
                .WithRequired(e => e.Parentesco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parentesco>()
                .HasOptional(e => e.NovedadAgenteFamiliar)
                .WithRequired(e => e.Parentesco);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.perNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.perDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PlantaTipo>()
                .Property(e => e.ptiNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Programa>()
                .Property(e => e.jurCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<Programa>()
                .Property(e => e.proCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<Programa>()
                .Property(e => e.proNombre)
                .IsUnicode(false);

            modelBuilder.Entity<RecuperarClave>()
                .Property(e => e.rclUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<RecuperarClave>()
                .Property(e => e.rclEmailRecuperacion)
                .IsUnicode(false);

            modelBuilder.Entity<RecuperarClave>()
                .Property(e => e.rclUsuarioEncriptado)
                .IsUnicode(false);

            modelBuilder.Entity<RecuperarClave>()
                .Property(e => e.rclEmailRecuperacionEncriptado)
                .IsUnicode(false);

            modelBuilder.Entity<SituacionRevista>()
                .Property(e => e.sreNombre)
                .IsUnicode(false);

            modelBuilder.Entity<SubPrograma>()
                .Property(e => e.sprCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<SubPrograma>()
                .Property(e => e.sprNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.titNombre)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadPresupuestaria>()
                .Property(e => e.uprCodigo)
                .IsUnicode(false);

            modelBuilder.Entity<UnidadPresupuestaria>()
                .Property(e => e.uprActividad)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuApellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuNombreIngreso)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuClave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuClaveProvisoria)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuEmail)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioConectado>()
                .Property(e => e.ucoGuid)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioConectado>()
                .Property(e => e.ucoIpPublica)
                .IsUnicode(false);

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlAnio)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlMes)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlNombre)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlPrefijoDoc)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlPlanta)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlNroControl)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlJurisdicionId)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlLugarPid)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlEscuelaId)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlCargoId)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlCategoria)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlHorasCat)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlDiasTraba)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlAntiguedad)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlAntiReconocida)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlSituRevista)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlInterinato)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlPreseNoRiesgo)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlJuviladoActi)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlCajaPrevi)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlHaberImpo)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlHaberRemu)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlHaberNoRemu)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlSalario)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlLiqId)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlFechaAlta)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlUsuId)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlEscCodigo)
                .IsFixedLength();

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlSalarioFamilia)
                .IsUnicode(false);

            modelBuilder.Entity<TempDatosLiquidacion>()
                .Property(e => e.tdlNuevoTotalHaberes)
                .IsUnicode(false);
        }
    }
}
