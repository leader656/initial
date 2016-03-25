using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace SupplementMall
{
    internal class DataBaseOperations
    {

        private static readonly SqlCeConnection Connection =  new SqlCeConnection("Data Source="+ Application.StartupPath+"\\Database.sdf");


        #region Customers
        public static bool InsertIntoCustomers(string name, string phone, string product, byte[] fingerPrint)
        {
            try
            {
                Connection.Open();
                SqlCeCommand cmdInsert =
                    new SqlCeCommand(
                        "INSERT INTO Customers(Name,Phone,Product,Date,FingerPrint,IsDeleted) VALUES(@name,@phone,@product,@Date,@fingerPrint,@isDeleted)",
                        Connection);
                cmdInsert.Parameters.AddWithValue("@name", name);
                cmdInsert.Parameters.AddWithValue("@phone", phone);
                cmdInsert.Parameters.AddWithValue("@product", product);
                cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@fingerPrint", fingerPrint);
                cmdInsert.Parameters.AddWithValue("@isDeleted", false);
                cmdInsert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool UpdateCustomer(int id, string name, string phone, string product, DateTime date)
        {
            try
            {
                Connection.Open();
                var cmdUpdate =
                    new SqlCeCommand("UPDATE Customers SET Name = @name, Phone = @phone, " +
                                     "Product = @product, Date = @date WHERE ID=@id", Connection);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.Parameters.AddWithValue("@name", name);
                cmdUpdate.Parameters.AddWithValue("@phone", phone);
                cmdUpdate.Parameters.AddWithValue("@product", product);
                cmdUpdate.Parameters.AddWithValue("@date", date);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteFromCustomers(int id)
        {
            try
            {
                Connection.Open();
                var cmdUpdate = new SqlCeCommand("UPDATE Customers SET IsDeleted = @isDeleted WHERE ID = @id", Connection);
                cmdUpdate.Parameters.AddWithValue("@isDeleted", true);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }

        public static DataTable GetAllDataFromCustomers()
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE IsDeleted = '{0}'", false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataTable SerachCustomersTableForValue(string field, string fieldValue)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE {0} = '{1}' AND IsDeleted = '{2}'", field, fieldValue, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataTable SerachCustomersTableForDate(DateTime from, DateTime to)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE (Date BETWEEN '{0}' AND '{1}') AND IsDeleted = '{2}'", from, to, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataRow GetCustomerInfo(int id)
        {
            try
            {

                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE ID = '{0}' ", id), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        #endregion

        #region Users
        public static bool InsertIntoUsers(string name, string username, string password, bool isAdmin, string email)
        {
            try
            {
                Connection.Open();
                SqlCeCommand cmdInsert =
                    new SqlCeCommand(
                        "INSERT INTO Users(Name,UserName,Password,IsAdmin,Email) VALUES(@name,@username,@password,@isAdmin,@email)",
                        Connection);
                cmdInsert.Parameters.AddWithValue("@name", name);
                cmdInsert.Parameters.AddWithValue("@username", username);
                cmdInsert.Parameters.AddWithValue("@password", password);
                cmdInsert.Parameters.AddWithValue("@isAdmin", isAdmin);
                cmdInsert.Parameters.AddWithValue("@email", email);
                cmdInsert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool UpdateUser(int id, string name, string username, string password, bool isAdmin, string email)
        {
            try
            {
                Connection.Open();
                var cmdUpdate =
                    new SqlCeCommand("UPDATE Users SET Name=@name, UserName=@username, " +
                                     "Password=@password, IsAdmin=@isAdmin, Email=@email" +
                                     " WHERE ID=@id", Connection);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.Parameters.AddWithValue("@name", name);
                cmdUpdate.Parameters.AddWithValue("@username", username);
                cmdUpdate.Parameters.AddWithValue("@password", password);
                cmdUpdate.Parameters.AddWithValue("@isAdmin", isAdmin);
                cmdUpdate.Parameters.AddWithValue("@email", email);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteFromUsers(int id)
        {
            try
            {
                Connection.Open();
                var cmdDelete = new SqlCeCommand("DELETE FROM Users WHERE ID = @id", Connection);
                cmdDelete.Parameters.AddWithValue("@id", id);
                cmdDelete.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static DataTable GetAllDataFromUsers()
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter("SELECT * FROM Users", Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataRow IsValidUser(string userName, string password)
        {
            try
            {
            
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE UserName = '{0}' AND Password = '{1}'",userName,password), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }

        public static DataRow GetUserInfo(int id)
        {
            try
            {
            
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE ID = '{0}' ",id), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }

        public static DataTable SerachUsersTableForValue(string field, string fieldValue)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE {0} = '{1}'", field, fieldValue, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }
        #endregion
    }
}
