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
            static public int insertEmployee(string nome, string email, string Password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Nome", nome),
                new SqlParameter("@email", email),
                new SqlParameter("@Password", Password)
           };

                return dal.executarNonQuery("INSERT into Employees (nome,email,Password) VALUES(@Nome,@email,@Password)", sqlParams);
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
                return dal.executarNonQuery("Delete From Employees WHERE[id]=@id", sqlParams);
            }
                static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }

        }
    }
}