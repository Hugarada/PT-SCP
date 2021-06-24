using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public class Imagem
        {
            static public object loadpic()
            {
                DAL dal = new DAL();
                 SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", 1),
             };
                return dal.executarScalar("select Img from Imagem where id=1", sqlParams);
            
            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Imagem", null);
            }

            static public int insertImagem(byte [] img )
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@img", img),
                
           };

                return dal.executarNonQuery("INSERT into Imagem (Img) VALUES(@img)", sqlParams);
            }
        }
        public class Employees
        {

            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Employees", null);
            }
            static public int insertEmployee(string Name, string Email, string Password, int DocumentsID, int Level, string Site)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Name", Name),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Password", Password),
                new SqlParameter("@Roll", "Stagiary"),
                new SqlParameter("@Level", Level),
                new SqlParameter("@Site_Area", Site),
                new SqlParameter("@DocumentsID", DocumentsID)
           };
                return dal.executarNonQuery("INSERT into Employees (Name,Email,Password,Roll,Level,Site_Area,DocumentsID) VALUES(@Name,@Email,@Password,@Roll,@Level,@Site_Area,@DocumentsID)", sqlParams);
            }

            static public Object getMax()
            {
                DAL dal = new DAL();
                Object obj;
                obj = dal.executarScalar("SELECT MAX(DocumentsID) from Employees", null);
                if (obj.ToString() == "")
                {
                    return 0;
                }
                return obj;
            }

            static public DataTable getname(string email, string password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@email", email),
                    new SqlParameter("@password", password)
                };
                return dal.executarReader("select Name from Employees where email=@email and password=@password", sqlParams);
            }

            static public DataTable queryEmployee2(string email, string password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@email", email),
                    new SqlParameter("@password", password)
                };
                return dal.executarReader("select * from Employees where email=@email and password=@password", sqlParams);
            }

            static public DataTable queryEmployee(string email) {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@email", email)
                };
                return dal.executarReader("select * from Employees where email=@email", sqlParams);
            }
          
            static public int updateEmployee(string id, string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
            };
                return dal.executarNonQuery("update [Employees] set [nome]=@nome, [morada]=@morada, [telefone]=@telefone where [id]=@id", sqlParams);
            }
            static public int deleteEmployee(string id)            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
               
            };
                return dal.executarNonQuery("DELETE From Employees WHERE[id]=@id", sqlParams);
            }

            static public DataTable confirmpassword(string Email, string Password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Password", Password)
                };
                return dal.executarReader("SELECT Password from Employees WHERE Email=@Email and Password=@Password", sqlParams);
            }

            static public int alterarPerfil(string Email, string Password, string Name, string Roll, string Level, string Group, string SITE_AREA, string CAssignment, string Profile)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Password", Password),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Roll", Roll),
                    new SqlParameter("@Level", Level),
                    new SqlParameter("@Group", Group),
                    new SqlParameter("@SITE_AREA", SITE_AREA),
                    new SqlParameter("@CAssignment", CAssignment),
                    new SqlParameter("@Profile", Profile)
                };
                return dal.executarNonQuery("UPDATE [Employees] set [Password]=@Password, [Name]=@Name, [Roll]=@Roll, [Level]=@Level, [Group]=@Group, [SITE_AREA]=@SITE_AREA, [CAssignment]=@CAssignemnt, [Profile]=@Profile where [Email]=@Email", sqlparams);
            }

            static public int alterarPerfilnonpass(string Email, string Name, string Roll, string Level, string Group, string SITE_AREA, string CAssignment, string Profile)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Roll", Roll),
                    new SqlParameter("@Level", Level),
                    new SqlParameter("@Group", Group),
                    new SqlParameter("@SITE_AREA", SITE_AREA),
                    new SqlParameter("@CAssignment", CAssignment),
                    new SqlParameter("@Profile", Profile)
                };
                return dal.executarNonQuery("UPDATE Employees set [Name]=@Name, [Roll]=@Roll, [Level]=@Level, [Group]=@Group, [SITE_AREA]=@SITE_AREA, [CAssignment]=@CAssignment, [Profile]=@Profile where [Email]=@Email", sqlparams);
            }

            static public int selfchange(string Email, string Name, string Profile)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]
                {
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Profile", Profile)
                };
                return dal.executarNonQuery("UPDATE Employees set [Name]=@Name, [Profile]=@Profile WHERE [Email]=@Email", sqlparams);
            }
        }
        public class GoI
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * from GoI ", null);
            }

            static public DataTable getgoi(string Name)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name)
                };
                return dal.executarReader("SELECT * from GoI WHERE Name=@Name", sqlparams);
            }

            static public int AlterarGoI(string Name, string Overview, string Information, int ID)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Overview", Overview),
                    new SqlParameter("@Information", Information),
                    new SqlParameter("@ID", ID)
                };
                return dal.executarNonQuery("UPDATE GoI set [Name]=@Name, [Overview]=@Overview, [Information]=@Information WHERE [ID]=@ID", sqlparams);
            }

            static public Object getMax()
            {
                DAL dal = new DAL();
                Object obj;
                obj = dal.executarScalar("SELECT MAX(ID) from GoI", null);
                if (obj.ToString() == "")
                {
                    return 0;
                }
                return obj;
            }
        }
        public class Article
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Article", null);
            }

            static public int insertArticle(int ID, string Name, string Description, string Writter, string Site_Area, string Type)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]
                    {
                        new SqlParameter("@ID", ID),
                        new SqlParameter("@Name", Name),
                        new SqlParameter("@Type", Type),
                        new SqlParameter("@Aproved", "Pending"),
                        new SqlParameter("@Description", Description),
                        new SqlParameter("@Writter", Writter),
                        new SqlParameter("@Aproved", "Pending"),
                        new SqlParameter("@Type", Type),
                        new SqlParameter("@Site-Area", Site_Area)
                    };
                return dal.executarNonQuery("INSERT into Articles (ID, Name, Description, Writter, Aproved, Type, Site-Area) VALUES (@ID, @Name, @Description, @Writter, @Aproved, @Type, @Site-Area)", sqlparams);
            }

            static public int updateArticle(string Name, string Description, string Type, string Class, int LVL, string SITE_AREA, string oldName, string Aproved)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]
                    {
                        new SqlParameter("@Name", Name),
                        new SqlParameter("@Description", Description),
                        new SqlParameter("@Type", Type),
                        new SqlParameter("@Aproved", Aproved),
                        new SqlParameter("@Class", Class),
                        new SqlParameter("@LVL", LVL),
                        new SqlParameter("@SITE-AREA", SITE_AREA),
                        new SqlParameter("@oldName", oldName)
                    };
                return dal.executarNonQuery("UPDATE Articles set [Name]=@Name, [Description]=@Description, [Type]=@Type, [Aproved]=@Aproved, [Class]=@Class, [LVL]=@LVL WHERE [Name]=@oldName", sqlparams);
            }

            static public Object getMax()
            {
                DAL dal = new DAL();
                Object obj;
                obj = dal.executarScalar("SELECT MAX(ID) from Article", null);
                if (obj.ToString() == "")
                {
                    return 0;
                }
                return obj;
            }
        }
    }
}