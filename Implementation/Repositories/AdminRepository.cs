using System.Text.Json;
using file.Entities;

namespace file.Implementation.Repositories
{
    public class AdminRepository
    {
        private readonly string filePath;
        public AdminRepository(string filePath)
        {
            this.filePath = filePath;
        }
        private void SaveAdmins(List<Admin> admins)
        {
            var options =  new JsonSerializerOptions{
                WriteIndented = true


            };
            string json = 
             JsonSerializer.Serialize(admins, options);
            File.WriteAllText(filePath, json);
        }
        public List<Admin>? GetAllAdmins()
        {
            if (!File.Exists(filePath))
            return new List<Admin>();


            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Admin>>(json);
        }
        public void Add()
        {
            List<Admin>? admins = GetAllAdmins();
            Admin admin = new Admin()
            {
                Name = "Mahmudah Adeyemi",
                Email = "adeyemi.mahmudah@gmail.com",
                Password = "mahmudah2009",
                Address = "Gbonagun"
            };
            admins.Add(admin);
            SaveAdmins(admins); 
        }
    }
}
