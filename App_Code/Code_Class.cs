using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for Code_Class
/// </summary>
public class Code_Class
{
    public Code_Class()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //SELECT WITHOUT TABLE NAME
    private SqlConnection CreateConnection()
    {
        string _connectionString = ConnectObj.ConnectionSERVER();
        return new SqlConnection(_connectionString);
    }

    public DataTable SelectDataTableRecords(string query)
    {
        SqlConnection conn = CreateConnection();
        try
        {
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable lawyers_notifications = new DataTable();

            try
            {
                adapter.SelectCommand = new SqlCommand(query, conn);

                adapter.Fill(lawyers_notifications);
                return lawyers_notifications;
            }
            finally
            {
                if (!Object.Equals(adapter.SelectCommand, null)) adapter.SelectCommand.Dispose();
            }
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }


    SqlTransaction transactions; // class variable

    public static Boolean SaveRecord(string[] arraySaveQuery)
    {

        String connectionString = ConnectObj.ConnectionSERVER();
        SqlConnection connection = new SqlConnection(connectionString);

        SqlTransaction transactions;

        connection.Open();

        SqlCommand command = connection.CreateCommand();

        transactions = connection.BeginTransaction();

        command.Connection = connection;
        command.Transaction = transactions;

        try
        {
            foreach (string query in arraySaveQuery)
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }

            transactions.Commit();
            return true;

        }
        catch (Exception e)
        {
            try
            {
                transactions.Rollback();
            }
            catch (SqlException ex)
            {
                if (transactions.Connection != null)
                { }
            }

            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public static string ReadFile(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            return string.Empty;
        }

        using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
        {
            return sr.ReadToEnd();
        }
    }

    public static void WriteFile(string content, string path)
    {
        System.IO.File.WriteAllText(@"" + path, content);
    }

    public static Boolean SendTextMessage(string phoneno, string messagebody)
    {
        string senderusername = "francis";
        string senderpassword = "5545";
        string senderid = "Arkdrill";
        string sURL;
        StreamReader objReader;
        sURL = "http://thinkfirstsms.com/index.php/reseller/?username=" + senderusername + "&password=" + senderpassword + "&sender=" + senderid + "&mobile=" + phoneno + "&type=0&message=" + messagebody;
        WebRequest wrGETURL;
        wrGETURL = WebRequest.Create(sURL);
        try
        {
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            objReader = new StreamReader(objStream);
            objReader.Close();

            return true;
        }
        catch (Exception ex)
        {
            ex.ToString();
            return false;
        }
    }
}


public class Member
{
    public string RegId;
    public int Stage;
    public string Name;
    public int Left;
    public int Right;

}
public class Node
{
    public Node Parent;
    public Node LeftNode;
    public Node RightNode;

    private string _regId;
    private string _title;
    private int _stage;
    private int _left;
    private int _right;

    private Tree _tree;

    private int _level;

    public Node(Member m, int level, Tree tree)
    {
        this._left = m.Left;
        this._right = m.Right;
        _regId = m.RegId;
        _title = m.Name;
        _stage = m.Stage;
        _level = level;
        _tree = tree;
    }

    public int GetStage()
    {
        return _stage;
    }

    public void AddChildren(List<Member> members, int maxStage)
    {
        if (this._level == maxStage) return;

        //populate left
        var leftMember = (from m in members where m.Left > this._left & m.Right < this._right select m).FirstOrDefault();
        if (leftMember == null)
        {
            leftMember = new Member { Name = "Empty" };
        }
        else
        {
            // todo remove this item from the list
            members.Remove(leftMember);
        }


        //right
        var rightMember = (from m in members where m.Left > this._left & m.Right < this._right select m).FirstOrDefault();
        if (rightMember == null)
        {
            rightMember = new Member { Name = "Empty" };
        }
        else
        {
            members.Remove(rightMember);
        }

        this._level++;

        this.LeftNode = new Node(leftMember, this._level, _tree);
        this.RightNode = new Node(rightMember, this._level, _tree);



        this.LeftNode.AddChildren(members, maxStage);
        this.RightNode.AddChildren(members, maxStage);

    }

    public bool PlaceChild(Member member)
    {
        //if (_tree.HasBeenAdded(member)) return true;

        if (IsDecendant(member))
        {
            if (IsChild(member))
            {
                if (member.Left == _left + 1)
                {
                    if (LeftNode == null)
                    {
                         //throw new Exception("Nodes not well initialized");
                        return true;
                    }
                    LeftNode.CopyMember(member, this);
                }
                else
                {
                    if (RightNode == null)
                    {
                       // throw new Exception("Nodes not well initialized");
                        return true;
                    }
                    RightNode.CopyMember(member, this);
                }
                LeftNode.Parent = this;
                RightNode.Parent = this;
                return true;
            }
            else
            {
                if (LeftNode.IsEmpty())
                {
                    LeftNode.CopyMember(member, this);
                    return true;
                }
                else if (LeftNode.IsDecendant(member))
                {
                    return LeftNode.PlaceChild(member);
                }
                if (RightNode.IsEmpty())
                {
                    RightNode.CopyMember(member, this);
                    return true;
                }
                else if (RightNode.IsDecendant(member))
                {
                    return RightNode.PlaceChild(member);
                }
            }
        }
        return Parent.PlaceChild(member);
    }

    private bool IsEmpty()
    {
        return _title == "Empty";
    }

    private void CopyMember(Member member, Node prarent)
    {
        this._title = member.Name;
        this._stage = member.Stage;
        this._regId = member.RegId;
        _right = member.Right;
        _left = member.Left;
        Parent = prarent;

        _tree.AddedMembers.Add(member);
    }

    public bool IsDecendant(Member member)
    {
        return member.Left > _left && member.Right < _right;
    }

    public bool IsChild(Member member)
    {
        return member.Left == _left + 1 || member.Right == _right - 1;
    }

    private string getImage()
    {
        switch (_stage)
        {
            default:
                return "images/1.png";
            case 1:
                return "images/stage_avatars/stage-1-male.png";
            case 2:
                return "images/stage_avatars/stage-2-male.png";
            case 3:
                return "images/stage_avatars/stage-3-male.png";
            case 4:
                return "images/stage_avatars/stage-4-male.png";
            case 5:
                return "images/stage_avatars/stage-5-male.png";
        }
    }

    public string Display()
    {
        var img = getImage();
        //todo get image based om the current level
        string output = "<li><span><img style='width:50px;' src='" + img + "' /><br/><a href='?userId=" + this._regId + "'>" + this._title + "</a></span>";
        if (this.LeftNode != null || this.RightNode != null)
        {
            output += "<ul>";
            if (this.LeftNode != null)
            {
                output += this.LeftNode.Display();
            }
            if (this.RightNode != null)
            {
                output += this.RightNode.Display();
            }
            output += "</ul>";
        }
        return output;

    }

    internal bool IsBalance(int expectedDept)
    {        
        //if this is the last in the block
        if (expectedDept == 1) return true;
        //if any of the legs is empty
        if (this.LeftNode.IsEmpty() || this.RightNode.IsEmpty()) return false;
        //check the legs of the children
        return LeftNode.IsBalance(expectedDept - 1) && RightNode.IsBalance(expectedDept - 1);
    }
}

public class Tree
{
    const int TYPE_GENEALOGY = 1;
    const int TYPE_DIRECT_DOWNLINE = 2;
    const int TYPE_ALL_DOWNLINE = 3;

    public Node RootNode;
    public List<Member> Members;
    public List<Member> AddedMembers = new List<Member>();

    public Tree(Member rootMember, List<Member> members, int _type)
    {
        if (_type == 0) _type = TYPE_GENEALOGY;

        var block = 0;
        switch (_type)
        {
            case TYPE_GENEALOGY:
                if (rootMember.Stage == 1)
                {
                    block = 3;
                }
                else
                {
                    block = 4;
                }
                break;
            case TYPE_ALL_DOWNLINE:
                var count = members.Count;
                var nth = Math.Pow((1 - ((count * (1 - 2)) / 1)), 0.5);
                int whole = (int)nth;
                var fraction = nth - whole;
                if (fraction > 0)
                {
                    whole += 1;
                }
                block = whole;


                break;
            case TYPE_DIRECT_DOWNLINE:
                block = 2;
                break;

        }

        Members = members;
        RootNode = new Node(rootMember, 1, this);
        RootNode.AddChildren(new List<Member> { rootMember }, block);

        foreach (var m in members)
        {
            if (m.RegId == rootMember.RegId) continue;
            RootNode.PlaceChild(m);
        }
    }

    public bool HasBeenAdded(Member member)
    {
        foreach (var m in Members)
        {
            if (m.RegId == member.RegId) return true;
        }
        return false;
    }


    public string Display()
    {
        var output = "<ul id='org' class='tree'>";
        output += this.RootNode.Display();
        output += "</ul>";
        return output;
    }

    public bool IsBalance(int expectedDept)
    {
        return RootNode.IsBalance(expectedDept);
    }
}