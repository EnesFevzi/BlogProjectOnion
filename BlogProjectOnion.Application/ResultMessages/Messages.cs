using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.ResultMessages
{
    public static class Messages
    {
        public static class Genre
        {
            public static string Add(string genreTitle)
            {
                return $"{genreTitle} başlıklı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string genreTitle)
            {
                return $"{genreTitle} başlıklı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string genreTitle)
            {
                return $"{genreTitle} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string genreTitle)
            {
                return $"{genreTitle} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }
        public static class Post
        {
            public static string Add(string postTitle)
            {
                return $"{postTitle} başlıklı gönderi başarıyla eklenmiştir.";
            }
            public static string Update(string postTitle)
            {
                return $"{postTitle} başlıklı gönderi başarıyla güncellenmiştir.";
            }
            public static string Delete(string postTitle)
            {
                return $"{postTitle} başlıklı gönderi başarıyla silinmiştir.";
            }
            public static string UndoDelete(string postTitle)
            {
                return $"{postTitle} başlıklı gönderi başarıyla geri alınmıştır.";
            }
        }
    }
}
