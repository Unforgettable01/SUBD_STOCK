using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockDatabaseImplement
{
    public partial class stockContext : DbContext
    {
        public stockContext()
        {
        }

        public stockContext(DbContextOptions<stockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<НакладнаяПроданнойПродукции> НакладнаяПроданнойПродукции { get; set; }
        public virtual DbSet<Покупатель> Покупатель { get; set; }
        public virtual DbSet<ПриходнаяНакладная> ПриходнаяНакладная { get; set; }
        public virtual DbSet<Продукция> Продукция { get; set; }
        public virtual DbSet<ПродукцияНакладнаяПп> ПродукцияНакладнаяПп { get; set; }
        public virtual DbSet<ПродукцияПриходнаяНакладная> ПродукцияПриходнаяНакладная { get; set; }
        public virtual DbSet<Сотрудник> Сотрудник { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Директива #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.0.197;Port=5432;Database=stock;Username=postgres;Password=0000");
#pragma warning restore CS1030 // Директива #warning
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<НакладнаяПроданнойПродукции>(entity =>
            {
                entity.ToTable("накладная_проданной_продукции");

                entity.HasComment("Информация для продажи продукта");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id наклданой проданной продукции")
                    .ValueGeneratedNever();

                entity.Property(e => e.ДатаПродажи)
                    .IsRequired()
                    .HasColumnName("Дата_продажи")
                    .HasMaxLength(10)
                    .HasComment("Дата продажи продукта");

                entity.Property(e => e.Покупательid).HasComment("id покупателя");

                entity.Property(e => e.Сотрудникid).HasComment(@"id сотрудника");

                entity.Property(e => e.Телефон).HasComment("Номер телефона для связи с покупателем");

                entity.HasOne(d => d.Покупатель)
                    .WithMany(p => p.НакладнаяПроданнойПродукции)
                    .HasForeignKey(d => d.Покупательid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("накладная_проданно_Покупательid_fkey");

                entity.HasOne(d => d.Сотрудник)
                    .WithMany(p => p.НакладнаяПроданнойПродукции)
                    .HasForeignKey(d => d.Сотрудникid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("накладная_проданной_Сотрудникid_fkey");
            });

            modelBuilder.Entity<Покупатель>(entity =>
            {
                entity.ToTable("покупатель");

                entity.HasComment("Таблица с информацией о покупателе");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id покупателя")
                    .ValueGeneratedNever();

                entity.Property(e => e.Телефон).HasComment("Номер телефона покупателя для связи");

                entity.Property(e => e.Фио)
                    .IsRequired()
                    .HasColumnName("ФИО")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Неизвестный пользователь'::character varying")
                    .HasComment("ФИО покупателя");
            });

            modelBuilder.Entity<ПриходнаяНакладная>(entity =>
            {
                entity.ToTable("приходная_накладная");

                entity.HasComment("учитывается продукция, поступившая на склад");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id приходной")
                    .ValueGeneratedNever();

                entity.Property(e => e.ДатаПоступления)
                    .HasColumnName("Дата_поступления")
                    .HasColumnType("date")
                    .HasComment("Дата поступления продукта");

                entity.Property(e => e.Сотрудникid).HasComment("id сотрудника");

                entity.HasOne(d => d.Сотрудник)
                    .WithMany(p => p.ПриходнаяНакладная)
                    .HasForeignKey(d => d.Сотрудникid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("приходная_накладная_Сотрудникid_fkey");
            });

            modelBuilder.Entity<Продукция>(entity =>
            {
                entity.ToTable("продукция");

                entity.HasComment("Информация о продукте");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id продукта")
                    .ValueGeneratedNever();

                entity.Property(e => e.Название)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Неизвестный продукт'::character varying")
                    .HasComment("Название продукта");

                entity.Property(e => e.Цена).HasComment("Цена продукта");
            });

            modelBuilder.Entity<ПродукцияНакладнаяПп>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("продукция_накладная_пп");

                entity.HasComment("Таблица контроля проданной продукции");

                entity.Property(e => e.КоличествоПроданнойПродукции)
                    .HasColumnName("Количество_проданной_продукции")
                    .HasComment("Количество проданной продукции");

                entity.Property(e => e.НакладнаяПроданнойПродукцииid)
                    .HasColumnName("Накладная_проданной_продукцииid")
                    .HasComment("id накладной проданной продукции");

                entity.Property(e => e.Продукцияid).HasComment("id продукции");

                entity.HasOne(d => d.НакладнаяПроданнойПродукции)
                    .WithMany()
                    .HasForeignKey(d => d.НакладнаяПроданнойПродукцииid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("продукция_накл_Накладная_прод_fkey1");

                entity.HasOne(d => d.Продукция)
                    .WithMany()
                    .HasForeignKey(d => d.Продукцияid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("продукция_накладна_Продукцияid_fkey1");
            });

            modelBuilder.Entity<ПродукцияПриходнаяНакладная>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("продукция_приходная_накладная");

                entity.HasComment("Таблица контроля поступаемой продукции");

                entity.Property(e => e.КоличествоПроданнойПродукции)
                    .HasColumnName("Количество_проданной_продукции")
                    .HasComment("Количество проданной продукции");

                entity.Property(e => e.ПриходнаяНакладнаяid)
                    .HasColumnName("Приходная_накладнаяid")
                    .HasComment("id приходной накладной");

                entity.Property(e => e.Продукцияid).HasComment("id продукции");

                entity.HasOne(d => d.ПриходнаяНакладная)
                    .WithMany()
                    .HasForeignKey(d => d.ПриходнаяНакладнаяid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("продукция_прихо_Приходная_накл_fkey");

                entity.HasOne(d => d.Продукция)
                    .WithMany()
                    .HasForeignKey(d => d.Продукцияid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("продукция_приходная_Продукцияid_fkey");
            });

            modelBuilder.Entity<Сотрудник>(entity =>
            {
                entity.ToTable("сотрудник");

                entity.HasComment("таблица информации о сотруднике");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id сотрудника")
                    .ValueGeneratedNever();

                entity.Property(e => e.Логин)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("Логин от личного кабинета для сотрудника");

                entity.Property(e => e.Пароль).HasComment("Пароль от личного кабинета для сотрудника");

                entity.Property(e => e.Телефон).HasComment("Телефон сотрудника");

                entity.Property(e => e.Фио)
                    .HasColumnName("ФИО")
                    .HasMaxLength(255)
                    .HasComment("ФИО сотрудника");
            });

            modelBuilder.HasSequence("накладная_проданной_продукции_id_seq");

            modelBuilder.HasSequence("покупатель_id_seq");

            modelBuilder.HasSequence("приходная_накладная_id_seq");

            modelBuilder.HasSequence("продукция_id_seq");

            modelBuilder.HasSequence("сотрудник_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
