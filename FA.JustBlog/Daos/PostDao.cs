
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fa.JustBlog.Daos
{
    public class PostDao
    {
        DBContext myDb = new DBContext();

        public List<Post> getAll()
        {
            return myDb.Posts.OrderByDescending(p => p.id_post).ToList();
        }

        public List<Post> getPost()
        {
            return myDb.Posts.OrderByDescending(p => p.id_post).Take(5).ToList();
        }


        public Post getPostById(int id)
        {
            return myDb.Posts.FirstOrDefault(x =>x.id_post == id);
        }
        public void addPost(Post post)
        {
            myDb.Posts.Add(post);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.Posts.FirstOrDefault(x => x.id_post == id);
            myDb.Posts.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Post post)
        {
            var obj = myDb.Posts.FirstOrDefault(x => x.id_post == post.id_post);
            obj.title = post.title;
            obj.desShort = post.desShort;
            obj.content = post.content;
            myDb.SaveChanges();
        }
    }
}