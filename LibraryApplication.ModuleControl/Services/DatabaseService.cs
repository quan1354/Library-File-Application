using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ModuleControl.ViewModels;
using MyMovieApplication.Core.Events;
using Prism.Events;
using static ModuleControl.Services.MyService;

namespace ModuleControl.Services
{
    public class DatabaseService
    {
        public SqlConnection con { get; set; }
        public SqlCommand command { get; set; }
        public DatabaseService(){
        }


        public void connectDatabase()
        {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();
            /*SqlCommand command = new SqlCommand("CREATE TABLE Video(" +
                "VideoID int IDENTITY(1,1)," +
                "Name nvarchar(100)," +
                "Date date," +
                "Descriptiom nvarchar(100)," +
                "Path nvarchar(MAX)," +
                "CONSTRAINT pk_Video_VideoID PRIMARY KEY(VideoID)" +
                ")", con);*/

            /*SqlCommand command = new SqlCommand("CREATE TABLE Folder(" +
                "FolderID int IDENTITY(1,1)," +
                "Name nvarchar(100)," +
                "SubFolder nvarchar(MAX)," +
                "CONSTRAINT pk_Folder_FolderID PRIMARY KEY(FolderID)" +
                ")", con);*/

            command.ExecuteNonQuery();
        }

        public Video insertData(Video video)
        {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();
            DateTime dateValue = DateTime.Now;
            command = new SqlCommand("SET IDENTITY_INSERT Video OFF;" +
                "INSERT INTO Video (Name, Date, Description, Path)" +
                "OUTPUT INSERTED.VideoID VALUES (@Name, @Date, @Description, @url)", con);
            command.Parameters.AddWithValue("@Name", video.Name);
            command.Parameters.AddWithValue("@Date", video.Date);
            command.Parameters.AddWithValue("@Description", video.Description);
            command.Parameters.AddWithValue("@url", video.Path);

            /*command = new SqlCommand("SET IDENTITY_INSERT Folder OFF;" +
                "INSERT INTO Folder VALUES (@Name, @SubFolder)", con);
            command.Parameters.AddWithValue("@Name", "Disney Princess");
            command.Parameters.AddWithValue("@SubFolder", "[1,3]");*/

            int insertedVideoID = (int)command.ExecuteScalar();
            video.VideoID = insertedVideoID;
            return video;
        }

        public ObservableCollection<Video> selectAllVideoData()
        {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();

            string query = "SELECT * FROM Video";
            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            ObservableCollection<Video> videoCollection = new ObservableCollection<Video>();

            while (reader.Read())
            {
                Video video = new Video();
                video.VideoID = reader.GetInt32(0);
                video.Name = reader.GetString(1);
                video.Date = reader.GetDateTime(2);
                video.Description = reader.GetString(3);
                video.Path = reader.GetString(4);

                videoCollection.Add(video);
            }
            return videoCollection;
        }

        public ObservableCollection<Folder> selectAllFolderData()
        {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();

            string query = "SELECT * FROM Folder";
            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            ObservableCollection<Folder> videoCollection = new ObservableCollection<Folder>();

            while (reader.Read())
            {
                Folder folder = new Folder();
                folder.FolderID = reader.GetInt32(0);
                folder.Name = reader.GetString(1);
                folder.SubFolder = reader.GetString(2);

                videoCollection.Add(folder);
            }
            return videoCollection;
        }

        public void deleteItem(Video video) {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();

            string query = "DELETE FROM Video WHERE VideoID = @id";
            
            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", Convert.ToString(video.VideoID));
            command.ExecuteNonQuery();
        }

        public void updateItem(Video video) {
            con = new SqlConnection(@"data source=CSL-0932\SQLEXPRESS;initial catalog=MyMovie;trusted_connection=true");
            con.Open();

            string query = "UPDATE Video " +
                               "SET Name = @Name, " +
                               "Description = @Description, " +
                               "Path = @Path, " +
                               "Date = @Date " +
                               "WHERE VideoID = @id";
            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", video.VideoID);
            command.Parameters.AddWithValue("@Name", video.Name);
            command.Parameters.AddWithValue("@Description", video.Description);
            command.Parameters.AddWithValue("@Path", video.Path);
            command.Parameters.AddWithValue("@Date", video.Date);
            command.ExecuteNonQuery();
        }
    }
}
