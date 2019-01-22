using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;
using System.Data;


public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionChocolate"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }


#region Chocolate


    public static ArrayList GetChocolateByType(string criteria, string chocolateType)
    {
        ArrayList list = new ArrayList();
        if(chocolateType.Equals("Valentine's Day")) chocolateType="%Valentine%";
        string query = string.Format("SELECT * FROM Chocolate WHERE {0} like '{1}' order by name ", criteria, chocolateType);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3); ; 
                string image = reader.GetString(4);
                string description; 
                   if(reader.IsDBNull(5)) description=null; 
                   else description = reader.GetString(5);
                double weight; 
                  if(reader.IsDBNull(6)) weight=0; 
                  else weight = reader.GetDouble(6);
                string dimensions; 
                   if(reader.IsDBNull(7)) dimensions=null; 
                   else dimensions=reader.GetString(7);
                string ingredients;
                   if(reader.IsDBNull(8)) ingredients=null;
                   else ingredients = reader.GetString(8);
                string holiday;
                   if(reader.IsDBNull(9)) holiday=null;
                   else holiday = reader.GetString(9);

                
                if (ingredients=="") ingredients = null;
                if (holiday == "") holiday = null;
                if (dimensions == "") dimensions = null;
                if (description == "") description = null;


                Chocolate chocolate = new Chocolate(id, name, type, price, image, description, weight, dimensions, ingredients, holiday);
                list.Add(chocolate);
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return list;
    }


    public static IList<string> UsedImages(string path)
    {
        string query = "SELECT image FROM Chocolate";
        IList<string> l = new List<string>();

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                l.Add(path+reader.GetString(0));
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return l;
    }


    public static ArrayList ChocolateSearch(string what)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM Chocolate WHERE lower(name) like '%{0}%' or lower(type) like '%{0}%' or lower(cast(description as varchar(2000))) like '%{0}%' or lower(cast(ingredients as varchar(2000))) like '%{0}%' or lower(holiday) like '%{0}%' order by name ", what.ToLower());

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3); ;
                string image = reader.GetString(4);
                string description;
                if (reader.IsDBNull(5)) description = null;
                else description = reader.GetString(5);
                double weight;
                if (reader.IsDBNull(6)) weight = 0;
                else weight = reader.GetDouble(6);
                string dimensions;
                if (reader.IsDBNull(7)) dimensions = null;
                else dimensions = reader.GetString(7);
                string ingredients;
                if (reader.IsDBNull(8)) ingredients = null;
                else ingredients = reader.GetString(8);
                string holiday;
                if (reader.IsDBNull(9)) holiday = null;
                else holiday = reader.GetString(9);


                if (ingredients == "") ingredients = null;
                if (holiday == "") holiday = null;
                if (dimensions == "") dimensions = null;
                if (description == "") description = null;


                Chocolate chocolate = new Chocolate(id, name, type, price, image, description, weight, dimensions, ingredients, holiday);
                list.Add(chocolate);
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return list;
    }


    public static Chocolate GetChocolateById(int id)
    {
        string query = string.Format("SELECT * FROM Chocolate WHERE id = {0}", id);
        Chocolate chocolate=null;

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               // int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3); ;
                string image = reader.GetString(4);
                string description;
                if (reader.IsDBNull(5)) description = null;
                else description = reader.GetString(5);
                double weight;
                if (reader.IsDBNull(6)) weight = 0;
                else weight = reader.GetDouble(6);
                string dimensions;
                if (reader.IsDBNull(7)) dimensions = null;
                else dimensions = reader.GetString(7);
                string ingredients;
                if (reader.IsDBNull(8)) ingredients = null;
                else ingredients = reader.GetString(8);
                string holiday;
                if (reader.IsDBNull(9)) holiday = null;
                else holiday = reader.GetString(9);


                if (ingredients == "") ingredients = null;
                if (holiday == "") holiday = null;
                if (dimensions == "") dimensions = null;
                if (description == "") description = null;


                chocolate = new Chocolate(id, name, type, price, image, description, weight, dimensions, ingredients, holiday);
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return chocolate;
    }


    public static void AddChocolate(Chocolate chocolate)
    {
        string query = string.Format(
          "INSERT INTO Chocolate VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5}, '{6}', '{7}', '{8}' )",
          chocolate.name, chocolate.type,chocolate.price,chocolate.image, chocolate.description, chocolate.weight, chocolate.dimensions,chocolate.ingredients,chocolate.holiday
          );
        command.CommandText = query;

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
       finally
        {
           conn.Close();
           command.Parameters.Clear();
        }
    }

#endregion


#region Users

    public static string ChangeForgottenPassword(string user, string newPassword)
    {
        UpdatePassword(user, newPassword);
        return "Password was successfully changed!";
    }

    public static string ChangePassword(string user, string oldPassword, string newPassword)
    {
        if (oldPassword != GetPassword(user))
            return "Old password is incorrect!";
        else
        {
            UpdatePassword(user,newPassword);
            return "Password was successfully changed!";
        }
    }

    public static string GetPassword(string name)
    {
        string password; 

        string query = string.Format("SELECT password FROM Users WHERE name = '{0}'", name);
        command.CommandText = query;

        try
        {
            conn.Open();
            password = (string)command.ExecuteScalar();

        }
        finally
        {

            conn.Close();
            command.Parameters.Clear();
        }

        return password;
    }

    public static void UpdatePassword(string name, string password)
    {
        string query = @"UPDATE users
                         SET password = @password
                         WHERE name = @name";
        command.CommandText = query;

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@name", name));
            command.Parameters.Add(new SqlParameter("@password", password));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static void DeleteAccount(string name)
    {
        string query = @"DELETE from users
                         WHERE name = @client";
        command.CommandText = query;
        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@client", name));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }


    public static void UpdateCode(string name, string code, DateTime date)
    {
        string query = @"UPDATE users
                         SET activationCode = @code, dateCodeSent = @date
                         WHERE name = @client";
        command.CommandText = query;

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@client", name));
            command.Parameters.Add(new SqlParameter("@date", date));
            command.Parameters.Add(new SqlParameter("@code", code));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static void ActivateAccount(string email){
        string query = @"UPDATE users
                         SET confirmedEmail = 1
                         WHERE lower(email) = @client";
        command.CommandText = query;

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@client", email.ToLower()));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static bool accountActivated(string email){
         bool activated;

         string query = string.Format("SELECT confirmedEmail FROM Users WHERE lower(email) = '{0}'", email.ToLower());
         command.CommandText = query;

         try
        {
            conn.Open();
            activated = (bool)command.ExecuteScalar();

        }
        finally
        {

            conn.Close();
            command.Parameters.Clear();
        }

         return activated;
    }

    public static void DateCodeActivateAccount(string name, ref DateTime dateSent, ref string code, ref string mail )
    {
        string query = string.Format("SELECT dateCodeSent, activationCode, email FROM users WHERE name = '{0}'", name);
        command.CommandText = query;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()){
               dateSent = reader.GetDateTime(0);
               code = reader.GetString(1);
               mail = reader.GetString(2);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }

    }

    public static User LoginUser(string email, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM  Users WHERE email = '{0}'", email);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT password FROM Users WHERE lower(email) = '{0}'", email.ToLower());
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();
            
                if (dbPassword.Equals(password))
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    User user = null;

                    query = string.Format("SELECT name , user_type FROM Users WHERE lower(email) = '{0}'", email.ToLower());
                    command.CommandText = query;
                 
                     SqlDataReader reader = command.ExecuteReader();
                     while (reader.Read())
                      {
                        string name = reader.GetString(0);
                        string type = reader.GetString(1);
                        
                        user = new User(name, password, email, type);
                      }
                     
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {

            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static string RegisterUser(User user, string activationCode, DateTime dateCodeSent)
    {
        //Check if user exists
        string query1 = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", user.email);
        string query2 = string.Format("SELECT COUNT(*) FROM users WHERE name = '{0}'", user.name);

        try
        {
            conn.Open();
            command.CommandText = query1;
            int amountOfUsersEmail = (int)command.ExecuteScalar();
            command.CommandText = query2;
            int amountOfUsersName = (int)command.ExecuteScalar();

            if (amountOfUsersEmail < 1 && amountOfUsersName < 1)
            {
                bool activated = false; ;
                if (activationCode == null) activated = true;


                //User does not exist, create a new user
                query1 = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}', '{4}' , '{5}', '{6}')", user.name, user.password,
                                      user.email, user.type, activated, activationCode, dateCodeSent);
                command.CommandText = query1;
                command.ExecuteNonQuery();
                return "User registered! Please check your e-mail for the activation link.";
            }
            else
            {
                //User exists\
                if(amountOfUsersEmail > 0)
                    return "A user with this e-mail address already exists!";
                else
                    return "A user with this name already exists!";
            }
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static User GetUserDetails(string userName)
    {
        string query = string.Format("SELECT * FROM users WHERE name = '{0}'", userName);
        command.CommandText = query;
        User user = null;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string password = reader.GetString(2);
                string email = reader.GetString(3);
                string userType = reader.GetString(4);

                user = new User(id, name, password, email, userType);

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }

        return user;
    }

#endregion


#region Orders

    public static void AddOrders(ArrayList orders)
    {   
        if (orders != null)
        try
        {
            command.CommandText = "INSERT INTO Orders VALUES ( @clientName, @product, @amount, @price, @date, @orderShipped, @deliveryAddress )";
            conn.Open();

            foreach (Order order in orders)
            {
                command.Parameters.Add(new SqlParameter("@clientName", order.clientName));
                command.Parameters.Add(new SqlParameter("@product", order.product));
                command.Parameters.Add(new SqlParameter("@amount", order.amount));
                command.Parameters.Add(new SqlParameter("@price", order.price));
                command.Parameters.Add(new SqlParameter("@date", order.date));
                command.Parameters.Add(new SqlParameter("@orderShipped", order.orderShipped));
                command.Parameters.Add(new SqlParameter("@deliveryAddress", order.deliveryAddress));

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static ArrayList GetGroupedOrders(DateTime currentDate, DateTime endDate, Boolean shipped)
    {   
        string query = @"SELECT clientName, date, SUM(total) 
                           FROM ( 
                                  SELECT clientName, date, (amount * price) AS total 
                                  FROM orders
                                  WHERE date >= @date1 AND date <= @date2 AND orderShipped = @orderShipped
                                )as result 
                           GROUP BY clientName, date";
        ArrayList orderList = new ArrayList();
        int lastDay;

        if (currentDate.Month == endDate.Month && currentDate.Year == endDate.Year)
        {
            lastDay = endDate.Day;
        }
        else
        {
            lastDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

        }

        DateTime date2 = new DateTime(currentDate.Year, currentDate.Month, lastDay);

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@date1", currentDate));
            command.Parameters.Add(new SqlParameter("@date2", date2));
            command.Parameters.Add(new SqlParameter("@orderShipped", shipped));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string client = reader.GetString(0);
                DateTime date = reader.GetDateTime(1);
                double total = reader.GetDouble(2);

                GroupedOrder groupedOrder = new GroupedOrder(client, date, total);
                orderList.Add(groupedOrder);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
        return orderList;
    }

    public static ArrayList GetGroupedOrders(String name)
    {
        string query = @"SELECT date, SUM(total), orderShipped 
                           FROM ( 
                                  SELECT date, (amount * price) AS total, orderShipped 
                                  FROM orders
                                  WHERE clientName = @date1
                                )as result 
                           GROUP BY date, orderShipped";
        ArrayList orderList = new ArrayList();

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@date1", name));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(0);
                double total = reader.GetDouble(1);
                bool shipped = reader.GetBoolean(2);

                GroupedOrder groupedOrder = new GroupedOrder(name, date, total, shipped);
                orderList.Add(groupedOrder);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
        return orderList;
    }

    public static ArrayList GetDetailedOrders(string client, DateTime date)
    {
        string query = @"SELECT id, product, amount, price, orderShipped, deliveryAddress
                           FROM orders
                           WHERE clientName = @client AND date = @date";
        command.CommandText = query;
        ArrayList orderList = new ArrayList();

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date", date));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string product = reader.GetString(1);
                int amount = reader.GetInt32(2);
                double price = reader.GetDouble(3);
                bool orderShipped = reader.GetBoolean(4);
                string deliveryAddress = reader.GetString(5);

                Order order = new Order(id, client, product, amount, price, date, orderShipped, deliveryAddress);
                orderList.Add(order);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return orderList;
    }

    public static void UpdateOrders(string client, DateTime date)
    {
        string query = @"UPDATE orders
                         SET orderShipped = 1
                         WHERE clientName = @client AND date = @date";
        command.CommandText = query;

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date",date));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }


    //Chart methods
    public static System.Data.DataTable GetChartDate(string query)
    {
        command.CommandText = query;
        DataTable dt = new DataTable();

        try
        {
            conn.Open();

            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = command;
                sda.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }

        return dt;
    }


#endregion


}