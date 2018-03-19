Imports System.Web

Public Class ConnectObj

    Public Shared Function ConnectionDB() As String
        Dim connect As String
        Try
            'connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/fsprings_database.mdb") + ";Persist Security Info=False;Jet OLEDB:Database Password=fsprings"

            'connect = "Data Source=.\SQLEXPRESS;Initial Catalog=legalpedia_client; Integrated Security=true; Connect Timeout=1440"
            ' connect = "Data Source=localhost;Initial Catalog=Bread4World; Integrated Security=True"
            connect = "Data Source=SQL7004.site4now.net;Initial Catalog=DB_A3438D_bre;User Id=DB_A3438D_bre_admin;Password=12345678qwe;"
            'connect = "Data Source=adminiven,1433; Network Library=DBMSSOCN;    Initial Catalog=legalpedia_server; User Id=diamondchild; Password=dia; Connection Timeout=150"
        Catch ex As Exception
            Throw New ApplicationException(ex.Message.ToString)
        End Try
        Return connect
    End Function

    Public Shared Function ConnectionSERVER() As String
        Dim connect As String
        Try
            'connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/fsprings_database.mdb") + ";Persist Security Info=False;Jet OLEDB:Database Password=fsprings"
            ' connect = "Data Source=u16331762.legalpediang.com,1433;Initial Catalog=legalpedia_desktop_Server; Integrated Security=false; User Id=sa; Password=legal123@francis; Connection Timeout=1440"

            ' connect = "Data Source=.;Initial Catalog=Bread4World; Integrated Security=True; connect Timeout=1440"
            connect = "Data Source=SQL7004.site4now.net;Initial Catalog=DB_A3438D_bre;User Id=DB_A3438D_bre_admin;Password=12345678qwe;"
            'connect = "Data Source=u19788506.nogconline.com,1433;Initial Catalog=GasLawDB; User Id=nogc2; Password=nogc@nogc1199; Integrated Security=false; Connection Timeout=1440"

        Catch ex As Exception
            Throw New ApplicationException(ex.Message.ToString)
        End Try
        Return connect
    End Function

End Class
