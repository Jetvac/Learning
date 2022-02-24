using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class LearningContext : DbContext
    {
        public LearningContext()
        {
        }

        public LearningContext(DbContextOptions<LearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<CompletedCourse> CompletedCourses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTheme> CourseThemes { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<EducationOrganisation> EducationOrganisations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDiscipline> EmployeeDisciplines { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleDiscipline> ScheduleDisciplines { get; set; }
        public virtual DbSet<StudentList> StudentLists { get; set; }
        public virtual DbSet<StudyClass> StudyClasses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Learning;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.ToTable("ClassRoom");

                entity.Property(e => e.ClassRoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClassRoomID");

                entity.Property(e => e.ClassRoomNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CompletedCourse>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.CourseId });

                entity.ToTable("CompletedCourse");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Certificate).IsRequired();

                entity.Property(e => e.CourseEndDate).HasColumnType("date");

                entity.Property(e => e.CourseName).IsRequired();

                entity.Property(e => e.CourseStartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CompletedCourses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompletedCourse_Employee");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.EducationOrganisationId });

                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EducationOrganisationId).HasColumnName("EducationOrganisationID");

                entity.Property(e => e.CourseEndDate).HasColumnType("date");

                entity.Property(e => e.CourseName).IsRequired();

                entity.Property(e => e.CourseStartDate).HasColumnType("date");

                entity.HasOne(d => d.EducationOrganisation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.EducationOrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_EducationOrganisation");
            });

            modelBuilder.Entity<CourseTheme>(entity =>
            {
                entity.HasKey(e => new { e.EducationOrganisationId, e.CourseId, e.ThemeId });

                entity.ToTable("CourseTheme");

                entity.Property(e => e.EducationOrganisationId).HasColumnName("EducationOrganisationID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseThemes)
                    .HasForeignKey(d => new { d.CourseId, d.EducationOrganisationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseTheme_Course");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.ToTable("Discipline");

                entity.Property(e => e.DisciplineId).HasColumnName("DisciplineID");

                entity.Property(e => e.DisciplineName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EducationOrganisation>(entity =>
            {
                entity.ToTable("EducationOrganisation");

                entity.Property(e => e.EducationOrganisationId)
                    .ValueGeneratedNever()
                    .HasColumnName("EducationOrganisationID");

                entity.Property(e => e.EducationOrganisationName).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EducationOrganisationId).HasColumnName("EducationOrganisationID");

                entity.Property(e => e.EmployeeBirthdate).HasColumnType("date");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EmployeeFullname).IsRequired();

                entity.Property(e => e.EmployeePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.EducationOrganisation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EducationOrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EducationOrganisation");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Gender__4F7CD00D");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__PostID__5070F446");
            });

            modelBuilder.Entity<EmployeeDiscipline>(entity =>
            {
                entity.ToTable("EmployeeDiscipline");

                entity.Property(e => e.EmployeeDisciplineId).HasColumnName("EmployeeDisciplineID");

                entity.Property(e => e.DisciplineId).HasColumnName("DisciplineID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.EmployeeDisciplines)
                    .HasForeignKey(d => d.DisciplineId)
                    .HasConstraintName("FK__EmployeeD__Disci__59063A47");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDisciplines)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeD__Emplo__5812160E");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ScheduleID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.StudyClassId).HasColumnName("StudyClassID");

                entity.Property(e => e.WeekDayId).HasColumnName("WeekDayID");

                entity.HasOne(d => d.StudyClass)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.StudyClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__StudyC__5BE2A6F2");

                entity.HasOne(d => d.WeekDay)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.WeekDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__WeekDa__5CD6CB2B");
            });

            modelBuilder.Entity<ScheduleDiscipline>(entity =>
            {
                entity.ToTable("ScheduleDiscipline");

                entity.Property(e => e.ScheduleDisciplineId)
                    .ValueGeneratedNever()
                    .HasColumnName("ScheduleDisciplineID");

                entity.Property(e => e.ClassRoomId).HasColumnName("ClassRoomID");

                entity.Property(e => e.DisciplineId).HasColumnName("DisciplineID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.ScheduleDisciplines)
                    .HasForeignKey(d => d.ClassRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleDiscipline_ClassRoom");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.ScheduleDisciplines)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleDiscipline_Discipline");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.ScheduleDisciplines)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleDiscipline_Schedule");
            });

            modelBuilder.Entity<StudentList>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.EmployeeId, e.EducationOrganisationId });

                entity.ToTable("StudentList");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EducationOrganisationId).HasColumnName("EducationOrganisationID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StudentLists)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentList_Employee");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentLists)
                    .HasForeignKey(d => new { d.CourseId, d.EducationOrganisationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentList_Course");
            });

            modelBuilder.Entity<StudyClass>(entity =>
            {
                entity.ToTable("StudyClass");

                entity.Property(e => e.StudyClassId).HasColumnName("StudyClassID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.StudyClassNumber)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StudyClasses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudyClas__Emplo__534D60F1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("User");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Employee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.ToTable("WeekDay");

                entity.Property(e => e.WeekDayId).HasColumnName("WeekDayID");

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
