using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using Microsoft.Extensions.Configuration;
using qms.Models;
using qms.common;

namespace qms.DataAccess;
public class TokenSqlMgr
{
    private String? conStr;

    /// Function to Create Tokens
    #region CreateToken
    public Int32 createToken(Token token)
    {
        Int32 ret = -1;

        conStr = commondata.GetConnectionStr;
        MySqlConnection? con = null;
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                ret = this.createToken(con, token);
            }
            if (ret > 0)
            {

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return ret;

    }
    public Int32 createToken(MySqlConnection myCon, Token token)
    {

        Int32 ret = -1;
        MySqlCommand? cmd = null;
        String queryStr = "INSERT INTO ticket_tbl(ticket, customer, plateno, contactnumber, queueindex, createdat)"
                        + " VALUES (@ticket, @customer, @plateno, @contactnumber, @queueindex, NOW())";

        try
        {
            using (cmd = new MySqlCommand(queryStr, myCon))
            {
                if (!String.IsNullOrEmpty(token.Ticket))
                {
                    cmd.Parameters.AddWithValue("@ticket", token.Ticket);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ticket", DBNull.Value);
                }

                if (!String.IsNullOrEmpty(token.Customer))
                {
                    cmd.Parameters.AddWithValue("@customer", token.Customer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@customer", DBNull.Value);
                }

                if (!String.IsNullOrEmpty(token.PlateNo))
                {
                    cmd.Parameters.AddWithValue("@plateno", token.PlateNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@plateno", DBNull.Value);
                }

                if (!String.IsNullOrEmpty(token.ContactNo))
                {
                    cmd.Parameters.AddWithValue("@contactnumber", token.ContactNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@contactnumber", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@queueindex", token.QueueIndex);
            }

            ret = (int)cmd.ExecuteNonQuery();

            if (cmd.LastInsertedId > 0)
            {
                cmd.Parameters.Add(new MySqlParameter("newId", cmd.LastInsertedId));
            }

            ret = Convert.ToInt32(cmd.Parameters["@newId"].Value);
        }
        catch (Exception ex)
        {
            //logger.Error("Error on saving User Info to tbl_User_Info");
            throw ex;
        }
        return ret;
    }
    #endregion CreateToken

    /// Function to select one token
    #region GetTokenInfo
    public Token GetTokenInfo(int id)
    {
        conStr = commondata.GetConnectionStr;
        Token ret = new Token();
        MySqlConnection? con = null;
        MySqlCommand cmd;
        MySqlDataReader? reader = null;
        String query = "SELECT * FROM ticket_tbl WHERE qid = @qid";
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                if (id > 0)
                {
                    try
                    {
                        using (cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@qid", id));
                            using (reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                ret.Qid = Int32.Parse(reader["qid"].ToString());
                                ret.Ticket = reader["ticket"].ToString();
                                ret.Customer = reader["customer"].ToString();
                                ret.PlateNo = reader["plateno"].ToString();
                                ret.ContactNo = reader["contactnumber"].ToString();
                                ret.QueueIndex = int.Parse(reader["queueindex"].ToString());
                                ret.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return ret;
    }
    #endregion GetTokenInfo

    /// Function to get all tokens in Token Table
    #region GetTokens
    public List<Token> GetTokens(Int32 id, String token)
    {

        conStr = commondata.GetConnectionStr;
        List<Token> ret = new List<Token>();
        MySqlConnection MyCon = null;

        try
        {
            using (MyCon = new MySqlConnection(conStr))
            {
                MyCon.Open();
                ret = this.GetTokens(MyCon, id, token);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (MyCon != null)
            {
                MyCon.Close();
            }
        }

        return ret;
    }

    public List<Token> GetTokens(MySqlConnection con, Int32 id, String token)
    {
        List<Token> ret = new List<Token>();
        MySqlCommand cmd;
        String sqlQuery = "SELECT * FROM ticket_tbl";
        String inject = "";
        MySqlDataReader? reader = null;

        if (id > 0)
        {
            inject += " WHERE qid=@qid";
        }
        if (!String.IsNullOrEmpty(token))
        {
            inject += " WHERE ticket=@ticket";
        }

        try
        {
            using (cmd = new MySqlCommand(sqlQuery + inject, con))
            {
                if (id > 0)
                {
                    cmd.Parameters.Add(new MySqlParameter("@qid", id));
                }
                if (!String.IsNullOrEmpty(token))
                {
                    cmd.Parameters.Add(new MySqlParameter("@ticket", token));
                }

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Token tokenList = new Token();
                        tokenList.Qid = int.Parse(reader["qid"].ToString());
                        tokenList.Ticket = reader["ticket"].ToString();
                        tokenList.Customer = reader["customer"].ToString();
                        tokenList.PlateNo = reader["plateno"].ToString();
                        tokenList.ContactNo = reader["contactnumber"].ToString();
                        tokenList.QueueIndex = int.Parse(reader["queueindex"].ToString());
                        tokenList.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                        ret.Add(tokenList);
                    }

                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }

        return ret;
    }

    #endregion GetTokens

    #region GetQueueTokens
    public List<Token> GetQueueTokens()
    {

        conStr = commondata.GetConnectionStr;
        List<Token> ret = new List<Token>();
        MySqlConnection MyCon = null;

        try
        {
            using (MyCon = new MySqlConnection(conStr))
            {
                MyCon.Open();
                ret = this.GetQueueTokens(MyCon);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (MyCon != null)
            {
                MyCon.Close();
            }
        }

        return ret;
    }

    public List<Token> GetQueueTokens(MySqlConnection con)
    {
        List<Token> ret = new List<Token>();
        MySqlCommand cmd;
        String sqlQuery = "SELECT * FROM ticket_tbl WHERE queueindex != 0 ORDER BY queueindex ASC";
        String inject = "";
        MySqlDataReader? reader = null;

        try
        {
            using (cmd = new MySqlCommand(sqlQuery + inject, con))
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Token tokenList = new Token();
                        tokenList.Qid = int.Parse(reader["qid"].ToString());
                        tokenList.Ticket = reader["ticket"].ToString();
                        tokenList.Customer = reader["customer"].ToString();
                        tokenList.PlateNo = reader["plateno"].ToString();
                        tokenList.ContactNo = reader["contactnumber"].ToString();
                        tokenList.QueueIndex = int.Parse(reader["queueindex"].ToString());
                        tokenList.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                        ret.Add(tokenList);
                    }

                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }

        return ret;
    }

    #endregion GetQueueTokens

    /// Update Queue Index for Each Counter Reservation
    #region UpdateQueueIndex
    public int UpdateQueueIndex(int id, int queueindex)
    {
        Int32 ret = -1;

        conStr = commondata.GetConnectionStr;
        MySqlConnection? con = null;

        using (con = new MySqlConnection(conStr))
        {
            con.Open();

            if (id > 0)
            {
                MySqlCommand? cmd = null;
                String query = "UPDATE ticket_tbl SET queueindex=@queueindex WHERE qid=@qid";

                try
                {
                    cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@qid", id);
                    cmd.Parameters.AddWithValue("@queueindex", queueindex);
                    ret = (int)cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        return ret;
    }
    #endregion UpdateQueueIndex

    /// Function to get Last Item of Token Table
    #region GetLastToken
    public Token GetLastToken()
    {

        conStr = commondata.GetConnectionStr;
        Token ret = new Token();
        MySqlCommand cmd;
        String sqlQuery = "SELECT * FROM ticket_tbl ORDER BY qid DESC LIMIT 1";
        MySqlConnection? con = null;
        MySqlDataReader? reader = null;
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                try
                {
                    using (cmd = new MySqlCommand(sqlQuery, con))
                    {

                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ret.Qid = int.Parse(reader["qid"].ToString());
                                ret.Ticket = reader["ticket"].ToString();
                                ret.Customer = reader["customer"].ToString();
                                ret.PlateNo = reader["plateno"].ToString();
                                ret.ContactNo = reader["contactnumber"].ToString();
                                ret.QueueIndex = int.Parse(reader["queueindex"].ToString());
                                ret.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return ret;
    }
    #endregion GetLastToken

    /// Function to get counter servicing tickets
    #region GetCounterToken
    public Token GetCounterToken(int index)
    {

        conStr = commondata.GetConnectionStr;
        Token ret = new Token();
        MySqlCommand cmd;
        String sqlQuery = "SELECT * FROM ticket_tbl WHERE queueindex = @queueindex";
        MySqlConnection? con = null;
        MySqlDataReader? reader = null;
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                try
                {
                    using (cmd = new MySqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@queueindex", index));

                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ret.Qid = int.Parse(reader["qid"].ToString());
                                ret.Ticket = reader["ticket"].ToString();
                                ret.Customer = reader["customer"].ToString();
                                ret.PlateNo = reader["plateno"].ToString();
                                ret.ContactNo = reader["contactnumber"].ToString();
                                ret.QueueIndex = int.Parse(reader["queueindex"].ToString());
                                ret.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

        return ret;
    }
    #endregion GetCounterToken

    #region GetFirstToken
    public Token GetFirstToken()
    {

        conStr = commondata.GetConnectionStr;
        Token ret = new Token();
        MySqlCommand cmd;
        String sqlQuery = "SELECT * FROM ticket_tbl WHERE queueindex = 0 ORDER BY qid ASC LIMIT 1";
        MySqlConnection? con = null;
        MySqlDataReader? reader = null;
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                try
                {
                    using (cmd = new MySqlCommand(sqlQuery, con))
                    {

                        using (reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ret.Qid = int.Parse(reader["qid"].ToString());
                                ret.Ticket = reader["ticket"].ToString();
                                ret.Customer = reader["customer"].ToString();
                                ret.PlateNo = reader["plateno"].ToString();
                                ret.ContactNo = reader["contactnumber"].ToString();
                                ret.QueueIndex = int.Parse(reader["queueindex"].ToString());
                                ret.CreatedAt = DateTime.Parse(reader["createdat"].ToString());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }

        return ret;
    }
    #endregion GetFirstToken

    #region DeleteToken

    public int DeleteToken(int id)
    {
        int ret = -1;
        conStr = commondata.GetConnectionStr;
        MySqlCommand cmd;
        String sqlQuery = "DELETE FROM ticket_tbl WHERE qid = @qid";
        MySqlConnection? con = null;
        try
        {
            using (con = new MySqlConnection(conStr))
            {
                con.Open();
                
                    using (cmd = new MySqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@qid", id));
                        ret = (int)cmd.ExecuteNonQuery();
                        
                    }
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return ret;
    }
    #endregion DeleteToken
}
