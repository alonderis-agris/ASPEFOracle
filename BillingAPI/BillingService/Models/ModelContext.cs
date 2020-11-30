using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BillingService.Models
{
    public partial class ModelContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BBilling> BBilling { get; set; }
        public virtual DbSet<BGateway> BGateway { get; set; }
        public virtual DbSet<BUser> BUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(Configuration.GetConnectionString("OracleDbCs"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "SYS");

            modelBuilder.Entity<BBilling>(entity =>
            {
                entity.ToTable("B_BILLING");

                entity.HasIndex(e => e.BGatewayId)
                    .HasName("B_BILLING_GATEWAY_ID_INDX");

                entity.HasIndex(e => e.BUserId)
                    .HasName("B_BILLING_USER_ID_INDX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.BGatewayId)
                    .HasColumnName("B_GATEWAY_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.BUserId)
                    .HasColumnName("B_USER_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasColumnName("ORDER_NUMBER")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.BGateway)
                    .WithMany(p => p.BBilling)
                    .HasForeignKey(d => d.BGatewayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("B_GATEWAY_ID_FK");

                entity.HasOne(d => d.BUser)
                    .WithMany(p => p.BBilling)
                    .HasForeignKey(d => d.BUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("B_USER_ID_FK");
            });

            modelBuilder.Entity<BGateway>(entity =>
            {
                entity.ToTable("B_GATEWAY");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BUser>(entity =>
            {
                entity.ToTable("B_USER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("PWD")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("ADO_IMCSEQ$");

            modelBuilder.HasSequence("APP$SYSTEM$SEQ");

            modelBuilder.HasSequence("APPLY$_DEST_OBJ_ID");

            modelBuilder.HasSequence("APPLY$_ERROR_HANDLER_SEQUENCE");

            modelBuilder.HasSequence("APPLY$_SOURCE_OBJ_ID");

            modelBuilder.HasSequence("AQ$_ALERT_QT_N");

            modelBuilder.HasSequence("AQ$_AQ$_MEM_MC_N");

            modelBuilder.HasSequence("AQ$_AQ_PROP_TABLE_N");

            modelBuilder.HasSequence("AQ$_CHAINSEQ");

            modelBuilder.HasSequence("AQ$_IOTENQTXID");

            modelBuilder.HasSequence("AQ$_NONDURSUB_SEQUENCE");

            modelBuilder.HasSequence("AQ$_ORA$PREPLUGIN_BACKUP_QTB_N");

            modelBuilder.HasSequence("AQ$_PDB_MON_EVENT_QTABLE$_N");

            modelBuilder.HasSequence("AQ$_PROPAGATION_SEQUENCE");

            modelBuilder.HasSequence("AQ$_PUBLISHER_SEQUENCE");

            modelBuilder.HasSequence("AQ$_RULE_SEQUENCE");

            modelBuilder.HasSequence("AQ$_RULE_SET_SEQUENCE");

            modelBuilder.HasSequence("AQ$_SCHEDULER$_EVENT_QTAB_N");

            modelBuilder.HasSequence("AQ$_SCHEDULER$_REMDB_JOBQTAB_N");

            modelBuilder.HasSequence("AQ$_SCHEDULER_FILEWATCHER_QT_N");

            modelBuilder.HasSequence("AQ$_SYS$SERVICE_METRICS_TAB_N");

            modelBuilder.HasSequence("AQ$_TRANS_SEQUENCE");

            modelBuilder.HasSequence("AUDSES$");

            modelBuilder.HasSequence("AWCREATE_S$");

            modelBuilder.HasSequence("AWCREATE10G_S$");

            modelBuilder.HasSequence("AWLOGSEQ$");

            modelBuilder.HasSequence("AWMD_S$");

            modelBuilder.HasSequence("AWREPORT_S$");

            modelBuilder.HasSequence("AWSEQ$");

            modelBuilder.HasSequence("AWXML_S$");

            modelBuilder.HasSequence("B_BILLING_SEQ");

            modelBuilder.HasSequence("B_GATEWAY_SEQ");

            modelBuilder.HasSequence("B_USERS_SEQ");

            modelBuilder.HasSequence("CACHE_STATS_SEQ_0");

            modelBuilder.HasSequence("CACHE_STATS_SEQ_1");

            modelBuilder.HasSequence("CDC_RSID_SEQ$");

            modelBuilder.HasSequence("CHNF$_CLAUSEID_SEQ");

            modelBuilder.HasSequence("CHNF$_QUERYID_SEQ");

            modelBuilder.HasSequence("CLI_ID$");

            modelBuilder.HasSequence("COMPARISON_SCAN_SEQ$");

            modelBuilder.HasSequence("COMPARISON_SEQ$");

            modelBuilder.HasSequence("CONFLICT_HANDLER_ID_SEQ$");

            modelBuilder.HasSequence("DAM_CLEANUP_SEQ$");

            modelBuilder.HasSequence("DBFS_HS$_ARCHIVEREFIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_BACKUPFILEIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_POLICYIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_RSEQ");

            modelBuilder.HasSequence("DBFS_HS$_STOREIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_TARBALLSEQ");

            modelBuilder.HasSequence("DBFS_SFS$_FSSEQ");

            modelBuilder.HasSequence("DBMS_CUBE_ADVICE_SEQ$");

            modelBuilder.HasSequence("DBMS_LOCK_ID_V2");

            modelBuilder.HasSequence("DBMS_PARALLEL_EXECUTE_SEQ$");

            modelBuilder.HasSequence("DM$EXPIMP_ID_SEQ");

            modelBuilder.HasSequence("EXPRESS_S$");

            modelBuilder.HasSequence("FED$APPID_SEQ");

            modelBuilder.HasSequence("FED$SESS_SEQ");

            modelBuilder.HasSequence("FED$STMT_SEQ");

            modelBuilder.HasSequence("FGR$_NAMES_S");

            modelBuilder.HasSequence("GROUP_NUM_SEQ");

            modelBuilder.HasSequence("HS$_BASE_DD_S");

            modelBuilder.HasSequence("HS$_CLASS_CAPS_S");

            modelBuilder.HasSequence("HS$_CLASS_DD_S");

            modelBuilder.HasSequence("HS$_CLASS_INIT_S");

            modelBuilder.HasSequence("HS$_FDS_CLASS_S");

            modelBuilder.HasSequence("HS$_FDS_INST_S");

            modelBuilder.HasSequence("HS$_INST_CAPS_S");

            modelBuilder.HasSequence("HS$_INST_DD_S");

            modelBuilder.HasSequence("HS$_INST_INIT_S");

            modelBuilder.HasSequence("HS_BULK_SEQ");

            modelBuilder.HasSequence("IDGEN1$");

            modelBuilder.HasSequence("IDX_RB$JOBSEQ");

            modelBuilder.HasSequence("ILM_EXECUTIONID");

            modelBuilder.HasSequence("ILM_SEQ$");

            modelBuilder.HasSequence("IM_DOMAINSEQ$");

            modelBuilder.HasSequence("INVALIDATION_REG_ID$");

            modelBuilder.HasSequence("JAVA$JOX$CUJS$SEQUENCE$");

            modelBuilder.HasSequence("JAVA$POLICY$SEQUENCE$");

            modelBuilder.HasSequence("JAVA$PREFS$SEQ$");

            modelBuilder.HasSequence("JOBSEQ");

            modelBuilder.HasSequence("JOBSEQLSBY");

            modelBuilder.HasSequence("LINK_SOURCE_ID_SEQ");

            modelBuilder.HasSequence("LOG$SEQUENCE");

            modelBuilder.HasSequence("MODELALG_SEQ$");

            modelBuilder.HasSequence("MV_RF$JOBSEQ");

            modelBuilder.HasSequence("MV_RF$USAGESTATSEQ");

            modelBuilder.HasSequence("MVREF$_STATS_SEQ");

            modelBuilder.HasSequence("OBJECT_GRANT");

            modelBuilder.HasSequence("OLAP_ASSIGNMENTS_SEQ");

            modelBuilder.HasSequence("OLAP_ATTRIBUTES_SEQ");

            modelBuilder.HasSequence("OLAP_CALCULATED_MEMBERS_SEQ");

            modelBuilder.HasSequence("OLAP_DIM_LEVELS_SEQ");

            modelBuilder.HasSequence("OLAP_DIMENSIONALITY_SEQ");

            modelBuilder.HasSequence("OLAP_HIER_LEVELS_SEQ");

            modelBuilder.HasSequence("OLAP_HIERARCHIES_SEQ");

            modelBuilder.HasSequence("OLAP_MAPPINGS_SEQ");

            modelBuilder.HasSequence("OLAP_MEASURES_SEQ");

            modelBuilder.HasSequence("OLAP_MODELS_SEQ");

            modelBuilder.HasSequence("OLAP_PROPERTIES_SEQ");

            modelBuilder.HasSequence("ORA_PLAN_ID_SEQ$");

            modelBuilder.HasSequence("ORA_TQ_BASE$");

            modelBuilder.HasSequence("PARTITION_NAME$");

            modelBuilder.HasSequence("PCLX_JOBSEQ");

            modelBuilder.HasSequence("PDB_ALERT_SEQUENCE");

            modelBuilder.HasSequence("PLSQL_CODE_COVERAGE_RUNNUMBER");

            modelBuilder.HasSequence("PRIV_CAPTURE_SEQ$");

            modelBuilder.HasSequence("PRIV_UNUSED_ID$");

            modelBuilder.HasSequence("PRIV_USED_ID$");

            modelBuilder.HasSequence("PROFNUM$");

            modelBuilder.HasSequence("PSINDEX_SEQ$");

            modelBuilder.HasSequence("RADM_PE$_SEQ");

            modelBuilder.HasSequence("REDEF_SEQ$");

            modelBuilder.HasSequence("RGROUPSEQ");

            modelBuilder.HasSequence("ROPP$X$KCCAL_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBF_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBI_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBL_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBLKCOR_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBP_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCBS_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCCC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCDC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCDI_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCDI2_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCFC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCFE_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCFN_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCIC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCLE_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCLH_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCOR_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCPC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCPDB_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCPIC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCRSR_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCRT_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCSL_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCTF_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCTIR_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCTKH_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCCTS_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCPDBINC_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCVDF_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCVFH_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCVFHALL_SEQ");

            modelBuilder.HasSequence("ROPP$X$KCVFHTMP_SEQ");

            modelBuilder.HasSequence("RULE_ID_SEQ$");

            modelBuilder.HasSequence("SCHEDULER$_EVTSEQ");

            modelBuilder.HasSequence("SCHEDULER$_INSTANCE_S");

            modelBuilder.HasSequence("SCHEDULER$_JOBSUFFIX_S");

            modelBuilder.HasSequence("SCHEDULER$_LWJOB_OID_SEQ");

            modelBuilder.HasSequence("SCHEDULER$_RDB_SEQ");

            modelBuilder.HasSequence("SNAPSHOT_ID$");

            modelBuilder.HasSequence("SNAPSITE_ID$");

            modelBuilder.HasSequence("SQL_TK_CHK_ID");

            modelBuilder.HasSequence("SQLLOG$_SEQ");

            modelBuilder.HasSequence("SSCR_CAP_SEQ$");

            modelBuilder.HasSequence("ST_OPR_ID_SEQ");

            modelBuilder.HasSequence("STATS_ADVISOR_DIR_SEQ");

            modelBuilder.HasSequence("STREAMS$_APPLY_SPILL_TXNKEY_S");

            modelBuilder.HasSequence("STREAMS$_CAP_SUB_INST");

            modelBuilder.HasSequence("STREAMS$_CAPTURE_INST");

            modelBuilder.HasSequence("STREAMS$_PROPAGATION_SEQNUM");

            modelBuilder.HasSequence("STREAMS$_RULE_NAME_S");

            modelBuilder.HasSequence("STREAMS$_SM_ID");

            modelBuilder.HasSequence("STREAMS$_STMT_HANDLER_SEQ");

            modelBuilder.HasSequence("SYNCREF_GROUP_ID_SEQ$");

            modelBuilder.HasSequence("SYNCREF_STEP_SEQ$");

            modelBuilder.HasSequence("SYNOPSIS_NUM_SEQ");

            modelBuilder.HasSequence("SYSDBIMFSCUID_SEQ$");

            modelBuilder.HasSequence("SYSDBIMFSSEG_SEQ$");

            modelBuilder.HasSequence("SYSLSBY_EDS_DDL_SEQ");

            modelBuilder.HasSequence("SYSTEM_GRANT");

            modelBuilder.HasSequence("TSDP_ASSOCIATION$SEQUENCE");

            modelBuilder.HasSequence("TSDP_POLICY$SEQUENCE");

            modelBuilder.HasSequence("TSDP_POLNAME$SEQUENCE");

            modelBuilder.HasSequence("TSDP_PROTECTION$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SENSITIVE$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SOURCE$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SUBPOL$SEQUENCE");

            modelBuilder.HasSequence("TSDP_TYPE$SEQUENCE");

            modelBuilder.HasSequence("TSM_MIG_SEQ$");

            modelBuilder.HasSequence("UGROUP_SEQUENCE");

            modelBuilder.HasSequence("USER_GRANT");

            modelBuilder.HasSequence("UTL_RECOMP_SEQ");

            modelBuilder.HasSequence("WI$_JOB_ID");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_DIR");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_DIR_INST");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_EXEC");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_JOURNAL");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_MSGGROUP");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_SQLW_QUERY");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_TASK");

            modelBuilder.HasSequence("WRI$_ADV_SQLT_PLAN_SEQ");

            modelBuilder.HasSequence("WRI$_ALERT_SEQUENCE");

            modelBuilder.HasSequence("WRI$_ALERT_THRSLOG_SEQUENCE");

            modelBuilder.HasSequence("WRI$_EMX_FILE_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_COMP_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_FORMAT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_REPT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_RATMASK_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_REF_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_STMT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_WORKSPACE_PLAN_SEQ");

            modelBuilder.HasSequence("WRM$_DEEP_PURGE_INTERVAL");

            modelBuilder.HasSequence("WRP$_REPORT_ID_SEQ");

            modelBuilder.HasSequence("WRR$_CAPTURE_ID");

            modelBuilder.HasSequence("WRR$_REPLAY_ID");

            modelBuilder.HasSequence("WRW_EXP_MAILPKG_SEQ");

            modelBuilder.HasSequence("WRW_IMP_LEGACY_MAILPKG_SEQ");

            modelBuilder.HasSequence("WRW_IMPID_SEQ");

            modelBuilder.HasSequence("XS$ID_SEQUENCE");

            modelBuilder.HasSequence("XSPARAM_REG_SEQUENCE$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
