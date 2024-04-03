using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingPicsEFCore.Data
{
    public class PicRepository
    {
        private readonly string _connectionString;

        public PicRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Picture> GetPictures()
        {
            using ImageDataContext context = new ImageDataContext(_connectionString);
            return context.Pictures.ToList();
        }

        public void AddPicture(Picture p)
        {
            using ImageDataContext context = new ImageDataContext(_connectionString);
            context.Pictures.Add(p);
            context.SaveChanges();
        }

        public Picture GetByID(int id)
        {
            using ImageDataContext context = new ImageDataContext(_connectionString);
            return context.Pictures.FirstOrDefault(p => p.ID == id);
        }
    }
}
