using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace Model
{
    public class ComonDbContext : DbContext
    {
        private readonly static string CONNECTION_STRING = "name=StudentDB_ConnString";

        public ComonDbContext() : base(CONNECTION_STRING)
        {
            //这里是如果像自定义 就这么写。如果不写就是默认的契约(ComonDbContext)
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<ClassDB> ClassDBContent { get; set; }

        public DbSet<OrderClassDB> Orderclass { get; set; }

        public DbSet<GroupDB> GroupDBContent { get; set; }

        public DbSet<DirectionDB> DirectionDBContent { get; set; }

        public DbSet<EnrollmentDB> EnrollmentDBContent { get; set; }

        public DbSet<StuenrollDB> StuenrollDBContent { get; set; }

        public DbSet<DiplomaDB> DiplomaDBContent { get; set; }

        public DbSet<GraPersonlistDB> GraPersonlistDBContent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约(就是在表后边加个s)

            //防止黑幕交易 要不然每次都要访问 EdmMetadata这个表
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            #region ====可以删除的公约（方便大家查看使用）===
            /*
            Namespace:System.Data.Entity.ModelConfiguration.Conventions.Edm
            • AssociationInverseDiscoveryConvention 
            寻找导航上互相引用的类的属性，并将它们配置为逆属性的相同的关系。
            • ComplexTypeDiscoveryConvention 
            寻找有没有主键的类型，并将它们配置为复杂类型。
            • DeclaredPropertyOrderingConvention 
            确保每个实体的主要关键属性优先于其他属性。
            • ForeignKeyAssociationMultiplicityConvention 
            配置是必需的还是可选的关系基于为空性外键属性，如果包含在类定义中。
            • IdKeyDiscoveryConvention 
            查找名为 Id 或 <TypeName> Id 的属性，并将他们配置作为主键。
            • NavigationPropertyNameForeignKeyDiscoveryConvention 
            使用外键关系，使用 <NavigationProperty> <PrimaryKeyProperty> 模式作为属性的外观。
            • OneToManyCascadeDeleteConvention 
            交换机上层叠删除，所需的关系。
            • OneToOneConstraintIntroductionConvention 
            将配置为一个： 一个关系的外键的主键。
            • PluralizingEntitySetNameConvention 
            配置为多元化的类型名称的实体数据模型中的实体集的名称。
            • PrimaryKeyNameForeignKeyDiscoveryConvention 
            使用外键关系，使用 <PrimaryKeyProperty> 模式作为属性的外观。
            • PropertyMaxLengthConvention 
            配置所有的字符串和字节 [] 属性，默认情况下具有最大长度。
            • StoreGeneratedIdentityKeyConvention 
            配置默认情况下将标识所有整数的主键。
            • TypeNameForeignKeyDiscoveryConvention 
            使用外键关系，使用 <PrincipalTypeName> <PrimaryKeyProperty> 模式作为属性的外观。*/
            #endregion
        }
    }
}
