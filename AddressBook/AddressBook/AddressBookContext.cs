namespace AddressBook
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AddressBookContext : DbContext
    {
        // Контекст настроен для использования строки подключения "AddressBookContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "AddressBook.AddressBookContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AddressBookContext" 
        // в файле конфигурации приложения.
        public AddressBookContext()
            : base("name=AddressBookContext")
        {
            Database.CreateIfNotExists();
        }
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Subscriber> Subscribers { get; set; }
        //public virtual DbSet<GroupPhone> GroupPhones { get; set; }
        //public virtual DbSet<GroupAddress> GroupAddresses { get; set; }
        //public virtual DbSet<Group> Groups { get; set; }


        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("UsersTable").HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasMany(u => u.SubscriberInternal).WithRequired(s => s.User).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<User>().HasMany(u => u.GroupAddressInternal).WithRequired(s => s.User).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<User>().HasMany(u => u.GroupInternal).WithRequired(s => s.User).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<User>().HasMany(u => u.GroupPhoneInternal).WithRequired(s => s.User).HasForeignKey(s => s.UserId);

            //modelBuilder.Entity<Subscriber>().ToTable("SubscribersTable").HasKey(s => s.Id);
            //modelBuilder.Entity<GroupPhone>().ToTable("GroupPhonesTable").HasKey(gp => gp.Id);
            //modelBuilder.Entity<GroupAddress>().ToTable("GroupAddressesTable").HasKey(ga => ga.Id);
            //modelBuilder.Entity<Group>().ToTable("GroupsTable").HasKey(g => g.Id);

            modelBuilder.Entity<Phone>().ToTable("PhoneTable").HasKey(p => p.Id);
            modelBuilder.Entity<Address>().ToTable("AddressTable").HasKey(a => a.Id);

            modelBuilder.Entity<Subscriber>().Ignore(s => s.Addresses);
            modelBuilder.Entity<Subscriber>().Ignore(s => s.Phones);
            modelBuilder.Entity<Subscriber>().Ignore(s => s.Groups);

            modelBuilder.Entity<Subscriber>().HasMany(s => s.AddressInternal).WithRequired(o => o.Subscriber).HasForeignKey(o => o.SubscriberId);
            modelBuilder.Entity<Subscriber>().HasMany(s => s.PhoneInternal).WithRequired(o => o.Subscriber).HasForeignKey(o => o.SubscriberId);
            modelBuilder.Entity<Subscriber>().HasMany(s => s.GroupInternal).WithRequired(o => o.Subscriber).HasForeignKey(o => o.SubscriberId);

            modelBuilder.Entity<Address>().HasRequired(a => a.GroupAddress);
            modelBuilder.Entity<Phone>().HasRequired(a => a.GroupPhone);

        }

        public Subscriber GetSubscriber(int UserId, int SubscriberId)
        {
            var subscriber = Users.Find(UserId).SubscriberInternal.ElementAt(SubscriberId);
            Entry(subscriber).Collection(s => s.AddressInternal).Load();
            Entry(subscriber).Collection(s => s.PhoneInternal).Load();
            Entry(subscriber).Collection(s => s.GroupInternal).Load();
            return subscriber;
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}